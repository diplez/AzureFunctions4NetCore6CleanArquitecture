using Bit.Synchronizer.Domain.Common.Interfaces.Querys;

namespace Bit.Synchronizer.Domain.Common.QuerysMapper
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
