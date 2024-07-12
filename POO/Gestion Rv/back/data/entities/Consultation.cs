using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Consultation
    {
        private int id;
        private string constantes;
        private Ordonnance ordonnance;
        private List<Prestation> prestations;

        public Consultation()
        {
        }

        public Consultation(string constantes, Ordonnance ordonnance, List<Prestation> prestations)
        {
            this.constantes = constantes;
            this.ordonnance = ordonnance;
            this.prestations = prestations;
        }

        public Consultation(int id, string constantes, Ordonnance ordonnance, List<Prestation> prestations)
        {
            this.id = id;
            this.constantes = constantes;
            this.ordonnance = ordonnance;
            this.prestations = prestations;
        }

        public int Id { get => id; set => id = value; }
        public string Constantes { get => constantes; set => constantes = value; }
        public Ordonnance Ordonnance { get => ordonnance; set => ordonnance = value; }
        public List<Prestation> Prestations { get => prestations; set => prestations = value; }
    }
}
