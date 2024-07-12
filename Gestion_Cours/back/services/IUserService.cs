using Gestion_Cours.back.data.entities;
using Gestion_Etudiant.back.data.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public interface IUserService : IService<User>
    {
        UserDto Connexion(string login, string password);
    }

}
