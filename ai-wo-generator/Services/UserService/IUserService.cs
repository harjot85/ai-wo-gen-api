using ai_wo_generator.Models;

namespace ai_wo_generator.Services.UserService
{
    public interface IUserService
    {
        Task<int> RegisterAsync(RegisterRequest request);
        Task<User?> GetUserAsync(int id);
    }
}
