using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.dto
{
    public class CoursDto
    {

        private int id;
        private string date;
        private string horaire;
        private string code;

        private string module;
        private string professeur;
        private string classes;
        private string salle;

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Code { get => code; set => code = value; }
        public string Module { get => module; set => module = value; }
        public string Professeur { get => professeur; set => professeur = value; }
        public string Salle { get => salle; set => salle = value; }
        public string Classes { get => classes; set => classes = value; }
        public string Horaire { get => horaire; set => horaire = value; }
    }
}
