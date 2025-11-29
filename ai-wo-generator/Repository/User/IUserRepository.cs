using ai_wo_generator.Models;

// Ensure that the correct 'User' type is referenced.
// If 'User' is both a namespace and a class, use the fully qualified name for the class.
namespace ai_wo_generator.Repository.User
{
    public interface IUserRepository
    {
        Task<ai_wo_generator.Models.User?> GetByEmailAsync(string email);
        Task<ai_wo_generator.Models.User?> GetByIdAsync(int id);
        Task<int> CreateAsync(ai_wo_generator.Models.User user);
    }
}
