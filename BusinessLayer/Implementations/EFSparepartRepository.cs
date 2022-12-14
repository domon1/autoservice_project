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
    public class EFSparepartRepository : ISparepartRepository
    {
        private EFDbContext _context;

        public EFSparepartRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Create(Sparepart item)
        {
            _context.Spareparts.Add(item);
        }

        public void Delete(int id)
        {
            Sparepart sparepart = _context.Spareparts.FirstOrDefault(x => x.SparepartId == id);
            if (sparepart != null)
            {
                _context.Spareparts.Remove(sparepart);
            }
        }

        public IEnumerable<Sparepart> GetAll()
        {
            return _context.Spareparts.ToList();
        }

        public Sparepart GetById(int id)
        {
            return _context.Spareparts.FirstOrDefault(x => x.SparepartId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Sparepart item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
