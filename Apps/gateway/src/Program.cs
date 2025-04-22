using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//ocelot
builder.Configuration
    .AddJsonFile("configs/ocelot.global.json", optional: false, reloadOnChange: true);
builder.Configuration    
    .AddJsonFile("configs/ocelot.search_engine-service.json", optional: false, reloadOnChange: true); 
builder.Configuration
    .AddJsonFile("configs/ocelot.review_handler-service.json", optional: false, reloadOnChange: true);
builder.Configuration
    .AddJsonFile("configs/ocelot.create_service.json", optional: false, reloadOnChange: true);
    //Further services that should be added to gateway added here
    //builder.Configuration.AddJsonFile("configs/ocelot.<NameOfFile>.json", optional: false, reloadOnChange: true); 

builder.Services.AddOcelot(builder.Configuration);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.Run();

