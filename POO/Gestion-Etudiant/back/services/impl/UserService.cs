using Gestion_Etudiant.back.data.dto;
using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.services.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserDto Connexion(string login,string password)
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
                    RoleName = row.ItemArray[6].ToString(),
                    RoleDescription = row.ItemArray[7].ToString()
                };
                passwordBd = row.ItemArray[3].ToString();
            }

            if (user == null || password != passwordBd)
            {
                return null;
            }
            return user;
        }
    }
}
