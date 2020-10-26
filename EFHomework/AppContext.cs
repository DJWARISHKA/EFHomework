using EFHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFHomework
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.Migrate();
            DbInitializer.DbInitialize(this);
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>().HasKey(f => f.Id);
            modelBuilder.Entity<Faculty>().Property(f => f.Name).HasMaxLength(50);
            modelBuilder.Entity<Faculty>().HasMany(f => f.Groups)
                .WithOne(f => f.Faculty);

            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Group>().Property(g => g.Name).HasMaxLength(50);
            modelBuilder.Entity<Group>().HasMany(g => g.Students)
                .WithOne(g => g.Group);

            modelBuilder.Entity<Student>().HasKey(g => g.Id);
            modelBuilder.Entity<Student>().Property(g => g.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(g => g.Age).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=University.db");
        }
    }
}