var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Chirps API v0.0.1");

app.MapGet("/chirps", () => Results.Ok(new[] {
    new { Id = 1, Message = "Hello World!" },
    new { Id = 2, Message = "Goodbye cruel world..." }
}));

app.Run();