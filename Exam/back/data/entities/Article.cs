using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.data.entities
{
    public class Article
    {
        private int id;
        private string reference;
        private string name;
        private double prix;
        private int qteCmd;
        private int qteStock;
        private double montant;

        public int Id { get => id; set => id = value; }
        public string Reference { get => reference; set => reference = value; }
        public string Name { get => name; set => name = value; }
        public double Prix { get => prix; set => prix = value; }
        public int QteCmd { get => qteCmd; set => qteCmd = value; }
        public int QteStock { get => qteStock; set => qteStock = value; }
        public double Montant { get => montant; set => montant = value; }

        public override bool Equals(object obj)
        {
            return obj is Article article &&
                   id == article.id;
        }
    }
}
