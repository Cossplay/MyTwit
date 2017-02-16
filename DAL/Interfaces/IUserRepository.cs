
using DAL.Interfaces;
using MyTwit.DAL.Entities;

namespace MyTwit.DAL.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
       // User GetUser(string username);
    }
}
