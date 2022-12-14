using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICarServiceRepository
    {
        IEnumerable<CarService> GetAll(); // получение всех объектов
        CarService GetById(int id); // получение одного объекта по id
        void Create(CarService item); // создание объекта
        void Update(CarService item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
