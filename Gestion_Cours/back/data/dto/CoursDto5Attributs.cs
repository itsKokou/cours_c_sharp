using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.dto
{
    public class CoursDto5Attributs
    {
        private int id;
        private DateTime date;
        private DateTime heureD;
        private DateTime heureF;
        private Module module;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime HeureD { get => heureD; set => heureD = value; }
        public DateTime HeureF { get => heureF; set => heureF = value; }
        public Module Module { get => module; set => module = value; }
    }
}
