using Gestion_Etudiant.back.core;
using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories
{
    public interface IUserRepository : IRepository<User>
    {
        DataTable findUserByLogin(string login);
    }
}
