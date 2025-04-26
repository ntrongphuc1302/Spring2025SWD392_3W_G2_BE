using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MetroOne.DTO.Requests
{
    public class RegisterRequest
    {
        [DefaultValue("Full name")]
        public string? FullName { get; set; }
        [DefaultValue("example@email.com")]
        public string? Email { get; set; }
        [DefaultValue("Your_password")]
        public string? Password { get; set; }
        [DefaultValue("Active")]
        public string? Status { get; set; }
        [DefaultValue("Passenger")]
        public string? Permission { get; set; }

    }

}
