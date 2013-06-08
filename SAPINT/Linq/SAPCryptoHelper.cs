namespace SAPINT.Linq
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class SAPCryptoHelper
    {
        public static string Decrypt(string text, string password)
        {
            byte[] buffer = Convert.FromBase64String(text.Replace("!", "=").TrimStart("###".ToCharArray()));
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return Encoding.UTF8.GetString(Decrypt(buffer, bytes.GetBytes(0x20), bytes.GetBytes(0x10)));
        }

        private static byte[] Decrypt(byte[] bytes, byte[] key, byte[] iV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = key;
            rijndael.IV = iV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public static string Encrypt(string text, string password)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 110, 0x20, 0x4d, 0x65, 100, 0x76, 0x65, 100, 0x65, 0x76 });
            return ("###" + Convert.ToBase64String(Encrypt(buffer, bytes.GetBytes(0x20), bytes.GetBytes(0x10))).Replace("=", "!"));
        }

        private static byte[] Encrypt(byte[] bytes, byte[] key, byte[] iV)
        {
            MemoryStream stream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = key;
            rijndael.IV = iV;
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.Close();
            return stream.ToArray();
        }
    }
}

