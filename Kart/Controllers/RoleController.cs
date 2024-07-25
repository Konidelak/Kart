using Kart.Dal;
using Kart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kart.Controllers
{
    public class RoleController : Controller
    {
        private readonly KartDbContext _cartDbContext;

        public RoleController(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        public IActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_cartDbContext);
            var roles = roleRepo.GetRoles();

            return View(roles);
        }
        public IActionResult Create()
        {
            Role role = new Role();
            return View(role);
        }
        [HttpPost]
        public IActionResult Create(Role role)
        {
            RoleRepo roleRepo = new RoleRepo(_cartDbContext);
            roleRepo.AddRole(role);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {

            RoleRepo roleRepo = new RoleRepo(_cartDbContext);
            var data = roleRepo.GetRolesById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id, Role role)
        {
            RoleRepo roleRepo = new RoleRepo(_cartDbContext);
            roleRepo.EditRole(id, role);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Role role)
        {
            RoleRepo roleRepo = new RoleRepo(_cartDbContext);
            roleRepo.DeleteRole(role);
            return RedirectToAction("Index");
        }
    }
}
