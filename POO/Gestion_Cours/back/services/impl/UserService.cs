using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int add(User entity)
        {
            throw new NotImplementedException();
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
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
