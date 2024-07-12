using Gestion_Etudiant.back.data.dto;
using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.services
{
    public interface IUserService
    {
        UserDto Connexion(string login,string password);
    }
}
