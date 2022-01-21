using Bit.Client.Domain.Common.Dto.Response;
using Bit.Client.Domain.Common.Dto.Response.Generic;
using Bit.Client.Domain.Common.QuerysMapper;
using Bit.Contract.Domain.Common.Dto.Response;
using Bit.Contract.Domain.Common.Dto.Response.MSClient;
using Bit.Contract.Domain.Common.Interfaces.Repositories;
using Bit.Contract.Domain.Common.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Client.Tests.RepositoriesTest
{
    public static class MSClientServicesTest
    {

        public static Mock<IMSClientService> GetByClientPartnerId()
        {
            var crmClientsPartner = new ClientPartnerResponse {
                Id= "aba32978-5c7b-422b-894e-8967c8dd118f",
                ClientId = Guid.NewGuid(),
                Domain = "Domainn",
                Name ="Partner Test",
                PartnerId = Guid.NewGuid(),
                TenandId = Guid.NewGuid()
            };            

            var mock = new Mock<IMSClientService>();

            mock.Setup(r => r.GetClientPartnerById(It.IsAny<Guid>())).ReturnsAsync(crmClientsPartner);

            return mock;
        }
    }
}
