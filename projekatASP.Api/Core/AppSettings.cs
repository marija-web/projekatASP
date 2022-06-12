using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.Core
{
    public class AppSettings
    {
        public JWTSettings JwtSettings { get; set; }
        public ForEmail ForEmail { get; set; }
    }
    public class ForEmail
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
