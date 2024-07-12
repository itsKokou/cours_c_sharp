using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public interface IClasseService: IService<Classe>
    {
        ICoursService CoursService { get; set; }
        List<Niveau> getAllNiveau();
        List<Filiere> getAllFiliere();
        List<Classe> getAllByNiveauAndFiliere(int niveauId, int filiereId);
        List<Module> getClasseModules(int classeID);
        List<Classe> getClasseDisponibles(Module module, DateTime date, DateTime heureD, DateTime heureF, List<Classe> classesDuProf );
    }
}
