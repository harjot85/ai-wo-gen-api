namespace ai_wo_generator.DTOs
{
    public class UserFitnessPlanParameters
    {
        public int userId { get; set; }
        public FitnessPlanParameters FitnessParameters        { get; set; } = new();
    }

    public class FitnessPlanParameters
    {
        public WorkoutPreferences WorkoutPreferences { get; set; } = new();
        public List<string> Equipment { get; set; } = [];
    }

    public class FitnessPlanSave
    {
        public int UserId { get; set; }
        public int FitnessPlanId { get; set; }
        public string Plan { get; set; } = string.Empty;
        public DateTime DateCreated { get; } = DateTime.UtcNow;
    }
  
    public class WorkoutPreferences
    {
        public string Goal { get; set; } = string.Empty;
        public string NumberOfDays { get; set; } = string.Empty;
        public string WorkoutDuration { get; set; } = string.Empty;
        public string ExercisePreferences { get; set; } = string.Empty;
    }

   
}