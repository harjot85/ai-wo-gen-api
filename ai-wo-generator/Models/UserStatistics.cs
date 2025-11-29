namespace ai_wo_generator.Models
{
    public class UserStatistics
    {
        public long UserId { get; set; } 
        public decimal? HeightInInches { get; set; }
        public decimal? WeightInPounds { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
