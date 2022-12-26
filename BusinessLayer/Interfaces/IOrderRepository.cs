using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll(); // получение всех объектов
        Order GetById(int id); // получение одного объекта по id
        void Create(Order item); // создание объекта
        void Update(Order item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
        IEnumerable<Order> GetAllById(int id);
        IEnumerable<Order> GetAllNotFinishedById(int id);
        IEnumerable<Order> GetAllNotFinishedByDate(string date);
        IEnumerable<Order> GetAllFinishedById(int id);
        int GetClientId(Order order);
    }
}
