using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.MSClient
{
    public class ClientResponse
    {        
        public Guid Id { set; get; }
        
        public string FirstName { set; get; }
        
        public string LastName { set; get; }
        
        public string UserName { set; get; }

        public string Email { set; get; }
        
        public string Description { set; get; }
    }
}
