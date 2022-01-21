using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bit.Synchronizer.Domain.Common.Interfaces.Services;
using Bit.Synchronizer.Application.Licence.Querys;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;

namespace Bit.Synchronizer.Api.Workers
{
    public class FunctionClientWorker
    {
        private readonly IMediator Mediator;
        private readonly IMSMonitorService _mSMonitorService;

        private readonly IHttpClientFactory _httpClientFactory;
        private const string timer = "0 */5 * * * *"; //esta configurado para que sincronice cada 5 minutos, para configurar a las 2AM ser�a: "0 00 2 * * *", estructura {second} {minute} {hour} {day} {month} {day-of-week} 
        private const string url = "https://clientfunctionsmp.azurewebsites.net/api/client/syncronizedClientsAll";//API utilizada
        public FunctionClientWorker(IHttpClientFactory httpClientFactory, IMediator mediator, IMSMonitorService mSMonitorService)
        {
            _httpClientFactory = httpClientFactory;
            Mediator = mediator;
            _mSMonitorService = mSMonitorService;
        }

        [FunctionName("FuncionWorkerClient")]
        [OpenApiOperation(operationId: "Sincronizaci�n", tags: new[] { "Sincronizaci�n" }, Summary = "Sincronizaci�n", Description = "Sincronizaci�n Clients", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Sincronizaci�n", Description = "Sincronizaci�n Clients")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Invalid input", Description = "Invalid input")]

        public async Task Run(
             [TimerTrigger(timer)] TimerInfo myTimer,
              ILogger log
            )
        {
            if (myTimer.IsPastDue)
            {
                try
                {
                    log.LogInformation("C# HTTP FuncionWorkerClient function ha procesado una petici�n.");

                    //var httpClient = _httpClientFactory.CreateClient();
                    //var response = await httpClient.GetAsync(url);
                    //log.LogInformation($"Response worker service: {response.IsSuccessStatusCode}");
                }
                catch (Exception ex)
                {
                    log.LogInformation($"Manejo de errores:", ex);
                    throw ex;                    
                }

            }
            var data = await Mediator.Send(new GetAllLicencesQuery() { 
                Page = 1,
                Results = 10
            });
            Console.WriteLine(data.Items.FirstOrDefault().Name + " --");
            log.LogInformation($"C# Timer trigger function se ha ejecutado a la(s): {DateTime.Now}");
            await _mSMonitorService.registerLogInformation($"C# Timer trigger function se ha ejecutado a la(s): {DateTime.Now}", resourceName: "testDiego");

        }
    }
}
