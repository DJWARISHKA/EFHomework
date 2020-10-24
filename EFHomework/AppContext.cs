using EFHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFHomework
{
    public class AppContext : DbContext
    {
        public DbSet<Faculty> Faculties;
        public DbSet<Group> Groups;
        public DbSet<Student> Students;

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>().HasKey(f => f.Id);
            modelBuilder.Entity<Faculty>().Property(f => f.Name).HasMaxLength(50);
            modelBuilder.Entity<Faculty>().HasMany(f => f.Groups)
                .WithOne(f => f.Faculty)
                .HasForeignKey(g => g.FacultyId);

            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Group>().Property(g => g.Name).HasMaxLength(50);
            modelBuilder.Entity<Group>().HasMany(g => g.Students)
                .WithOne(g => g.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Student>().HasKey(g => g.Id);
            modelBuilder.Entity<Student>().Property(g => g.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(g => g.Age).IsRequired();

            modelBuilder.Entity<Student>().HasData(
                new Student {Id = 1, Name = "Tom", Age = 23, GroupId = 1},
                new Student {Id = 2, Name = "Alice", Age = 26, GroupId = 1},
                new Student {Id = 3, Name = "Nick", Age = 20, GroupId = 2},
                new Student {Id = 4, Name = "Sam", Age = 21, GroupId = 2},
                new Student {Id = 5, Name = "Jesus", Age = 28, GroupId = 3});

            modelBuilder.Entity<Group>().HasData(
                new Group {Id = 1, Name = "1488", FacultyId = 1, StudentsCount = 2},
                new Group {Id = 2, Name = "653", FacultyId = 1, StudentsCount = 2},
                new Group {Id = 3, Name = "КБ12", FacultyId = 2, StudentsCount = 1});

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty {Id = 1, Name = "Технической кибернетики", StudentsCount = 4},
                new Faculty {Id = 2, Name = "Мостов и тунелей", StudentsCount = 1});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=University.db");
        }
    }
}