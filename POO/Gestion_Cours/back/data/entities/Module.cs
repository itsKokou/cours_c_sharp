using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.entities
{
    public class Module
    {
        private int id;
        private string name;
        private bool isArchived;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool IsArchived { get => isArchived; set => isArchived = value; }
    }
}
