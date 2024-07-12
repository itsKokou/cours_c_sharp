using Gestion_Etudiant.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories
{
    public class FabriqueRepository
    {
        public static IUserRepository userRepository;
        public static IUserRepository GetUserRepository()
        {
            if(userRepository == null)
            {
                userRepository = new UserRepository();
            }
            return userRepository;
        }
    }
}
