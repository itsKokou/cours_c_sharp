using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Classe
    {
        private int id;
        private string name;
        private int effectif;
        private bool isArchived;

        private Niveau niveau;
        private Filiere filiere;
        private List<Module>modules = new List<Module>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Effectif { get => effectif; set => effectif = value; }
        public bool IsArchived { get => isArchived; set => isArchived = value; }
        public Niveau Niveau { get => niveau; set => niveau = value; }
        public Filiere Filiere { get => filiere; set => filiere = value; }
        public List<Module> Modules { get => modules; set => modules = value; }

        public override string ToString()
        {
            return name;
        }
    }
}
