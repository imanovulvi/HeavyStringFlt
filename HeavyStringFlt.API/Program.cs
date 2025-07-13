using HeavyStringFlt.API.Business.Abstraction;
using HeavyStringFlt.API.Business.Concret;
using HeavyStringFlt.API.WorkerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(ChunkService));
builder.Services.AddSingleton(typeof(BackgroundQueue));

builder.Services.AddHostedService<Worker>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
