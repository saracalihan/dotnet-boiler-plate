using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DapperExample.Services
{
    public static class AuthenticationService
    {
        static byte[] generateSalt() {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return bytes;
        }
        static string hashPassword(string password, byte[] salt)
        {
           byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[passwordBytes.Length + salt.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[passwordBytes.Length + i] = salt[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public static Object generateSaltAndPassword(string password)
        {
            byte[] salt = generateSalt();
            string hash = hashPassword(password, salt);
            return new { 
                hash,
                salt = Convert.ToBase64String(salt)
            };
        }
        public static bool authenticatePassword(string password, string hash, string salt)
        {
            string hashedPassword = "";
            if(hashedPassword != hash)
            {
                return false;
            }
            return true;

        }
    }
}
