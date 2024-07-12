using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class User:Personne
    {
        private string login;
        private string password;

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        public User(int id, string nomComplet,string login, string password) : base(id, nomComplet)
        {
            this.Type = "USER";
            this.login = login;
            this.password = password;
        }

        public User():base()
        {
            this.Type = "USER";
        }
    }
}
