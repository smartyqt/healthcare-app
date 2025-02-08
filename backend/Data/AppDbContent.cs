using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(1985, 5, 12), Gender = "Male", ContactInfo = "555-123-4567" },
                new Patient { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1992, 8, 24), Gender = "Female", ContactInfo = "555-567-8901" },
                new Patient { Id = 3, Name = "Alex Johnson", DateOfBirth = new DateTime(2000, 3, 14), Gender = "Non-binary", ContactInfo = "555-432-1987" },
                new Patient { Id = 4, Name = "Michael Brown", DateOfBirth = new DateTime(1978, 7, 30), Gender = "Male", ContactInfo = "555-789-0123" },
                new Patient { Id = 5, Name = "Sarah Wilson", DateOfBirth = new DateTime(1995, 12, 5), Gender = "Female", ContactInfo = "555-246-8135" },
                new Patient { Id = 6, Name = "Emily Davis", DateOfBirth = new DateTime(1989, 9, 17), Gender = "Female", ContactInfo = "555-135-7924" },
                new Patient { Id = 7, Name = "James Miller", DateOfBirth = new DateTime(1980, 6, 21), Gender = "Male", ContactInfo = "555-987-6543" },
                new Patient { Id = 8, Name = "Olivia Martinez", DateOfBirth = new DateTime(1993, 4, 9), Gender = "Female", ContactInfo = "555-654-3210" },
                new Patient { Id = 9, Name = "William Anderson", DateOfBirth = new DateTime(1975, 11, 2), Gender = "Male", ContactInfo = "555-321-4987" },
                new Patient { Id = 10, Name = "Sophia Thomas", DateOfBirth = new DateTime(2002, 8, 11), Gender = "Female", ContactInfo = "555-789-4561" }
            );

            modelBuilder.Entity<Recommendation>().HasData(
                new Recommendation { Id = 1, PatientId = 1, Type = "Allergy Check", Description = "Annual allergy test", IsCompleted = false },
                new Recommendation { Id = 2, PatientId = 2, Type = "Screening", Description = "General health screening", IsCompleted = false },
                new Recommendation { Id = 3, PatientId = 3, Type = "Blood Pressure Check", Description = "Routine BP monitoring", IsCompleted = false },
                new Recommendation { Id = 4, PatientId = 4, Type = "Cholesterol Screening", Description = "Cholesterol level check", IsCompleted = false },
                new Recommendation { Id = 5, PatientId = 5, Type = "Vaccination Update", Description = "Check for required vaccinations", IsCompleted = false }
            );
        }
    }
}
