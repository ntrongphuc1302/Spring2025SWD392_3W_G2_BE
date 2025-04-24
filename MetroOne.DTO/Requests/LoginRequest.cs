﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MetroOne.DTO.Requests
{
    public class LoginRequest
    {
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
