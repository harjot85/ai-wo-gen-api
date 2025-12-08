using ai_wo_generator.DTOs;
using ai_wo_generator.DTOs.Authentication;
using ai_wo_generator.DTOs.UserProfile;

namespace ai_wo_generator.Services.UserService
{
    public interface IUserService
    {
        Task<int> RegisterAsync(UserRegisterationRequest request);

        Task<UserProfileResponseDto?> GetUserAsync(int id);

        // TODO: Returns JWT token with user id | bool is temporary for now
        Task<int> LoginAsync(UserLoginRequest loginRequest);
    }
}
