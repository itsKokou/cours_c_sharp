using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.dto
{
    public class CoursDto4Attributs
    {
        private int id;
        private DateTime date;
        private DateTime heureD;
        private DateTime heureF;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime HeureD { get => heureD; set => heureD = value; }
        public DateTime HeureF { get => heureF; set => heureF = value; }
    }
}
