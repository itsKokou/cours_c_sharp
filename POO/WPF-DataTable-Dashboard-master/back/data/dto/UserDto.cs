using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours_Projet.back.data.dto
{
    public class UserDto
    {
        private int id;
        private string nomComplet;
        private string roleName;
        private string roleDescription;

        public int Id { get => id; set => id = value; }
        public string NomComplet { get => nomComplet; set => nomComplet = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string RoleDescription { get => roleDescription; set => roleDescription = value; }
    }
}
