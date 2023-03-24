using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("TodoDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/todo" , async (AppDbContext context) =>
{
    var todoItems = await context.TodoItems.ToListAsync();
    return Results.Ok(todoItems);
});

app.MapPost("api/todo" , async (AppDbContext context, TodoItem todoItem) =>
{
    await context.TodoItems.AddAsync(todoItem);
    await context.SaveChangesAsync();
    return Results.Created($"/api/todo/{todoItem.Id}", todoItem);
});

app.Run();

