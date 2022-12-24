using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITimeOrderRepository
    {
        IEnumerable<TimeOrder> GetAll(); // получение всех объектов
        TimeOrder GetById(int id); // получение одного объекта по id
        IEnumerable<TimeOrder> GetTimeByDate(string date);
    }
}
