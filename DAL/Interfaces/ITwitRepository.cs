using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITwitRepository : IRepository<Twit>
    {
        IEnumerable<Twit> GetAll();
        void Like(int twitId, int cntLikes);
        void Unlike(int twitId, int cntLikes);
    }
}
