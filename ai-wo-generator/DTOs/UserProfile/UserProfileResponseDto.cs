using ai_wo_generator.Models;

namespace ai_wo_generator.DTOs.UserProfile
{
    public class UserProfileResponseDto
    {
        
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public UserStatistics? Statistics { get; set; }

    }
}
