using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using MySql.Data.MySqlClient;

namespace MyTwit.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string CreateMd5(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder();
                foreach (var b in data)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public bool VerifyMd5Hash(string input, string hash)
        {
            var hashOfinput = CreateMd5(input);
            return hashOfinput.Equals(hash);
        }

    }
}