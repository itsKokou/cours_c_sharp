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
        private DateOnly date;
        private TimeOnly heureD;
        private TimeOnly heureF;
        private string code;

        private Module module;
        private Professeur professeur;
        private Salle salle;
        private List<Classe> classes = new List<Classe>();

        public int Id { get => id; set => id = value; }
        public DateOnly Date { get => date; set => date = value; }
        public TimeOnly HeureD { get => heureD; set => heureD = value; }
        public TimeOnly HeureF { get => heureF; set => heureF = value; }
        public string Code { get => code; set => code = value; }
        public Module Module { get => module; set => module = value; }
        public Professeur Professeur { get => professeur; set => professeur = value; }
        public Salle Salle { get => salle; set => salle = value; }
        public List<Classe> Classes { get => classes; set => classes = value; }
    }
}
