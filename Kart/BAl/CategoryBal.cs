using Kart.Dal;
using Kart.Models.VM;
using Kart.Models;

namespace Kart.BAl
{
    public class CategoryBal
    {
        private readonly KartDbContext _cartDbContext;
        public CategoryBal(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public bool insertCategory(CategoryVm categoryVM)
        {
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            Category categoryn = new Category();
            categoryn.Name = categoryVM.Name;
            categoryn.Description = categoryVM.Description;
            if (categoryRepo.AddCategory(categoryn))
            {
                return true;
            }

            return false;
        }
        public bool updateCategory(int id, CategoryVm categoryVM)
        {
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            Category newCategory = new Category();
            newCategory.Name = categoryVM.Name;
            newCategory.Description = categoryVM.Description;
            if (categoryRepo.EditCategory(id, newCategory))
            {
                return true;
            }
            return false;
        }
        public bool deleteCategory(CategoryVm categoryVM)
        {
            Category categoryC = new Category();
            categoryC.Name = categoryVM.Name;
            categoryC.Description = categoryVM.Description;
            CategoryRepo categoryRepo = new CategoryRepo(_cartDbContext);
            if (categoryRepo.DeleteCategory(categoryC))
            {
                return true;
            }
            return false;

        }
    }
}
