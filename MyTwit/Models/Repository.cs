using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MyTwit.Models
{
    public class Repository
    {
        private static string CONNECTION_STRING = @"Server=127.0.0.1;User Id = root; Password ='';Database = MyTwit";

        public User GetUser(string username)
        {
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM users WHERE username = '{username}'", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User {Login = reader.GetString(0), Password = reader.GetString(1)};
                }
                return null;
            }
        } 
    }
}