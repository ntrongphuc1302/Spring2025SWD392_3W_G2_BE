using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class LoginResponse
    {
        public required string Token { get; set; }
        public required string Role { get; set; }
        public required string FullName { get; set; }
        public required int ExpiresIn { get; set; }
    }
}
