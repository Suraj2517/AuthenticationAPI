using AuthAPI.Models;

namespace AuthAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        public User Login(User user)
        {
            return db.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
        }

        public int Register(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }
    }

}
