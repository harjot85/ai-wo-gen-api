using ai_wo_generator.Models;

namespace ai_wo_generator.DTOs.UserProfile
{
    public class UserProfileCreateDto
    {
        User User { get; set; } = new();
        UserStatistics Statistics { get; set; } = new();
    }
}
