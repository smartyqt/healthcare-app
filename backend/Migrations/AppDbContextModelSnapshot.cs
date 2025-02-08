﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactInfo = "5551234567",
                            DateOfBirth = new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            ContactInfo = "5555678901",
                            DateOfBirth = new DateTime(1992, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            ContactInfo = "5554321987",
                            DateOfBirth = new DateTime(2000, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Non-binary",
                            Name = "Alex Johnson"
                        },
                        new
                        {
                            Id = 4,
                            ContactInfo = "5557890123",
                            DateOfBirth = new DateTime(1978, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Michael Brown"
                        },
                        new
                        {
                            Id = 5,
                            ContactInfo = "5552468135",
                            DateOfBirth = new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Sarah Wilson"
                        },
                        new
                        {
                            Id = 6,
                            ContactInfo = "5551357924",
                            DateOfBirth = new DateTime(1989, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Emily Davis"
                        },
                        new
                        {
                            Id = 7,
                            ContactInfo = "5559876543",
                            DateOfBirth = new DateTime(1980, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "James Miller"
                        },
                        new
                        {
                            Id = 8,
                            ContactInfo = "5556543210",
                            DateOfBirth = new DateTime(1993, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Olivia Martinez"
                        },
                        new
                        {
                            Id = 9,
                            ContactInfo = "5553214987",
                            DateOfBirth = new DateTime(1975, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "William Anderson"
                        },
                        new
                        {
                            Id = 10,
                            ContactInfo = "5557894561",
                            DateOfBirth = new DateTime(2002, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Name = "Sophia Thomas"
                        });
                });

            modelBuilder.Entity("backend.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Recommendations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Annual allergy test",
                            IsCompleted = false,
                            PatientId = 1,
                            Type = "Allergy Check"
                        },
                        new
                        {
                            Id = 2,
                            Description = "General health screening",
                            IsCompleted = false,
                            PatientId = 2,
                            Type = "Screening"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Routine BP monitoring",
                            IsCompleted = false,
                            PatientId = 3,
                            Type = "Blood Pressure Check"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cholesterol level check",
                            IsCompleted = false,
                            PatientId = 4,
                            Type = "Cholesterol Screening"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Check for required vaccinations",
                            IsCompleted = false,
                            PatientId = 5,
                            Type = "Vaccination Update"
                        });
                });

            modelBuilder.Entity("backend.Models.Recommendation", b =>
                {
                    b.HasOne("backend.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
