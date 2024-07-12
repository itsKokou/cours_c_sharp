using Gestion_Etudiant.back.core.impl;
using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class UserRepository : DataBase, IUserRepository
    {
        public int add(User entity)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable findUserByLogin(string login)
        {
            string SQL_SELECT = String.Format("select u.*, r.* from users u, role r where u.roleID=r.id and u.login = '{0}'", login);
            this.tableName = "CONNECTEDUSER";
            return  ExecuteSelect(SQL_SELECT);
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public int update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
