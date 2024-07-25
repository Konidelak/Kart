using Kart.Models;

namespace Kart.Dal
{
    public class UserRepo
    {
        private readonly KartDbContext _cartDbContext;
        public UserRepo(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public bool addUser(User user)
        {
            user.RoleId = 3;
            _cartDbContext.Users.Add(user);
            _cartDbContext.SaveChanges();
            return true;
        }
        public User getUser(string email, string password)
        {
            User user = null;
            try
            {
                user = _cartDbContext.Users.FirstOrDefault(a => a.EmailId == email && a.Password == password);
                return user;
            }
            catch (Exception)
            {
                return user;
            }
        }
    }
}
