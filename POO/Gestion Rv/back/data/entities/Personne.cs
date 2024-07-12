using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Personne
    {
        private int id;
        private string nomComplet;
        private string type;

        protected int Id { get => id; set => id = value; }
        protected string NomComplet { get => nomComplet; set => nomComplet = value; }
        protected string Type { get => type; set => type = value; }

        public Personne()
        {
        }

        public Personne(string nomComplet)
        {
            this.nomComplet = nomComplet;
        }

        public Personne(int id, string nomComplet)
        {
            this.id = id;
            this.nomComplet = nomComplet;
        }
    }
}
