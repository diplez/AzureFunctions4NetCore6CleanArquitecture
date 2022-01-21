﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.MSIntegration
{
    public class MSIntegrationConfiguration
    {
        public const string MSIntegration = "MSIntegration";

        public string URLBase { get; set; }

        public string Token { get; set; }
    }
}
