using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Entity;

namespace ToDoList.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}