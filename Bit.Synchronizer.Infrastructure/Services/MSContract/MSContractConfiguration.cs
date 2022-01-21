using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSContract
{
    public class MSContractConfiguration
    {
        public const string MSContract = "MSContract";

        public string URLBase { get; set; }

        public string Token { get; set; }
    }
}
