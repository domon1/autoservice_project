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
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext _context;

        public EFUserRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public int GetCustomerId(User user)
        {
            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    return _context.Customers.FirstOrDefault(x => x.UserId == user.UserId).CustomerId;
                }
                else
                {
                    return _context.Staffs.FirstOrDefault(x => x.UserId == user.UserId).StaffId;
                }
            }

            return 0;
        }
    }
}
