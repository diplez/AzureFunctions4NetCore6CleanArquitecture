using Bit.Subscription.Domain.Common.Interfaces.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Client.Domain.Common.QuerysMapper
{
    public class PagedQuery : IPagedQuery
    {
        public int Page { set; get; }

        public int Results { set; get; }

        public string OrderBy { set; get; }

        public string SortOrder { set; get; }

        public string Filter { set; get; }
    }
}
