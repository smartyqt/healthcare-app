namespace backend.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }

        public int PatientId { get; set; } // Foreign Key
        public Patient? Patient { get; set; } // Navigation Property
    }

}

