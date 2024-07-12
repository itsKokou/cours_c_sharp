using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.dto
{
    public class ClasseEnseigneeDto
    {
        private int id;
        private string name;
        private int effectif;

        private Niveau niveau;
        private Filiere filiere;
        private string modules;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Effectif { get => effectif; set => effectif = value; }
        public Niveau Niveau { get => niveau; set => niveau = value; }
        public Filiere Filiere { get => filiere; set => filiere = value; }
        public string Modules { get => modules; set => modules = value; }
    }
}
