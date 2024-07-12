using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.entities
{
    public class Article
    {
        private int id;
        private string libelle;
        private string reference;
        private int qteStock;
        private double prix;

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public string Reference { get => reference; set => reference = value; }
        public int QteStock { get => qteStock; set => qteStock = value; }
        public double Prix { get => prix; set => prix = value; }
    }
}
