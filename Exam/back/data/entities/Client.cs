using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.data.entities
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string portable;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Portable { get => portable; set => portable = value; }
    }
}
