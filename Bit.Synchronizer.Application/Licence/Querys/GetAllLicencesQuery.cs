using Bit.Domain.Common.Dto.Response.Generic;
using Bit.Synchronizer.Domain.Common.Interfaces.Querys;
using Bit.Synchronizer.Domain.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Application.Licence.Querys
{
    public class GetAllLicencesQuery : IRequest<PagedResult<LicenceDto>>, IPagedQuery
    {
        public int Page { set; get; }

        public int Results { set; get; } = 10;

        public string OrderBy { set; get; }

        public string SortOrder { set; get; }

        public string Filter { set; get; }
    }
}
