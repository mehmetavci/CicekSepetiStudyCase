using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CicekSepetiStudyCase.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int UnitInStock { get; set; }
    }
}
