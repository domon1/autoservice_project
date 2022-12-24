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
    public class EFTimeOrderRepository : ITimeOrderRepository
    {
        private EFDbContext _context;

        public EFTimeOrderRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeOrder> GetAll()
        {
            return _context.TimeOrders.ToList();
        }

        public TimeOrder GetById(int id)
        {
            return _context.TimeOrders.FirstOrDefault(x => x.TimeOrderId == id);
        }

        public IEnumerable<TimeOrder> GetTimeByDate(string date)
        {
            var order = _context.Orders
                .Where(x => x.Date == date)
                .Select(x => x.TimeOrderId).
                ToList();

            var timeByDate = _context.TimeOrders.Where(x => !order.Contains(x.TimeOrderId)).ToList();

            return timeByDate;
        }
    }
}
