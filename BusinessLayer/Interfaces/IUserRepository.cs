using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll(); // получение всех объектов
        void Create(User item); // создание объекта
        void Save();  // сохранение изменений
        User Login(string email, string password);
        int GetCustomerId(User user);
    }
}
