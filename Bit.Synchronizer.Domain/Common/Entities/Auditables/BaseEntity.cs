using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Bit.Domain.Common.Entities.Auditables
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}