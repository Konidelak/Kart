using Kart.Models;

namespace Kart.Dal
{
    public class CategoryRepo
    {
        private readonly KartDbContext _cartDbContext;

        public CategoryRepo(KartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public List<Category> GetCategories()
        {
            var category = _cartDbContext.Categories.ToList();
            return category;
        }
        public Category? GetCategoryById(int id)
        {
            var cat = _cartDbContext.Categories.FirstOrDefault(c => c.Id == id);
            return cat;
        }
        public bool AddCategory(Category category)
        {
            try
            {
                _cartDbContext.Add(category);
                _cartDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditCategory(int id, Category category)
        {
            var data = _cartDbContext.Categories.Find(id);
            if (data != null)
            {
                data.Name = category.Name;
                data.Description = category.Description;
                _cartDbContext.SaveChanges();
            }
            return true;
        }
        public bool DeleteCategory(Category category)
        {
            _cartDbContext.Remove(category);
            _cartDbContext.SaveChanges();
            return true;
        }
    }
}
