using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Domain.Common.Entities.Auditables
{
    public class BaseEntityAlternative
    {
        [BsonId]
        public string Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public BaseEntityAlternative()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
