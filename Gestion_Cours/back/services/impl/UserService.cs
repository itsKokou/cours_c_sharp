using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using Gestion_Etudiant.back.data.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        //==============================================================

        public static IUserService userService = null;
        public static IUserService GetInstance(IUserRepository userRepository)
        {
            if (userService == null)
            {
                userService = new UserService(userRepository);
            }
            return userService;
        }
        //===============================================================

        public int add(User entity)
        {
            throw new NotImplementedException();
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto Connexion(string login, string password)
        {
            DataTable dataTable = userRepository.findUserByLogin(login);
            UserDto user = null;
            string passwordBd = "";
            if (dataTable.Rows.Count != 0)
            {
                DataRow row = dataTable.Rows[0];
                user = new UserDto()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    NomComplet = row.ItemArray[1].ToString(),
                    IsArchived = Convert.ToBoolean(row.ItemArray[5]),
                    RoleName = row.ItemArray[7].ToString(),
                    RoleDescription = row.ItemArray[8].ToString()
                };
                passwordBd = row.ItemArray[4].ToString();
            }

            if (user == null || password != passwordBd)
            {
                return null;
            }
            return user;
        }

        public User findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> getAll()
        {
            throw new NotImplementedException();
        }

        public int update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
