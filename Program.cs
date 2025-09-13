using FutebolApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlite("Data Source=Futebol.db"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

