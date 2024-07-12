using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Medicament
    {
        private int id;
        private string code;
        private string name;

        public Medicament()
        {
        }

        public Medicament(int id, string code, string name)
        {
            this.id = id;
            this.code = code;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
    }
}
