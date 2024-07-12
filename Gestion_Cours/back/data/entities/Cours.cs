using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Cours
    {
        private int id;
        private DateTime date;
        private DateTime heureD;
        private DateTime heureF;
        private string code;

        private Module module;
        private Professeur professeur;
        private Salle salle;
        private List<Classe> classes = new List<Classe>();
        private bool isArchived;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime HeureD { get => heureD; set => heureD = value; }
        public DateTime HeureF { get => heureF; set => heureF = value; }
        public string Code { get => code; set => code = value; }
        public Module Module { get => module; set => module = value; }
        public Professeur Professeur { get => professeur; set => professeur = value; }
        public Salle Salle { get => salle; set => salle = value; }
        public List<Classe> Classes { get => classes; set => classes = value; }
        public bool IsArchived { get => isArchived; set => isArchived = value; }
    }
}
