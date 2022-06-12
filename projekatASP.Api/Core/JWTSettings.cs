using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatASP.Api.Core
{
    public class JWTSettings
    {
        public int Minutes { get; set; }
        public string User { get; set; }
        public string SecretKey { get; set; }
    }
}
