
using Bit.Subscription.Domain.Common.Dto.Request.MSMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bit.Subscription.Domain.Common.Enums.MonitorEnums;

namespace Bit.Subscription.Domain.Common.Interfaces.Services
{
    public interface IMSMonitorService
    {
        Task<Guid> RegisterActivity(ActivityRequest req);

        Task registerLogInformation(string message, string data = "", string resourceName = "", OPERATION_ENUM operation = OPERATION_ENUM.LOGS, Guid resourceId = new Guid());

        Task registerErrorInformation(string error, string data = "", string resourceName = "", OPERATION_ENUM operation = OPERATION_ENUM.LOGS, Guid resourceId = new Guid());
    }
}
