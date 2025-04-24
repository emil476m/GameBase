using infrastructur.Interfaces;
using infrastruvtur.Implementation;
using infrastruvtur.Models.externals;
using service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsqlDataSource(Environment.GetEnvironmentVariable("pgconn")!,
    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

builder.Services.AddScoped<ISearchRepository<SearchDto, GameDto>, SearchRepositorySearchDto>();

builder.Services.AddScoped<IService<SearchDto, GameDto>, ServiceSearchDto>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => //TODO Add a cors policy for linked page
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();