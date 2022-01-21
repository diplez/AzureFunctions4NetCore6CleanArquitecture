using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Domain.Common.Dto.Response.MSContract
{    
    public class ContractResponse
    {
        public Guid Id { set; get; }

        public string Name { set; get; }
        
        public string Code { set; get; }
        
        public string PurchaseCommit { set; get; }
        
        public string BillingType { set; get; }
        
        public DateTime ContractInit { set; get; }
        
        public DateTime ContractEnd { set; get; }
        
        public string Contact { set; get; }
        
        public Guid ClientPartner { set; get; }
    }
}
