using ai_wo_generator.DTOs.Authentication;

namespace ai_wo_generator.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserLoginResponseDto> RegisterAsync(UserRegisterationRequest request);

        // TODO: Returns JWT token with user id | bool is temporary for now
        Task<UserLoginResponseDto> LoginAsync(UserLoginRequest loginRequest);
    }
}
