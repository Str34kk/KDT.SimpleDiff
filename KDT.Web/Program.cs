using KDT.Web.Database;
using KDT.Web.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KdtContext>(o => o.UseInMemoryDatabase("KDT"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/fetchsmallitems", async (KdtContext db) =>
    await db.SmallItems.ToListAsync());

app.MapPost("/addsmalitem", async (SmallItem smallItem, KdtContext db) =>
{
    db.SmallItems.Add(smallItem);
    await db.SaveChangesAsync();

    return Results.Created("/addsmalitem", smallItem);
});

app.Run();