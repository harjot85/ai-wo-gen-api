using ai_wo_generator.Models;

namespace ai_wo_generator.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
    }
}
