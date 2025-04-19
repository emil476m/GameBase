
using System.Reflection.Metadata;
using infrastructur.Interfaces;
using infrastruvtur.Implementation;
using service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISearchRepository<string, string>, SeartchRepositoryString>();
builder.Services.AddScoped<IService<string, string>, ServiceString>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();