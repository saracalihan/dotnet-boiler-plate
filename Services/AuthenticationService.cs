using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DapperExample.Models;

namespace DapperExample.Services
{
    public class HashAndSalt
    {
        public string hash {get;set;}
        public string salt {get;set; }
    
        public HashAndSalt(string hash, byte[] salt)
        {
            this.hash = hash;
            this.salt = Convert.ToBase64String(salt);
        }
        public HashAndSalt(string hash, string salt)
        {
            this.hash = hash;
            this.salt = salt;
        }
    }
    public class AuthenticationService
    {
        private HashAlgorithm algorithm = new SHA256Managed();
        
        byte[] generateSalt() {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return bytes;
        }
        string hashPassword(string password, byte[] salt)
        {
           byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

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

        public HashAndSalt generateSaltAndHash(string password)
        {

            byte[] salt = generateSalt();
            string hash = hashPassword(password, salt);
            return new HashAndSalt(hash, salt);
        }
        public bool authenticatePassword(string password, string hash, string salt)
        {
            //Decode salt and convert to byte
            byte[] data = Convert.FromBase64String(salt);
            string hashedPassword = hashPassword(password, data);
            if(hashedPassword != hash)
            {
                return false;
            }
            return true;

        }
    }
}
