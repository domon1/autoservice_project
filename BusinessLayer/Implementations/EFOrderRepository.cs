﻿using BusinessLayer.Interfaces;
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
    }
}
