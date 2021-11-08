using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Yc.RSA;

namespace YudaCoin.Api.Entities.Yudacoin
{
    public class CryptoCurrency
    {
        private List<Transaction> currTrans = new List<Transaction>();
        private List<Block> chain = new List<Block>();
        private List<Node> nodes = new List<Node>();
        private Block lastBlock => chain.Last();

        public string NodeId { get; private set; }

        static int blockCount = 0;
        static int reward = 50;

        static string minerPrivKey = "";
        static Wallet minerWallet = Yc.RSA.RSA.GenerateKey();

        public CryptoCurrency()
        {
            minerPrivKey = minerWallet.PrivateKey;
            NodeId = minerWallet.PublicKey;

            // init trans
            var trx = new Transaction { Sender = "0x", Recipient = NodeId, Amount = 50, Fees = 0, Signature = "" };
            currTrans.Add(trx);

            CreateNewBlock(100, "1");
        }

        private Block CreateNewBlock(int proof, string prevHash = null)
        {
            var block = new Block
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Index = chain.Count,
                Timestamp = DateTime.Now,
                Transactions = currTrans.ToList(),
                Proof = proof,
                PreviousHash = prevHash ?? GetHash(chain.Last())
            };

            currTrans.Clear();
            chain.Add(block);
            return block;
        }

        private static string GetHash(Block block)
        {
            string strBlock = JsonConvert.SerializeObject(block);
            return GetSha256(strBlock);
        }

        private static string GetSha256(string data)
        {
            var sha256 = new SHA256Managed();
            var hashBuilder = new StringBuilder();

            byte[] bytes = Encoding.Unicode.GetBytes(data);

            foreach (var i in sha256.ComputeHash(bytes)) hashBuilder.AppendFormat("{0:x2}", i);

            return hashBuilder.ToString();
        }
    }
}
