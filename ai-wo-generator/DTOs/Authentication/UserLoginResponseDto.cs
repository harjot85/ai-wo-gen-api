using ai_wo_generator.DTOs.UserProfile;

namespace ai_wo_generator.DTOs.Authentication
{
    public class UserLoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int ExpiryInMinutes { get; set; }
        public UserDto User { get; set; } = new();
    }
}
