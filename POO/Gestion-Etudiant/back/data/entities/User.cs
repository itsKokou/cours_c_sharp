using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.entities
{
    public class User
    {
        protected int id;
        protected string nomComplet;
        protected string login;
        protected string password;
        private Role role;

        public User()
        {
        }

        public User(string nomComplet, string login, string password, Role role)
        {
            this.NomComplet = nomComplet;
            this.Login = login;
            this.Password = password;
            this.Role = role;
        }

        public int Id { get => id; set => id = value; }
        public string NomComplet { get => nomComplet; set => nomComplet = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        protected Role Role { get => role; set => role = value; }
    }
}
