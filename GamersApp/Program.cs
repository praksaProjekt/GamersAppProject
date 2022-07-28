global using GamersApp.Data;
global using Microsoft.EntityFrameworkCore;
using GamersApp.ServiceInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddJwtAuthenticationExtension();
builder.Services.AddServiceInjectionExtension();
builder.Services.AddControllers();
builder.Services.AddDbContextExtension(builder);
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

app.UseCors("EnableCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
