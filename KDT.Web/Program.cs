using KDT.SimpleDiff;
using KDT.Web.Database;
using KDT.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KdtDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSimpleDiff(
    connectionString: @"Data Source=C:\Users\KonDzik\source\repos\KonDzikToolbox\kdt.sqlite;");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSimpleDiff();

app.Run();