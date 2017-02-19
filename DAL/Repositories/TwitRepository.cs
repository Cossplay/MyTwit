using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public class TwitRepository : ITwitRepository
    {
        private static string CONNECTION_STRING = @"Server=127.0.0.1;User Id = root; Password ='';Database = MyTwit";
        public void Create(Twit twit)
        {
            throw new NotImplementedException();
        }

        public Twit Get(object twitId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Twit> GetAll()
        {
            var all = new List<Twit>();
            Twit curTwit = null;
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM twits", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    curTwit = new Twit()
                    {
                        TwitId = reader.GetInt32(reader.GetOrdinal("TwitId")),
                        Username = reader.GetString(reader.GetOrdinal("Username")),
                        Likes = reader.GetInt32(reader.GetOrdinal("Likes")),
                        TwitText = reader.GetString(reader.GetOrdinal("TwitText")),
                        TwitTime = (DateTime)reader.GetMySqlDateTime(reader.GetOrdinal("TwitTime"))
                    };
                    all.Add(curTwit);
                }
            }
            return all;
        }

        public void Like(int twitId, int cntLikes)
        {
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE twits SET LIKES = {++cntLikes} WHERE TwitId = {twitId}", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void Unlike(int twitId, int cntLikes)
        {
            using (var conn = new MySqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE twits SET LIKES = {--cntLikes} WHERE TwitId = '{twitId}'", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
