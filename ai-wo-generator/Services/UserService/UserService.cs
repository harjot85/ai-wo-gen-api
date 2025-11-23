using ai_wo_generator.Models;
using ai_wo_generator.Repository;

namespace ai_wo_generator.Services.UserService
{
    public class UserService(IUserRepository userRepository): IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<int> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }
            var user = new User
            {
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow
            };
            return await _userRepository.CreateAsync(user);
        }
        
        public async Task<User?> GetUserAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        private string HashPassword(string password)
        {
            
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
