using ai_wo_generator.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ai_wo_generator.Services
{
    public class JwtService(IOptions<JWTSettings> options)
    {
        private readonly JWTSettings _jwtSettings = options.Value;

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.ApiKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }

        public int GetTokenExpiryInMinutes()
        {
            return _jwtSettings.ExpiryInMinutes;
        }
    }
}
