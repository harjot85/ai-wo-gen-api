namespace ai_wo_generator.Models
{ 
    public class UserStatistics
    {
        public DateTime DateOfBirth { get; set; }
        public decimal WeightInLbs { get; set; }
        public decimal HeightInInches { get; set; }
        public string BiologicalSex { get; set; } = string.Empty;        
        public string? ExperienceLevel { get; set; }
        public string? Profession { get; set; }
        public string? ChronicPhysicalLimitations { get; set; }
        public string? MedicalIssues { get; set; }
    }
}
