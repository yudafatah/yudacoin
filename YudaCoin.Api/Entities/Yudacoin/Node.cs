using MongoDB.Bson.Serialization.Attributes;

namespace YudaCoin.Api.Entities.Yudacoin
{
    public class Node
    {
        [BsonId]
        public string Id { get; set; }
        public string Address { get; set; }
    }
}
