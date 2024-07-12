using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.services
{
    public interface IProfesseurService
    {
        int addProfesseur(Professeur prof);
        int updateProfesseur(Professeur prof);
        int deleteProfesseur(int id);
        DataTable getAllProfesseur();
        List<Grade> getAllGrade();
    }
}
