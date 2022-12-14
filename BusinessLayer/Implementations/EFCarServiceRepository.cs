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
    public class EFCarServiceRepository: ICarServiceRepository
    {
        private EFDbContext _context;

        public EFCarServiceRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(CarService item)
        {
            _context.CarServices.Add(item);
        }

        public void Delete(int id)
        {
            CarService carService = _context.CarServices.FirstOrDefault(x => x.CarServiceId == id);
            if (carService != null)
            {
                _context.CarServices.Remove(carService);
            }
        }

        public IEnumerable<CarService> GetAll()
        {
            return _context.CarServices.ToList();
        }

        public CarService GetById(int id)
        {
            return _context.CarServices.FirstOrDefault(x => x.CarServiceId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(CarService item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
