using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Request.MSMonitor
{
    public class ActivityRequest
    {
        public string ResourceName { set; get; }

        public string Operation { set; get; }

        public string Type { set; get; }

        public string Data { set; get; }

        public string Message { set; get; }

        public string Error { set; get; }

        public string Description { set; get; }

        public Guid ResourceID { set; get; }
    }
}
