using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Domain.Common.Dto.Response.MSClient
{
    public class ClientPartnerResponse
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Domain { set; get; }

        public Guid TenandId { set; get; }

        public Guid PartnerId { set; get; }

        public Guid ClientId { set; get; }
    }
}
