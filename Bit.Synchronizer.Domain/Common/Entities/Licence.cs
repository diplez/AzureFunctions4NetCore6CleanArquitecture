using Bit.Domain.Common.Entities.Auditables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Entities
{
    public class Licence : BaseEntity
    {
        public string Name { set; get; }

        public string FriendyName { set; get; }        

        public string TermDuration { set; get; }

        public double Cost { set; get; }

        public int MinimumQuantity { set; get; }

        public int MaximumQuantity { set; get; }

        public bool IsTrial { set; get; }

        public string ProductId { set; get; }

        public List<string> SupportedBillingCycles { set; get; }

        public string BillingType { set; get; }

        public bool IsAutoRenewable { set; get; }

        public string CatalogName { set; get; }

        public string CatalogItemId { set; get; }
      
        public string SkuId { set; get; }
        
        public string SkuDescription { set; get; }
        
        public string ProductDescription { set; get; }

    }
}
