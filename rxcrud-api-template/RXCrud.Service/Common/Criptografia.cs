using RXCrud.Domain.Exception;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RXCrud.Service.Common
{
    public static class Criptografia
    {
        private static string _stringKey = "9dec7339f2de4d61";

        public static string DecryptStringAES(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new RXCrudException("Não foi informado um valor valido para o campo texto.");
            }

            var iv = Encoding.UTF8.GetBytes(_stringKey);
            var encrypted = Convert.FromBase64String(text);
            var keybytes = Encoding.UTF8.GetBytes(_stringKey);
            var decripted = DecryptStringFromBytes(encrypted, keybytes, iv);

            return decripted;
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            string plaintext = null;

            using (var aes = Aes.Create("AesManaged"))
            {
                aes.IV = iv;
                aes.Key = key;
                aes.FeedbackSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string EncryptStringAES(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new RXCrudException("Não foi informado um valor valido para o campo texto.");
            }

            var iv = Encoding.UTF8.GetBytes(_stringKey);
            var keybytes = Encoding.UTF8.GetBytes(_stringKey);
            var encryoFromJavascript = EncryptStringToBytes(text, keybytes, iv);

            return Convert.ToBase64String(encryoFromJavascript);
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted;

            using (var aes = Aes.Create("AesManaged"))
            {
                aes.IV = iv;
                aes.Key = key;
                aes.FeedbackSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}