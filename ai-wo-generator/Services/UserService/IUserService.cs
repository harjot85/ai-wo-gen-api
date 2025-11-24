using ai_wo_generator.Models;
using ai_wo_generator.Models.DTO;

namespace ai_wo_generator.Services.UserService
{
    public interface IUserService
    {
        Task<int> RegisterAsync(UserRegisterationRequest request);
        Task<UserProfileDto?> GetUserAsync(int id);

        Task<UserProfileDto?> LoginAsync(UserLoginRequest loginRequest);
    }
}
