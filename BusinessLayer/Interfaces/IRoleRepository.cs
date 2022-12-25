using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll(); // получение всех объектов
        Role GetUserRole();
    }
}
