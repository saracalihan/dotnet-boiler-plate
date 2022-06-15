using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExample.Constants;
using DapperExample.Models;
using DapperExample.Repositories;

namespace DapperExample.Services
{
    public class TokenService
    {
        private SqlConnection connection;
        //public T generateToken<T>()
        //{
        //    IRepository repository = 
        //    // create token
        //    // write token
        //    //return token
        //    return 
        //}
        public TokenService()
        {
            connection = new SqlConnection("Data Source=LAPTOP-POJ47EP4\\SQLEXPRESS01;" + "Initial Catalog=basic;" + "User id=sa;" + "Password=123456;");
            connection.Open();
        }
        private string createToken()
        {
            int size = 30;
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            string value = result.ToString();
            return value;
        }
        public AccessToken generateAccessToken(int user_id)
        {
            // TODO: user_id userReposity üzerinden kontrol edilmeli

            double expireTime = 1;
            var count = connection.Execute(@"insert into access_tokens(user_id, value, status, expired_at) values( @user_id, @value, @status, @expired_at)", new { user_id, value = createToken(), status = TokenStatus.Active , expired_at = DateTime.Now});
            if (count != 1)
            {
                throw new Exception("Access token oluşturulamadı: ");
            }
            return new AccessToken();
        }
    }
}
