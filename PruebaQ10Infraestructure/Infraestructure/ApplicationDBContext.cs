using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Registration>()
                .HasOne(l => l.Student)
                .WithMany(u => u.Registrations)
                .HasForeignKey(l => l.StudentId)
                .IsRequired();

            modelBuilder.Entity<Registration>()
                .HasOne(l => l.Subject)
                .WithMany(u => u.Registrations)
                .HasForeignKey(l => l.SubjectId)
                .IsRequired();
        }
    }
}
