using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class DemandeAnnulation
    {
        private int id;
        private DateTime date;
        private string motif;
        private Patient patient;
        private Rv rv;

        public DemandeAnnulation()
        {
        }

        public DemandeAnnulation(DateTime date, string motif, Patient patient, Rv rv)
        {
            this.date = date;
            this.motif = motif;
            this.patient = patient;
            this.rv = rv;
        }

        public DemandeAnnulation(int id, DateTime date, string motif, Patient patient, Rv rv)
        {
            this.id = id;
            this.date = date;
            this.motif = motif;
            this.patient = patient;
            this.rv = rv;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Motif { get => motif; set => motif = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Rv Rv { get => rv; set => rv = value; }
    }
}
