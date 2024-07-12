using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Rv
    {
        private int id;
        private string type;
        private DateTime date;
        private DateTime heure;
        private Medecin medecin;
        private Patient patient;
        private bool isValidated;
        private bool isArchived;
        private Consultation consultation; //Null si rv pas fait
        private Prestation prestation; //Null si rv pas fait 

        public Rv()
        {
        }

        public Rv(string type, DateTime date, DateTime heure, Medecin medecin, Patient patient)
        {
            this.type = type;
            this.date = date;
            this.heure = heure;
            this.medecin = medecin;
            this.patient = patient;
        }

        public Rv(int id, string type, DateTime date, DateTime heure, Medecin medecin, Patient patient, bool isValidated, bool isArchived)
        {
            this.id = id;
            this.type = type;
            this.date = date;
            this.heure = heure;
            this.medecin = medecin;
            this.patient = patient;
            this.isValidated = isValidated;
            this.isArchived = isArchived;
        }

        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Heure { get => heure; set => heure = value; }
        public Medecin Medecin { get => medecin; set => medecin = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public bool IsValidated { get => isValidated; set => isValidated = value; }
        public bool IsArchived { get => isArchived; set => isArchived = value; }
        public Consultation Consultation { get => consultation; set => consultation = value; }
        public Prestation Prestation { get => prestation; set => prestation = value; }
    }
}
