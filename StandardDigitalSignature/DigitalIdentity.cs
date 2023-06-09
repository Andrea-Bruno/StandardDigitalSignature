using NBitcoin;
using SecureStorage;
using System;

namespace StandardDigitalSignature
{
    /// <summary>
    /// This class creates an anonymous digital identity and stores it securely. The digital identity is formed by a pair of cryptographic keys (public and private), and can be recovered with a passphrase which must be carefully guarded in a secure manner. This class uses the secure storage library to hold the password for digital identity recovery.
    /// The digital identity using the technology derived from bitcoin wallets is anonymous, it is based on the concept that the owner of the digital identity can demonstrate at any time that he is in possession of this identity by affixing a signature.
    /// It is possible to transform the anonymous digital identity into an authenticated identity, in which case the holder of the signature must undergo a KYC procedure, during which he will have to affix the digital signature in order to be able to demonstrate that he is in possession of the private key.
    /// The digital identity ID is formed from the public key, which by convention can be transcribed in base64 or hexadecimal format.
    /// For help and support you can ask here https://github.com/Andrea-Bruno/StandardDigitalSignature/issues
    /// </summary>
    static public class DigitalIdentity
    {
        static DigitalIdentity()
        {
            SecureStorage = new Storage(nameof(DigitalIdentity));
            var passphrase = Passphrase;
            Mnemonic mnemo;
            if (passphrase != null)
            {
                // Restore the pre-existing digital identity
                mnemo = new Mnemonic(passphrase, Wordlist.English);
            }
            else
            {
                // Generate a new digital identity
                mnemo = new Mnemonic(Wordlist.English);
                Passphrase = string.Join(" ", mnemo.Words);
            }
            var hdRoot = mnemo.DeriveExtKey();
            PrivateKey = hdRoot.PrivateKey;
            PublicKey = PrivateKey.PubKey;

        }
        static readonly Storage SecureStorage;
        /// <summary>
        /// The passphrase allows you to export and import your attention identity. Be careful, the theft of these words involves the theft of the digital identity!
        /// </summary>
        static public string Passphrase { get { return SecureStorage.Values.Get(nameof(Passphrase), null); } set { SecureStorage.Values.Set(nameof(Passphrase), string.Join(" ", value)); } } 
        static readonly Key PrivateKey;
        static readonly PubKey PublicKey;

        /// <summary>
        /// The digital identity ID in Base64 format. Which corresponds to the cryptographic public key created when the digital identity was generated.
        /// </summary>
        public static string DigitalId => Convert.ToBase64String(PublicKey.ToBytes());

        /// <summary>
        /// Digitally sign a document
        /// </summary>
        /// <param name="scopeOfSignature">Indicates the intention of the signer (the purpose for which the signature is placed on the document)</param>
        /// <param name="signatureFileName">Returns the name of the file containing the digital signature</param>
        /// <param name="fileName">The name of the file being signed</param>
        /// <param name="document">The file you are signing (in the form of binary data)</param>
        /// <returns>Digital signature in json format</returns>
        static public string SignDocument(DigitalSignature.Scope scopeOfSignature, out string signatureFileName, string fileName = null, byte[] document = null)
        {
            var sign = new DigitalSignature(PrivateKey.ToBytes(), scopeOfSignature, fileName, document);
            var json = sign.Save();
            signatureFileName = fileName + sign.FileExtension();
            return json;
        }
    }
}
