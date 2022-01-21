using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSMonitor
{
    public class MSMonitorConfiguration
    {
        public const string MSMonitor = "MSMonitor";

        public string URLBase { get; set; }

        public string Token { get; set; }
    }
}
