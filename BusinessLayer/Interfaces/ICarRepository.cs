using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll(); // получение всех объектов
        IEnumerable<Car> GetAllById(int id); // получение всех объектов по id
        Car GetById(int id); // получение одного объекта по id
        void Create(Car item); // создание объекта
        void Update(Car item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
