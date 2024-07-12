using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Patient:Personne
    {
        private string code;
        private string antecedents;

        public string Code { get => code; set => code = value; }
        public string Antecedents { get => antecedents; set => antecedents = value; }

        public Patient():base()
        {
            base.Type = "PATIENT";
        }

        public Patient(string nomComplet,string code, string antecedents):base(nomComplet)
        {
            base.Type = "PATIENT";
            this.code = code;
            this.antecedents = antecedents;
        }

        public Patient(int id,string nomComplet, string code, string antecedents) : base(id,nomComplet)
        {
            base.Type = "PATIENT";
            this.code = code;
            this.antecedents = antecedents;
        }

        
    }
}
