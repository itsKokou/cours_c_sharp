using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.dto
{
    public class ArticleDto
    {
        private string reference;
        private string libelle;
        private double prix;
        private int qteCmde;
        private double montant;

        public string Reference { get => reference; set => reference = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public double Prix { get => prix; set => prix = value; }
        public int QteCmde { get => qteCmde; set => qteCmde = value; }
        public double Montant { get => montant; set => montant = value; }
    }
}
