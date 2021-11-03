using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YudaCoin.Api.Entities.Yudacoin
{
    public class Transaction
    {
        [BsonId]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Amount { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public string Signature { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Fees { get; set; }

        public override string ToString()
        {
            return Amount.ToString("0.00000000") + Recipient + Sender;
        }
    }
}
