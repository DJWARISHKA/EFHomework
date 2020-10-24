﻿// <auto-generated />
using EFHomework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFHomework.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("EFHomework.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("StudentsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Faculty");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Технической кибернетики",
                            StudentsCount = 4
                        },
                        new
                        {
                            Id = 2,
                            Name = "Мостов и тунелей",
                            StudentsCount = 1
                        });
                });

            modelBuilder.Entity("EFHomework.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("StudentsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Group");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            Name = "1488",
                            StudentsCount = 2
                        },
                        new
                        {
                            Id = 2,
                            FacultyId = 1,
                            Name = "653",
                            StudentsCount = 2
                        },
                        new
                        {
                            Id = 3,
                            FacultyId = 2,
                            Name = "КБ12",
                            StudentsCount = 1
                        });
                });

            modelBuilder.Entity("EFHomework.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            GroupId = 1,
                            Name = "Tom"
                        },
                        new
                        {
                            Id = 2,
                            Age = 26,
                            GroupId = 1,
                            Name = "Alice"
                        },
                        new
                        {
                            Id = 3,
                            Age = 20,
                            GroupId = 2,
                            Name = "Nick"
                        },
                        new
                        {
                            Id = 4,
                            Age = 21,
                            GroupId = 2,
                            Name = "Sam"
                        },
                        new
                        {
                            Id = 5,
                            Age = 28,
                            GroupId = 3,
                            Name = "Jesus"
                        });
                });

            modelBuilder.Entity("EFHomework.Entities.Group", b =>
                {
                    b.HasOne("EFHomework.Entities.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFHomework.Entities.Student", b =>
                {
                    b.HasOne("EFHomework.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
