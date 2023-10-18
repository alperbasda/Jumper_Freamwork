using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Domain.Configurations
{
    public class IdentityApiConfiguration
    {
        public string BaseAddress { get; set; }

        public string GetTokenAddress { get; set; }

        public string RefreshTokenAddress { get; set; }

        public string RevokeTokenAddress { get; set; }
    }
}
