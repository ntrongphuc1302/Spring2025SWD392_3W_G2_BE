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
using MetroOne.DAL.Models;
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

        #region Login
        public async Task<LoginResponse?> LoginAsync(LoginRequest dto)
        {
            // Check if the user exists and validate the password
            var user = await _unitOfWork.Users.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "Passenger"),
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

        #endregion

        #region Register
        public async Task<RegisterResponse?> RegisterAsync(RegisterRequest dto)
        {
            var role = dto.Role ?? "Passenger"; // Default role

            //check if role is Passenger or Admin or Driver
            if (dto.Role != null && dto.Role != "Passenger" && dto.Role != "Admin" && dto.Role != "Driver")
                role = "Passenger"; // Default role

            // Check if the email already exists
            if (await _unitOfWork.Users.IsEmailExistsAsync(dto.Email))
                return null;


            var user = new User
                {
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password, workFactor:12),
                    FullName = dto.FullName,
                    Phone = dto.Phone,
                    Role = role,
                    Status = dto.Status ?? "Active", // Default status
            };
            var result = await _unitOfWork.Users.CreateAsync(user);
            if (!result)
                return null;
            return new RegisterResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Status = user.Status
            };
        }

        #endregion
    }

}
