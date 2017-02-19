
using System;
using MySql.Data.MySqlClient;
using MyTwit.DAL.Entities;
using MyTwit.DAL.Interfaces;
using DAL.Repositories;

namespace MyTwit.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static string CONNECTION_STRING = @"Server=127.0.0.1;User Id = root; Password ='';Database = MyTwit";
        public User Get(object username)
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
        public void Create(User user)
        {
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                new MySqlCommand($"INSERT INTO users (username, password) VALUES ('{user.Login}', '{user.Password}')", conn).ExecuteNonQuery();
            }
        }

    }
}