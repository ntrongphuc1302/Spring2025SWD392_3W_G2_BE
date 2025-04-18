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
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Azure;
using MetroOne.DAL.UnitOfWork;

namespace MetroOne.BLL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork, IOptions<JwtSettings> jwtOptions)
        {
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest dto)
        {
            // Check if the user exists and validate the password
            var user = await _unitOfWork.Users.GetByEmailAsync(dto.Email);
            if (user == null || user.Password != dto.Password) // Use hashing in real apps
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "User"),
            };

            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = now,
                IssuedAt = now,
                Expires = now.AddMinutes(_jwtSettings.ExpiryMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            var responseOjb = new LoginResponse
            {
                Token = jwt,
                Role = user.Role,
                FullName = user.FullName,
                ExpiresIn = _jwtSettings.ExpiryMinutes * 60
            };

            return (responseOjb);
        }
    }

}
