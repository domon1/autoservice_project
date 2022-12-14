using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ISparepartRepository
    {
        IEnumerable<Sparepart> GetAll(); // получение всех объектов
        Sparepart GetById(int id); // получение одного объекта по id
        void Create(Sparepart item); // создание объекта
        void Update(Sparepart item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
