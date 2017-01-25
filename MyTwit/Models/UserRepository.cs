
using MySql.Data.MySqlClient;
using MyTwit.Interfaces;

namespace MyTwit.Models
{
    public class UserRepository : IUserRepository
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
        public void SignUp(string username, string pass)
        {
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                new MySqlCommand($"INSERT INTO users (username, password) VALUES ('{username}', '{pass}')", conn).ExecuteNonQuery();
            }
        }
    }
}