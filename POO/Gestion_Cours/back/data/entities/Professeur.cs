using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Professeur:User
    {
        private string portable;

        public Professeur(string portable)
        {
        }

        public string Portable { get => portable; set => portable = value; }
    }
}
