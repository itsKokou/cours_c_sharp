using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.entities
{
    public class Professeur:User
    {
        private Grade grade;

        public Professeur():base()
        {
        }

        public Professeur(string nomComplet, string login, string password,Grade grade,Role role) :base(nomComplet,login,password,role)
        {
           this.grade = grade;
        }



        public Grade Grade { get => grade; set => grade = value; }


    }
}
