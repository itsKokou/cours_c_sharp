using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Enseignement
    {
        private int id;
        private Professeur professeur;
        private Classe classe;
        private List<Module> modules = new List<Module>();

        public Enseignement(int id, Professeur professeur, Classe classe, List<Module> modules)
        {
            this.id = id;
            this.professeur = professeur;
            this.classe = classe;
            this.modules = modules;
        }

        public int Id { get => id; set => id = value; }
        public Professeur Professeur { get => professeur; set => professeur = value; }
        public Classe Classe { get => classe; set => classe = value; }
        public List<Module> Modules { get => modules; set => modules = value; }
    }
}
