using Microsoft.OpenApi.Models; // Add this using directive for OpenApiInfo
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; // Add this using directive for AppDbContext
using AutoMapper;
using MediatR;
using api.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Sentilens V1",
        Version = "v1",
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddMediatR(typeof(CreateArticleCommandHandler).Assembly); // use this if the cfg does not have RegisterServicesFromAssembly
//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly
//    (typeof(CreateArticleCommandHandler).Assembly));
builder.Services.AddMediatR(cfg =>
  cfg.RegisterServicesFromAssembly
  (typeof(CreateArticleCommandHandler).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.Run();