using Kart.BAl;
using Kart.Models.VM;
using Kart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kart.Controllers
{
    public class UserController : Controller
    {
        private readonly KartDbContext _cartDbContext;
        public UserController(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;

        }
        public IActionResult Register()
        {
            UserVM vm = new UserVM();
            return View("SignUp", vm);
        }
        [HttpPost]
        public IActionResult UserRegister(UserVM vm)
        {
            if (ModelState.IsValid)
            {
                UserBal userBAL = new UserBal(_cartDbContext);
                if (userBAL.insertUser(vm))
                {
                    return RedirectToAction("Index", "Cart");
                }
            }
            return View("SignUp");

        }
        public IActionResult Login()
        {
            LginvM loginVM = new LginvM();
            return View(loginVM);
        }
        [HttpPost]
        public IActionResult Login(LginvM login)
        {
            if (ModelState.IsValid)
            {
                UserBal userBAL = new UserBal(_cartDbContext);
                var data = userBAL.GetUser(login.UserName, login.Password);
                if (data != null && data.RoleId == 3)
                {
                    return RedirectToAction("Index", "Role");
                }
                else if (data != null && data.RoleId > 3)
                {
                    return RedirectToAction("Index", "Cart");

                }
                else
                {
                    ViewBag.Message = "Invalid Credentials";
                }
                return View();

            }
            return View();
        }
    }
}
