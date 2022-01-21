using Bit.Subscription.Domain.Common.Dto.Response.MSContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Interfaces.Services
{
    public interface IMSContractService
    {
        Task<ContractResponse> GetContractByID(Guid id);

        Task<IEnumerable<ContractResponse>> GetContractsByClientPartnerId(Guid Id);

        Task<IEnumerable<ContractResponse>> GetAllContractsByClientId(Guid Id);
    }
}
