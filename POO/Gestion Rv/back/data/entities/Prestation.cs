using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.data.entities
{
    public class Prestation
    {
        private int id;
        private string name;

        public Prestation()
        {
        }

        public Prestation(int id, string name)
        {
            this.id = id;
            this.name = name;
        }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
