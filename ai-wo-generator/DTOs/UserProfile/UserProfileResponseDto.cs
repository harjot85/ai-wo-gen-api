using ai_wo_generator.Models;

namespace ai_wo_generator.DTOs.UserProfile
{
    public class UserProfileResponseDto
    {
        public UserDto User = new();
        public UserStatistics? Statistics { get; set; }
    }
}
