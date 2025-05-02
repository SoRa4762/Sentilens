using Microsoft.OpenApi.Models; // Add this using directive for OpenApiInfo
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Add this using directive for AppDbContext
//using AutoMapper; no need actually
using MediatR;
using api.Core.Interfaces.Base;
using api.Infrastructure.Repositories.Base;
using api.Core.Interfaces;
using api.Infrastructure.Repositories;
using Asp.Versioning;
using api.Application.Handlers.ArticleHandlers;
using api.Infrastructure.Services.FeedSourceServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// configuring the controllers and swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Sentilens V1",
        Version = "v1",
    });
});

// configuring the API versioning
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

// configuring the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// configuring AutoMappers and MediatR
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddMediatR(typeof(CreateArticleCommandHandler).Assembly); -> use this if the cfg does not have RegisterServicesFromAssembly, unavailable to MediatR version below 12
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommandHandler).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // service type and implementation type
builder.Services.AddTransient<IArticleRepository, ArticleRepository>(); // adds transient service of type specified in interface to implementation type specified in repositories
builder.Services.AddTransient<IFeedSourceRepository, FeedSourceRepository>();

// services
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
using (var scope = app.Services.CreateScope()){
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
app.UseAuthorization();
app.MapControllers();

// didn't fix it
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();