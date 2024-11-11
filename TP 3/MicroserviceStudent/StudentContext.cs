using MicroserviceStudent.Models;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceStudent;
public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
    : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity
            .ToTable("student")
            .HasKey(e => e.Id);

            entity
             .Property(e => e.Id)
             .HasColumnName("id");

            entity
             .Property(e => e.Name)
             .HasColumnName("name");

            entity
            .Property(e => e.GroupName)
            .HasColumnName("groupname");

            entity
            .Property(e => e.Rating)
            .HasColumnName("rating");
        });
    }
}
