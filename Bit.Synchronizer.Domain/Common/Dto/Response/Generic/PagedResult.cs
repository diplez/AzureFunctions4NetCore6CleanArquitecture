using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit.Domain.Utils;

namespace Bit.Domain.Common.Dto.Response.Generic
{
    public class PagedResult <T>
    {
        [JsonProperty(PropertyName = "CurrentPage")]
        public int CurrentPage { get; }

        [JsonProperty(PropertyName = "ResultsPerPage")]
        public int ResultsPerPage { get; }

        [JsonProperty(PropertyName = "TotalPages")]
        public int TotalPages { get; }

        [JsonProperty(PropertyName = "TotalResults")]
        public long TotalResults { get; }

        [JsonProperty(PropertyName = "Items")]
        public IEnumerable<T> Items { set; get; }

        public PagedResult() { }

        public PagedResult(IEnumerable<T> result)
        {
            Items = result;
        }

        public PagedResult(IEnumerable<T> result, int currentPage, int resultPerPage, long totalResuls)
        {
            var pagiUtil = new PaginatorUtils();
            ResultsPerPage = resultPerPage;
            CurrentPage = currentPage;
            Items = result;
            TotalResults = totalResuls;
            TotalPages = pagiUtil.pageTotal((double)ResultsPerPage, (double)totalResuls);
        }
    }
}
