using NBitcoin;

namespace Yc.RSA
{
    public static class RSA
    {
        public static Wallet GenerateKey()
        {
            Key privateKey = new();

            var pAddress = privateKey.GetBitcoinSecret(Network.Main).GetAddress(ScriptPubKeyType.Segwit);
            var address = BitcoinAddress.Create(pAddress.ToString(), Network.Main);

            return new Wallet { PublicKey = pAddress.ToString(), PrivateKey = privateKey.GetBitcoinSecret(Network.Main).ToString() };
        }

        public static string Sign(string privateKey, string msgToSign)
        {
            var secret = Network.Main.CreateBitcoinSecret(privateKey);
            var signature = secret.PrivateKey.SignMessage(msgToSign);

            var v = secret.PubKey.VerifyMessage(msgToSign, signature);

            return signature;
        }
// test
        public static bool Verify(string pubKey, string originalMsg, string signedMsg)
        {
            var address = BitcoinAddress.Create(pubKey, Network.Main);
            var pkh = (address as IPubkeyHashUsable);

            return pkh.VerifyMessage(originalMsg, signedMsg);
        }
    }
}
