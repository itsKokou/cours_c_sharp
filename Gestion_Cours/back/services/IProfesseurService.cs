using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public interface IProfesseurService : IService<Professeur>
    {
        ICoursService CoursService { get; set; }
        List<Professeur> getProfesseurByPortable(string portable);
        List<Module> getModulesByEnseignement(int enseignementID);
        List<Enseignement> getEnseignementsByClasse(int classeID);
        List<Enseignement> getEnseignementsByProfesseur(int profID);
        List<Professeur> getProfDisponibles(Module module, DateTime date, DateTime heureD, DateTime heureF);
        List<Classe> getClassesEnseigneesByProfesseurAndModule(int professeur, Module module);
        List<Classe> getClassesEnseigneesByProfesseur(int professeur);
    }
}
