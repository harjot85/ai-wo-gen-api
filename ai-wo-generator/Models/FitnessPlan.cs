namespace ai_wo_generator.Models
{
    public class FitnessPlanSave
    {
        public int UserId { get; set; }
        public int FitnessPlanId { get; set; }
        public string Plan { get; set; } = string.Empty;
        public DateTime DateCreated { get; } = DateTime.UtcNow;

    }

    public class FitnessPlanGenerate
    {
        public Statistics Statistics { get; set; } = new Statistics();
        public Equipment[] AvailableEquipment { get; set; } = [new Equipment()];
        public string Goal { get; set; } = string.Empty;
        public string Preference { get; set; } = string.Empty;

    }

    public class Statistics
    {
        public int Height { get; set;}
        public int Weight { get; set;}
    }

    public class Equipment
    {
        public string Name { get; set; } = string.Empty;
    }
}