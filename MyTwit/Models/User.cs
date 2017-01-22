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
    }
}