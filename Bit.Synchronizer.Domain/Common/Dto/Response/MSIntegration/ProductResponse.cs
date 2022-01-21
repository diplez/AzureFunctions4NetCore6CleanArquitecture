using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Dto.Response.MSIntegration
{
    public class ProductResponse
    {
        [JsonProperty(PropertyName = nameof(Id))]
        public string Id { set; get; }

        [JsonProperty(PropertyName = nameof(Title))]
        public string Title { set; get; }

        [JsonProperty(PropertyName = nameof(Description))]
        public string Description { set; get; }

        [JsonProperty(PropertyName = nameof(IsMicrosoftProduct))]
        public bool IsMicrosoftProduct { set; get; }

        [JsonProperty(PropertyName = nameof(PublishName))]
        public string PublishName { set; get; }

        [JsonProperty(PropertyName = nameof(ProductType))]
        public ProductTypePR? ProductType { set; get; }
    }

    public class ProductTypePR
    {

        [JsonProperty(PropertyName = nameof(Id))]
        public string Id { set; get; }

        [JsonProperty(PropertyName = nameof(DisplayName))]
        public string DisplayName { set; get; }

        [JsonProperty(PropertyName = nameof(Subtype))]
        public SubtypePR? Subtype { set; get; }
    }

    public class SubtypePR
    {

        [JsonProperty(PropertyName = nameof(Id))]
        public string Id { set; get; }

        [JsonProperty(PropertyName = nameof(DisplayName))]
        public string DisplayName { set; get; }
    }
}
