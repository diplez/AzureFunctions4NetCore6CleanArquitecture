using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSClient
{
    public class MSClientConfiguration
    {
        public const string MSClient = "MSClient";

        public string URLBase { get; set; }

        public string Token { get; set; }
    }
}
