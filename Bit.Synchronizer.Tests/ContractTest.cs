using Bit.Client.Domain.Common.Dto.Response.Generic;
using Bit.Client.Tests.RepositoriesTest;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Linq;
using AutoMapper;
using Bit.Client.Domain.Common.Dto;
using Bit.Contract.Domain.Common.Interfaces.Repositories;
using Bit.Contract.Application.Contract.Handlers;
using Bit.Contract.Domain.Common.Interfaces.Services;
using Bit.Contract.Domain.Common.Dto.Response.MSClient;
using System;
using Bit.Contract.Application.Contract.Querys;
using Bit.Contract.Domain.Common.Dto.Response;
using Bit.Contract.Tests.Repositories;
using Bit.Contract.Domain.Common.Entities;
using Bit.Contract.Application.Contract.Commands;
using Bit.Contract.Domain.Common.Dto;
using Bit.Contract.Domain.Utils;
using Bit.Contract.Application.Catalogs.Handlers;
using Bit.Contract.Application.Catalogs.Querys;
using System.Collections.Generic;

namespace Bit.Client.Test
{
    public class ContractTest
    {
        private Mock<IContractRepository> _mockContractRepository;
        private Mock<IMSClientService> _mockClientService;
        private Mock<IMSMonitorService> _mockMonitorService;
        private Mock<IPurchaseCommitRepository> _mockPurchaseCommitService;
        private Mock<IBillingTypeRepository> _mockBillingTypeService;
        private IMapper _mockMapper;

        public ContractTest()
        {
        }

        /// <summary>
        /// Hanlder para consultar datos de contrato segun el cliente partner
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllContractsByClientPartnerTest()
        {
            _mockContractRepository = ContractRepositoriesTest.GetContractByClientPartnerIDService();
            _mockClientService = MSClientServicesTest.GetByClientPartnerId();
            _mockMonitorService = new Mock<IMSMonitorService>();

            var resultsData = 1;

            var handler = new GetContractsByClientHandler(_mockContractRepository.Object, _mockClientService.Object, _mockMonitorService.Object);

            var result = await handler.Handle(new GetContractsByClientQuery() { ClientPartner = new Guid("aba32978-5c7b-422b-894e-8967c8dd118f"), Page = 1, Results = 10 }, CancellationToken.None);

            result.ShouldBeOfType<PagedResult<ContractClientResponse>>();
            result.Items.Count().ShouldBe(resultsData);
        }

        [Fact]
        public async Task CreateContractTest()
        {
            _mockContractRepository = ContractRepositoriesTest.CreateContractService();
            _mockClientService = MSClientServicesTest.GetByClientPartnerId();
            _mockMonitorService = new Mock<IMSMonitorService>();
            _mockPurchaseCommitService = PurchaseCommitRepositoryTest.getByIDRepository();
            _mockBillingTypeService = BillingTypeRepositoryTest.getByIDRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<ContractDto, Contracts>()
                .ReverseMap();
            });

            _mockMapper = mapperConfig.CreateMapper();

            var handler = new CreateContractHandler(
                _mockContractRepository.Object,
                _mockClientService.Object,
                _mockMonitorService.Object,
                _mockBillingTypeService.Object,
                _mockPurchaseCommitService.Object, _mockMapper);

            var contractComand = new CreateContractCommand()
            {
                Code = GeneratorRandoms.GeneratedCode(),
                BillingType = "MONTHLY",
                PurchaseCommit = "MONTHLYasa",
                ClientPartner = new Guid("aba32978-5c7b-422b-894e-8967c8dd118f"),
                Contact = "Alejandra Celi",
                ContractEnd = DateTime.UtcNow,
                ContractInit = DateTime.UtcNow,
                Name = "Contract Test"
            };

            var result = await handler.Handle(contractComand, CancellationToken.None);

            result.ShouldBeOfType<Guid>();
            result.ShouldBeEquivalentTo(new Guid("190779ec-4428-4467-94ff-fc590c1d5881"));
            Assert.Equal(result, new Guid("190779ec-4428-4467-94ff-fc590c1d5881"));
        }

        /// <summary>
        /// Hanlder para consultar datos de contrato segun el identificador
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetContractByIDTest()
        {
            _mockContractRepository = ContractRepositoriesTest.getByIDContractService();
            _mockMonitorService = new Mock<IMSMonitorService>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<ContractResponse, Contracts>()
                .ReverseMap();
            });

            _mockMapper = mapperConfig.CreateMapper();

            var handler = new GetContractByIdHandler(_mockContractRepository.Object, _mockMonitorService.Object, _mockMapper);

            var result = await handler.Handle(new GetContractByIdQuery() { Id = new Guid("86d9f1e5-9e1f-440f-b53c-2605599cb1d6") }, CancellationToken.None);

            result.ShouldBeOfType<ContractResponse>();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetCatalogsByType() {

            _mockPurchaseCommitService = PurchaseCommitRepositoryTest.getAllRepository();
            _mockBillingTypeService = BillingTypeRepositoryTest.getAllRepository();

            var handler = new GetCatalogByTypeHandler(_mockBillingTypeService.Object, _mockPurchaseCommitService.Object);

            var result = await handler.Handle(new GetCatalogByTypeQuery() { TypeCatalog = Contract.Domain.Common.Enums.TypeCatalogContract.TYPE_CATALOGS.BILLING_TYPE }, CancellationToken.None);

            result.ShouldBeOfType<List<CatalogResponse>>();
            result.Count().ShouldBe(2);
        }
    }
}
