using Kart.BAl;
using Kart.Dal;
using Kart.Models.VM;
using Kart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly KartDbContext _cartDbContext;
        public CategoryController(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public IActionResult Index()
        {
            List<CategoryVm> list = new List<CategoryVm>();
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            var data = categoryRepo.GetCategories();
            foreach (var i in data)
            {
                list.Add(new CategoryVm { Id = i.Id, Name = i.Name, Description = i.Description });
            }
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVm categoryVM)
        {
            if (ModelState.IsValid)
            {
                CategoryBal categoryBAL = new CategoryBal(_cartDbContext);
                if (categoryBAL.insertCategory(categoryVM))
                {
                    return RedirectToAction("Index");

                }
            }
            return View();


        }
        public IActionResult Edit(int id)
        {
            CategoryVm categoryVM = new CategoryVm();
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            var data = categoryRepo.GetCategoryById(id);
            if (data != null)
            {
                categoryVM.Id = data.Id;
                categoryVM.Name = data.Name;
                categoryVM.Description = data.Description;
            }
            return View(categoryVM);
        }
        [HttpPost]
        public IActionResult Edit(int id, CategoryVm categoryVM)
        {
            if (ModelState.IsValid)
            {
                CategoryBal category = new CategoryBal(_cartDbContext);
                if (category.updateCategory(id, categoryVM))
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        public IActionResult Delete(Category category)
        {
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            if (categoryRepo.DeleteCategory(category))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
