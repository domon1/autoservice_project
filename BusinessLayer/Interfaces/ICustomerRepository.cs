using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll(); // получение всех объектов
        Customer GetById(int id); // получение одного объекта по id
        void Create(Customer item); // создание объекта
        void Update(Customer item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
