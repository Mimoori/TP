using MicroserviceTeacher.Models;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceTeacher;
public class TeacherContext : DbContext
{
    public TeacherContext(DbContextOptions<TeacherContext> options)
    : base(options)
    {
    }
    public DbSet<Teacher> Teachers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity
            .ToTable("teachers")
            .HasKey(e => e.Id);
            entity
             .Property(e => e.Id)
             .HasColumnName("id");
            entity
             .Property(e => e.Name)
             .HasColumnName("name");
            entity
            .Property(e => e.Subject)
            .HasColumnName("subject");
            entity
          .Property(e => e.Worktime)
          .HasColumnName("worktime");
        });
    }

}