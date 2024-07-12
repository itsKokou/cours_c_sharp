using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.entities
{
    public class Classe
    {
        private int id;
        private string name;
        private Filiere filiere;
        private Niveau niveau;

        public Classe()
        {
        }

        public Classe(string name, Filiere filiere, Niveau niveau)
        {
            this.name = name;
            this.filiere = filiere;
            this.niveau = niveau;
        }

        public Classe(int id, string name, Filiere filiere, Niveau niveau)
        {
            this.id = id;
            this.name = name;
            this.filiere = filiere;
            this.niveau = niveau;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Filiere Filiere { get => filiere; set => filiere = value; }
        public Niveau Niveau { get => niveau; set => niveau = value; }

        public override string ToString()
        {
            return name;
        }
    };
}
