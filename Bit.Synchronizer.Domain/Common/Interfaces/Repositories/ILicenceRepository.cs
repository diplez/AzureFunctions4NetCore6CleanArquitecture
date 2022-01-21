using Bit.Client.Domain.Common.QuerysMapper;
using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Subscription.Domain.Common.Dto;
using Bit.Subscription.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Interfaces.Repositories
{
    public interface ILicenceRepository 
    {
        Task<Licence> GetByIdAsync(Guid Id);

        Task<PagedResult<LicenceDto>> GetByAllAsync(PagedQuery query);

        Task<bool> syncronizedAll(IEnumerable<Licence> list);

        Task<bool> syncronizedOne(Licence licence);
    }
}
