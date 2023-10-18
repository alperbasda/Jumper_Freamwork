using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Domain.Configurations
{
    public class JwtTokenOptions
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public string SecurityKey { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
