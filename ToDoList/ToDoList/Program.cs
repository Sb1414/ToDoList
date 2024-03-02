using Microsoft.EntityFrameworkCore;
using ToDoList.DAL;
using Microsoft.Extensions.Configuration;
using ToDoList.DAL.Intefaces;
using ToDoList.DAL.Repositories;
using ToDoList.Domain.Entity;
using ToDoList.Domain.Response;
using ToDoList.Service.Implementations;
using ToDoList.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

var connectionString = builder.Configuration.GetConnectionString("Postgres");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
