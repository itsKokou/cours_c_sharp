using Gestion_Cours.back.core.impl;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class UserRepository : DataBase, IUserRepository
    {
        public int insert(User entity)
        {
            throw new NotImplementedException();
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable findUserByLogin(string login)
        {
            string SQL_SELECT = String.Format("select * from user where login = {0}",login);
            this.tableName = "USERCONNECT";
            return  ExecuteSelect(SQL_SELECT);
        }

        public DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public User findById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
