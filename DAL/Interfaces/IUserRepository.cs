
using MyTwit.DAL.Entities;

namespace MyTwit.DAL.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SignUp(string username, string pass);
    }
}
