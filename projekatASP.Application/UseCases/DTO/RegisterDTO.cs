﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Application.UseCases.DTO
{
    public class RegisterDTO : MainDTO
    {
        public string Email { get; set; } 
        public string Username { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Password { get; set; }
    }
}
