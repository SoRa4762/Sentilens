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
// use this if the cfg does not have RegisterServicesFromAssembly, unavailable to MediatR version below 12
//builder.Services.AddMediatR(typeof(CreateArticleCommandHandler).Assembly);
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssembly(typeof(CreateArticleCommandHandler).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // service type and implementation type
builder.Services.AddTransient<IArticleRepository, ArticleRepository>(); // adds transient service of type specified in interface to implementation type specified in repositories
builder.Services.AddTransient<IFeedSourceRepository, FeedSourceRepository>();

var app = builder.Build();

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