using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Medecin:User
    {
        private string statut;

        public string Statut { get => statut; set => statut = value; }

        public Medecin(int id, string nomComplet, string login, string password,string statut) : base(id, nomComplet, login, password)
        {
            this.Type = "MEDECIN";
            this.statut = statut;
        }

        public Medecin():base()
        {
            this.Type = "MEDECIN";
        }
    }
}
