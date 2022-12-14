using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext _context;

        public EFCustomerRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(Customer item)
        {
            _context.Customers.Add(item);
        }

        public void Delete(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
