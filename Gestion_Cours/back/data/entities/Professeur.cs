using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Gestion_Cours.back.data.entities
{
    public class Professeur:User
    {
        private string portable;
        private List<Enseignement> enseignements = new List<Enseignement>();
        public string Portable { get => portable; set => portable = value; }
        public List<Enseignement> Enseignements { get => enseignements; set => enseignements = value; }

        public override string ToString()
        {
            return nomComplet;
        }

    }
}
