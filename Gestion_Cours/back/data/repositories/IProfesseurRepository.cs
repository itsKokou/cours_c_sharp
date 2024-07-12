using Gestion_Cours.back.core;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories
{
    public interface IProfesseurRepository: IRepository<Professeur>
    {
        DataTable findProfesseurByPortable(string portable);
        DataTable findModulesByEnseignement(int enseignementID);
        DataTable findEnseignementsByClasse(int classeID);
        DataTable findEnseignementsByProfesseur(int profID);
    }
}
