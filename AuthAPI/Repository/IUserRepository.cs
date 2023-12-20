using AuthAPI.Models;

namespace AuthAPI.Repository
{
    public interface IUserRepository
    {
        User Login(User user);
        int Register(User user);

    }
}
