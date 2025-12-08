namespace ai_wo_generator.DTOs.Authentication
{
    public class UserRegisterationRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string? FullName { get; set; }
    }
}
