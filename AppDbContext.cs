using kolokwium2_przyklad.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2_przyklad.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}