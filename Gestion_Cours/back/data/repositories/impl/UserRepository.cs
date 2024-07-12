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
        private UserRepository() { }
        public static IUserRepository userRepository = null;
        public static IUserRepository GetInstance()
        {
            if (userRepository == null)
            {
                userRepository = new UserRepository();
            }
            return userRepository;
        }



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
            string SQL_SELECT = String.Format("select u.id, u.nomComplet,u.portable,u.login,CONVERT(NVARCHAR,DECRYPTBYCERT(CERT_ID('CERT'),u.password,N'GLrS23IsM')) as password,u.isArchived,r.* from users u, roles r where u.roleID=r.id and login = '{0}'", login);
            this.tableName = "USERCONNECT";
            return  ExecuteSelect(SQL_SELECT);
        }

        public DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
