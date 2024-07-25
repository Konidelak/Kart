using Kart.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Kart.Controllers
{
    public class KartController : Controller
    {
        public IActionResult Index()
        {
            UserVM vm = new UserVM();
            ViewData["User"] = vm.FirstName + " " + vm.LastName;
            return View();
        }
    }
}
