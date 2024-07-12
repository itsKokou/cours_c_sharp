using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Salle
    {
        private int id;
        private string name;
        private int nbrePlace;
        private bool isArchived;

        public Salle()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int NbrePlace { get => nbrePlace; set => nbrePlace = value; }
        public bool IsArchived { get => isArchived; set => isArchived = value; }
    }
}
