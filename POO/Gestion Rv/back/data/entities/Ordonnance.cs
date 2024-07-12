using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Ordonnance
    {
        private int id;
        private string posologie;
        private List<Medicament> medicaments;

        public Ordonnance()
        {
        }

        public Ordonnance(int id, string posologie, List<Medicament> medicaments)
        {
            this.id = id;
            this.posologie = posologie;
            this.medicaments = medicaments;
        }

        public int Id { get => id; set => id = value; }
        public string Posologie { get => posologie; set => posologie = value; }
        public List<Medicament> Medicaments { get => medicaments; set => medicaments = value; }
    }
}
