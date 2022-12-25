using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class EFRoleRepository : IRoleRepository
    {
        private EFDbContext _context;

        public EFRoleRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetUserRole()
        {
            return _context.Roles.FirstOrDefault(x => x.Name == "user");
        }
    }
}
