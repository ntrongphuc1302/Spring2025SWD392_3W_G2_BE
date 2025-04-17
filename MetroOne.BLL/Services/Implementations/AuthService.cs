using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DTO.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Config;

namespace MetroOne.BLL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepo, IOptions<JwtSettings> jwtOptions)
        {
            _userRepo = userRepo;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || user.Password != dto.Password) // Use hashing in real apps
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "User"),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return new LoginResponse
            {
                Token = jwt,
                Role = user.Role,
                FullName = user.FullName,
                ExpiresIn = _jwtSettings.ExpiryMinutes * 60
            };
        }
    }

}
