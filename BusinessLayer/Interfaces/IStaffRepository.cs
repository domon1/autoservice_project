using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAll(); // получение всех объектов
        Staff GetById(int id); // получение одного объекта по id
        void Create(Staff item); // создание объекта
        void Update(Staff item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
