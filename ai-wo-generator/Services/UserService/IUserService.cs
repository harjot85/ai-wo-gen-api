using ai_wo_generator.Models;
using ai_wo_generator.Models.DTO;

namespace ai_wo_generator.Services.UserService
{
    public interface IUserService
    {
        Task<int> RegisterAsync(UserRegisterationRequest request);

        Task<UserProfileDto?> GetUserAsync(int id);

        // TODO: Returns JWT token with user id | bool is temporary for now
        Task<int> LoginAsync(UserLoginRequest loginRequest);

        Task<int> SaveAsync(UserProfile request);
    }
}
