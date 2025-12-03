namespace ai_wo_generator.Models
{
    public class UserProfile
    {
        User User { get; set; } = new();
        UserStatistics Statistics { get; set; } = new();
    }
}
