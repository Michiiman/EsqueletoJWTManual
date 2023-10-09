using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiEscuelaContext : DbContext
{
    public ApiEscuelaContext(DbContextOptions<ApiEscuelaContext> options) : base(options)
    {
    }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Grade> Grades{ get; set; }
    public DbSet<Role> Roles{ get; set; }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Subject> Subjects{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
    public DbSet<User> Users{ get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}