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
    public class EFCarRepository : ICarRepository
    {
        private EFDbContext _context;

        public EFCarRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(Car item)
        {
            _context.Cars.Add(item);
        }

        public void Delete(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CarId == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public Car GetById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.CarId == id);
        }

        public void Update(Car item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAllById(int id)
        {
            return _context.Cars.ToList().Where(x => x.CustomerId == id);
        }
    }
}
