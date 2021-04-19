using System;
using System.Security.Cryptography;
using System.Text;

namespace ABB.Core.Helper
{
    public class Sifreleyici
    {
        public static string EncryptSHA1(string data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }
        public static bool CheckSha1(string data, string hashedData)
        {
            return hashedData.Equals(EncryptSHA1(data));
        }
    }
}