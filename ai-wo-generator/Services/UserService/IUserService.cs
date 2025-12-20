using ai_wo_generator.DTOs;
using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.DTOs.UserProfile;

namespace ai_wo_generator.Services.UserService
{
    public interface IUserService
    {
        Task<UserProfileResponseDto?> GetUserAsync(int id);
    }
}
