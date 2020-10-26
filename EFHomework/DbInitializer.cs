using System.Collections.Generic;
using System.Linq;
using EFHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFHomework
{
    public static class DbInitializer
    {
        public static async void DbInitialize(AppContext context)
        {
            //await context.Database.EnsureCreatedAsync();
            if (!await context.Students.AnyAsync())
            {
                await context.Students.AddRangeAsync(
                    new Student {Name = "Tom", Age = 23},
                    new Student {Name = "Alice", Age = 26},
                    new Student {Name = "Nick", Age = 20},
                    new Student {Name = "Sam", Age = 21},
                    new Student {Name = "Jesus", Age = 28});
                await context.SaveChangesAsync();
            }

            if (!await context.Groups.AnyAsync())
            {
                await context.Groups.AddRangeAsync(
                    new Group
                    {
                        Name = "1488", StudentsCount = 2,
                        Students = new List<Student>(context.Students.Take(2))
                    },
                    new Group
                    {
                        Name = "653", StudentsCount = 2,
                        Students = new List<Student>(context.Students.Skip(2).Take(2))
                    },
                    new Group
                    {
                        Name = "КБ12", StudentsCount = 1,
                        Students = new List<Student>(context.Students.Skip(4).Take(1))
                    });
                await context.SaveChangesAsync();
            }

            if (!await context.Faculties.AnyAsync())
            {
                await context.Faculties.AddRangeAsync(
                    new Faculty
                    {
                        Name = "Технической кибернетики", StudentsCount = 4,
                        Groups = new List<Group>(context.Groups.Take(2))
                    },
                    new Faculty
                    {
                        Name = "Мостов и тунелей", StudentsCount = 1,
                        Groups = new List<Group>(context.Groups.Skip(2).Take(1))
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}