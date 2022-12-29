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
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext _context;

        public EFOrderRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(Order item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Order item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Order> GetAllById(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CustomerId == id);
            return _context.Orders.ToList().Where(x => x.CarId == car.CarId);
        }

        public IEnumerable<Order> GetAllNotFinishedById(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CustomerId == id);
            if (car != null)
            {
                var order = GetAll().Where(x => x.CarId == car.CarId && x.State == "waiting");
                return order;
            }
            else
            {
                var order = GetAll().Where(x => x.CarId == 0 && x.State == "waiting");
                return order;
            }


            //(x => x.CarId == car.CarId && x.State == "waiting")
        }

        public IEnumerable<Order> GetAllNotFinishedByDate(string date)
        {
            return _context.Orders.Where(x => x.Date == date && x.State == "waiting")
                .Include(x => x.Car).Include(x => x.CarService).Include(x => x.TimeOrder).ToList();
        }

        public IEnumerable<Order> GetAllWorkingByDate(string date)
        {
            return _context.Orders.ToList().Where(x => x.Date == date && x.State == "working");
        }

        public IEnumerable<Order> GetAllWorkingByDateAndStaff(string date, int staffId)
        {
            return _context.Orders.Where(x => x.Date == date && x.State == "working" && x.StaffId == staffId)
                .Include(x => x.Car).Include(x => x.CarService).Include(x => x.TimeOrder).ToList();
        }

        public IEnumerable<Order> GetAllCheck()
        {
            return _context.Orders.Where(x => x.State == "check")
                .Include(x => x.Car).Include(x => x.CarService).Include(x => x.TimeOrder).ToList();
        }

        public IEnumerable<Order> GetAllFinishedById(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CustomerId == id);
            if (car != null)
            {
                var order = _context.Orders.ToList().Where(x => x.CarId == car.CarId && x.State == "finish");
                return order;
            }
            else
            {
                var order = _context.Orders.ToList().Where(x => x.CarId == 0 && x.State == "finish");
                return order;
            }
            //try
            //{
            //    Car car = _context.Cars.FirstOrDefault(x => x.CustomerId == id);
            //    var order = _context.Orders.ToList().Where(x => x.CarId == car.CarId && x.State == "finish");
            //    return order;
            //}
            //catch (NullReferenceException)
            //{
            //    throw new NullReferenceException();
            //    //return null;
            //}
        }

        public int GetClientId(Order order)
        {
            return _context.Cars.FirstOrDefault(x => x.CarId == order.CarId).CustomerId;
        }
    }
}
