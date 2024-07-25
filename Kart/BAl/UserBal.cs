using Kart.Dal;
using Kart.Models.VM;
using Kart.Models;

namespace Kart.BAl
{
    public class UserBal
    {
        private readonly KartDbContext _cartDbContext;
        public UserBal(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public bool insertUser(UserVM userVM)
        {
            User user = new User();
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.EmailId = userVM.EmailId;
            user.Password = userVM.Password;
            user.Address = userVM.Address;
            UserRepo userRepo = new UserRepo(_cartDbContext);
            if (userRepo.addUser(user))
            {
                return true;
            }
            return false;
        }
        public User GetUser(string username, string password)
        {
            UserRepo userRepo = new UserRepo(_cartDbContext);
            return userRepo.getUser(username, password);
        }
    }
}
