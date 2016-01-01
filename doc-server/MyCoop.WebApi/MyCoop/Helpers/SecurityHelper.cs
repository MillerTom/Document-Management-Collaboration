using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MyCoop.Configuration;

namespace MyCoop.Helpers
{
    public class SecurityHelper
    {
        private static readonly byte[] Key;

        private static readonly byte[] IV;

        private static readonly string Salt;

        static SecurityHelper()
        {
            var cryptography = (CryptographySection)ConfigurationManager.GetSection("cryptography");
            Salt = cryptography.Salt;

            var salt = new UTF8Encoding(false).GetBytes(Salt);
            var key = new Rfc2898DeriveBytes(cryptography.Key, salt);
            var iv = new Rfc2898DeriveBytes(cryptography.IV, salt);

            Key = key.GetBytes(32);
            IV = iv.GetBytes(16);
        }

        public static string CreateRandomPassword(int length)
        {
            const string passwordChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?()[]";
            var chars = new char[length];
            var rd = new Random();

            for (int i = 0; i < length; i++)
            {
                chars[i] = passwordChars[rd.Next(0, passwordChars.Length)];
            }

            return new String(chars);
        }

        public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var algorithm = Aes.Create())
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
            {
                return Crypt(data, encryptor);
            }
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var algorithm = Aes.Create())
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
            {
                return Crypt(data, decryptor);
            }
        }

        private static byte[] Crypt(byte[] data, ICryptoTransform cryptor)
        {
            var m = new MemoryStream();
            using (Stream c = new CryptoStream(m, cryptor, CryptoStreamMode.Write))
            {
                c.Write(data, 0, data.Length);
            }
            return m.ToArray();
        }

        public static string Encrypt(string data, byte[] key, byte[] iv)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), key, iv));
        }

        public static string Decrypt(string data, byte[] key, byte[] iv)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(data), key, iv));
        }

        public static string Encrypt(string data)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), Key, IV));
        }

        public static string Decrypt(string data)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(data), Key, IV));
        }

        public static string GetHash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(String.Concat(input, Salt)));

                var sBuilder = new StringBuilder();

                foreach (byte b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static bool VerifyHash(string input, string hash)
        {
            var hashOfInput = GetHash(String.Concat(input, Salt));

            var comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }

            return false;
        }

    }
}