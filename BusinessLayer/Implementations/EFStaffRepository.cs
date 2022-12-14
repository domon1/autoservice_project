using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class EFStaffRepository : IStaffRepository
    {
        private EFDbContext _context;

        public EFStaffRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(Staff item)
        {
            _context.Staffs.Add(item);
        }

        public void Delete(int id)
        {
            Staff staff = _context.Staffs.FirstOrDefault(x => x.StaffId == id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
            }
        }

        public IEnumerable<Staff> GetAll()
        {
            return _context.Staffs.ToList();
        }

        public Staff GetById(int id)
        {
            return _context.Staffs.FirstOrDefault(x => x.StaffId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Staff item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
