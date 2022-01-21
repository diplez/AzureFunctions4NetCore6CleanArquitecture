using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Subscription.Domain.Common.Dto.Request.MSMonitor;
using Bit.Subscription.Domain.Common.Enums;
using Bit.Subscription.Domain.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Bit.Subscription.Domain.Common.Enums.MonitorEnums;

namespace Bit.Subscription.Infrastructure.Services.MSMonitor
{
    public class MSMonitorService : IMSMonitorService
    {
        public readonly MSMonitorConfiguration _configuration;

        public MSMonitorService(MSMonitorConfiguration configuration, IConfiguration global)
        {
            _configuration = new MSMonitorConfiguration() {
                URLBase = global.GetSection(MSMonitorConfiguration.MSMonitor)[nameof(MSMonitorConfiguration.URLBase)]                
            };
        }

        /// <summary>
        /// Registra actividad en monitoreo
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Guid> RegisterActivity(ActivityRequest req)
        {
            string baseUrl = $"{_configuration.URLBase}createActivity";
            RestClient client = new RestClient(baseUrl);

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(req);

            var response = await client.ExecuteAsync(request, Method.POST);

            if (!response.IsSuccessful)
            {
                throw new ApplicationException(response.ErrorMessage);
            }

            var result = JsonConvert.DeserializeObject<ResponseResultAJAX<Guid>>(response.Content);

            return result.Result;
        }

        public async Task registerErrorInformation(string error, string data = "", string resourceName = "", MonitorEnums.OPERATION_ENUM operation = MonitorEnums.OPERATION_ENUM.LOGS, Guid resourceId = default)
        {
            string projectName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            _ = await RegisterActivity(new ActivityRequest()
            {
                Error = error,
                Message = "",
                Data = data,
                ResourceName = resourceName,
                Description = $"{projectName}",
                Operation = operation.ToString(),
                Type = TYPE_LOG_ENUM.ERROR.ToString(),
                ResourceID = resourceId
            });
        }

        public async Task registerLogInformation(string message, string data = "", string resourceName = "", MonitorEnums.OPERATION_ENUM operation = MonitorEnums.OPERATION_ENUM.LOGS, Guid resourceId = default)
        {
            string projectName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            _ = await RegisterActivity(new ActivityRequest()
            {
                Error = "",
                Message = message,
                Data = data,
                ResourceName = resourceName,
                Description = $"{projectName}",
                Operation = operation.ToString(),
                Type = TYPE_LOG_ENUM.INFO.ToString(),
                ResourceID = resourceId
            });
        }
    }
}
