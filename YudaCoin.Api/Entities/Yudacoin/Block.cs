using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace YudaCoin.Api.Entities.Yudacoin
{
    public class Block
    {
        [BsonId]
        public string Id { get; set; }
        public int Index { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Timestamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int Proof { get; set; }
        public string PreviousHash { get; set; }

        public override string ToString()
        {
            return $"{Index} [{Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] Proof: {Proof} | PrevHash: {PreviousHash}";
        }
    }
}
