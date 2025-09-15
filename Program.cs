using FutebolApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlite("Data Source=Futebol.db"));

var app = builder.Build();

//GET All 
app.MapGet("/times", async (AppDbContext db) =>
{
    return await db.Times.ToListAsync();
});

//GET por id
app.MapGet("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    return time is not null ? Results.Ok(time) : Results.NotFound("Time não encontrado");
});

app.MapPost("/times", async (AppDbContext db, Time novoTime) =>
{
    db.Times.Add(novoTime);
    await db.SaveChangesAsync();
    return Results.Created($"O time {novoTime.Nome} foi adicionado com sucesso!", novoTime);
});

app.Run();

