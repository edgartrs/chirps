using Microsoft.EntityFrameworkCore;
using Chirps.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ChirpsDbContext>(options => options.UseInMemoryDatabase("Chirps"));
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Chirps API v0.0.1");

app.MapGet("/chirps", async (ChirpsDbContext db) => await db.Chirps.ToListAsync());
app.MapGet("/chirps/{id}", async (Guid id, ChirpsDbContext db) => await db.Chirps.FindAsync(id) is Chirp chirp ? Results.Ok(chirp) : Results.NotFound());
app.MapPost("/chirps", async (string message, ChirpsDbContext db) =>
{
  var chirp = new Chirp { Message = message, CreatedAt = DateTime.Now, Id = Guid.NewGuid() };
  await db.Chirps.AddAsync(chirp);
  await db.SaveChangesAsync();
  return Results.Created($"/chirps/{chirp.Id}", chirp);
});
app.Run();