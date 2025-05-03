using Microsoft.OpenApi.Models; // Add this using directive for OpenApiInfo
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Add this using directive for AppDbContext
using MediatR;
using api.Core.Interfaces.Base;
using api.Infrastructure.Repositories.Base;
using api.Core.Interfaces;
using api.Infrastructure.Repositories;
using Asp.Versioning;
using api.Application.Handlers.ArticleHandlers;
using System.Text.Json.Serialization;
using api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using api.Core.Services.AuthenticationServices;
using api.Infrastructure.Extensions.FeedSourceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// controllers and swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Sentilens V1",
        Version = "v1",
    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    }); 
});

// API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// authentication
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])
            )
        };
    });

// AutoMappers and MediatR
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddMediatR(typeof(CreateArticleCommandHandler).Assembly); -> use this if the cfg does not have RegisterServicesFromAssembly, unavailable to MediatR version below 12
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommandHandler).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // service type and implementation type
builder.Services.AddTransient<IArticleRepository, ArticleRepository>(); // adds transient service of type specified in interface to implementation type specified in repositories
builder.Services.AddTransient<IFeedSourceRepository, FeedSourceRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

// EXTENSIONS
builder.Services.AddHostedService<FeedAggregatorService>();
//builder.Services.AddScoped<IFeedFetcher, FeedFetcher>(); - remove it, replaced XML reader with HttpClient so yeah!

// Http Client
builder.Services.AddHttpClient<IFeedFetcher, FeedFetcher>(client =>
{
    client.DefaultRequestHeaders.UserAgent.ParseAdd("MyNewsAggregator/1.0");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Ignore JSON object cycle
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Optional: to keep original property names
    });

var app = builder.Build();

// seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AppDbContext>();
        await dbContext.SeedFeedSourcesAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding to the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// didn't fix it
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();