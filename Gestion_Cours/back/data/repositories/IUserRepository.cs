using Gestion_Cours.back.core;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories
{
    public interface IUserRepository : IRepository<User>
    {
        DataTable findUserByLogin(string login);
    }
}
