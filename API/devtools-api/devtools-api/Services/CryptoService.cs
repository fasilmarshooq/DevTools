using System;
using System.IO;
using System.Security.Cryptography;


namespace devtools_api.Services
{
    public static class CryptoService
    {
        public static byte[] Encrypt(byte[] content)
        {
            byte[] encryptedContent;
            using (var aesCrypto = new AesCryptoServiceProvider())
            {
                var rsa = GetCryptoServiceProviderForEncryption();

                var transform = aesCrypto.CreateEncryptor();

             
                var keyEncrypted = rsa.Encrypt(aesCrypto.Key, false);

                var LenK = new byte[4];
                var LenIV = new byte[4];

                var lKey = keyEncrypted.Length;
                LenK = BitConverter.GetBytes(lKey);
                var lIV = aesCrypto.IV.Length;
                LenIV = BitConverter.GetBytes(lIV);

                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(LenK, 0, 4);
                    memoryStream.Write(LenIV, 0, 4);
                    memoryStream.Write(keyEncrypted, 0, lKey);
                    memoryStream.Write(aesCrypto.IV, 0, lIV);

                    using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {

                        var blockSizeBytes = aesCrypto.BlockSize / 8;
                        var data = new byte[blockSizeBytes];

                        using (var contentStream = new MemoryStream(content))
                        {
                            int count;
                            do
                            {
                                count = contentStream.Read(data, 0, blockSizeBytes);
                                cryptoStream.Write(data, 0, count);
                            }
                            while (count > 0);
                        }

                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }
                    encryptedContent = memoryStream.ToArray();
                    memoryStream.Close();
                }
            }
            return encryptedContent;
        }

        public static byte[] Decrypt(byte[] encryptedContent)
        {
            byte[] decryptedContent;
            using (var aesCryptoProvider = new AesCryptoServiceProvider())
            {
                var rsa = GetCryptoServiceProviderForDecryption();

                var LenK = new byte[4];
                var LenIV = new byte[4];

                using (var encryptedStream = new MemoryStream(encryptedContent))
                {
                    encryptedStream.Seek(0, SeekOrigin.Begin);
                    encryptedStream.Seek(0, SeekOrigin.Begin);
                    encryptedStream.Read(LenK, 0, 3);
                    encryptedStream.Seek(4, SeekOrigin.Begin);
                    encryptedStream.Read(LenIV, 0, 3);

                    var lenK = BitConverter.ToInt32(LenK, 0);
                    var lenIV = BitConverter.ToInt32(LenIV, 0);

                    var startC = lenK + lenIV + 8;

                    var keyEncrypted = new byte[lenK];
                    var IV = new byte[lenIV];

                    encryptedStream.Seek(8, SeekOrigin.Begin);
                    encryptedStream.Read(keyEncrypted, 0, lenK);
                    encryptedStream.Seek(8 + lenK, SeekOrigin.Begin);
                    encryptedStream.Read(IV, 0, lenIV);


                    var keyDecrypted = rsa.Decrypt(keyEncrypted, false);


                    var transform = aesCryptoProvider.CreateDecryptor(keyDecrypted, IV);


                    using (var memoryStream = new MemoryStream())
                    {

                        var blockSizeBytes = aesCryptoProvider.BlockSize / 8;
                        var data = new byte[blockSizeBytes];

                        encryptedStream.Seek(startC, SeekOrigin.Begin);
                        using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                        {
                            int count;
                            do
                            {
                                count = encryptedStream.Read(data, 0, blockSizeBytes);
                                cryptoStream.Write(data, 0, count);
                            }
                            while (count > 0);

                            cryptoStream.FlushFinalBlock();
                            cryptoStream.Close();
                        }
                        decryptedContent = memoryStream.ToArray();
                        memoryStream.Close();
                    }
                }
            }

            return decryptedContent;
        }

        private static string GetKey()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CryptoKey.txt");
            var key = File.ReadAllText(path);
            return key;
        }


        private static RSACryptoServiceProvider GetCryptoServiceProviderForEncryption()
        {
            return GetCryptoServiceProvider(GetKey(), "Invalid Crypto Public Key For File Encryption");
        }

        private static RSACryptoServiceProvider GetCryptoServiceProviderForDecryption()
        {
            return GetCryptoServiceProvider(GetKey(), "Invalid Crypto Key For File Decryption");
        }

        private static RSACryptoServiceProvider GetCryptoServiceProvider(string key, string errorMessageIfInvalid)
        {
            if (key == null)
                throw new Exception(errorMessageIfInvalid);

            var rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(key);

            return rsa;
        }
    }
}