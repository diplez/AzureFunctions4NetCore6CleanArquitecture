using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Synchronizer.Domain.Common.Dto;
using Bit.Synchronizer.Domain.Common.Entities;
using Bit.Synchronizer.Domain.Common.QuerysMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Domain.Common.Interfaces.Repositories
{
    public interface ILicenceRepository 
    {
        Task<Licence> GetByIdAsync(Guid Id);

        Task<PagedResult<LicenceDto>> GetByAllAsync(PagedQuery query);

        Task<bool> syncronizedAll(IEnumerable<Licence> list);

        Task<bool> syncronizedOne(Licence licence);
    }
}
