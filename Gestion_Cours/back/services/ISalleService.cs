using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public interface ISalleService : IService<Salle>
    {
        ICoursService CoursService { get; set; }

        List<Salle> getSalleDisponibles(int nbrePlace,Module module, DateTime date, DateTime heureD, DateTime heureF);
    }
}
