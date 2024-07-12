using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.entities
{
    public class Commande
    {
        private int id;
        private double montant;
        private int qteCmde;
        private List<Article> articles = new List<Article>();
        private Client client;

        public int Id { get => id; set => id = value; }
        public double Montant { get => montant; set => montant = value; }
        public int QteCmde { get => qteCmde; set => qteCmde = value; }
        public Client Client { get => client; set => client = value; }
        public List<Article> Articles { get => articles; set => articles = value; }
    }
}
