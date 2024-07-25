using Kart.Models;

namespace Kart.Dal
{
    public class RoleRepo
    {
        private readonly KartDbContext _cartDbContext;
        public RoleRepo(KartDbContext cartDbContext)
        {

            _cartDbContext = cartDbContext;
        }
        public List<Role> GetRoles()
        {
            var roles = _cartDbContext.Roles.ToList();
            return roles;
        }
        public Role? GetRolesById(int id)
        {
            var role = _cartDbContext.Roles.FirstOrDefault(r => r.Id == id);
            return role;
        }
        public bool AddRole(Role role)
        {
            try
            {
                _cartDbContext.Roles.Add(role);
                _cartDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditRole(int id, Role role)
        {

            var data = _cartDbContext.Roles.Find(id);
            if (data != null)
            {
                data.Name = role.Name;
                _cartDbContext.SaveChanges();
            }
            return true;

        }
        public bool DeleteRole(Role role)
        {


            _cartDbContext.Roles.Remove(role);
            _cartDbContext.SaveChanges();
            return true;

        }
    }
}
