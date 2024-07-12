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
    public interface ICoursRepository : IRepository<Cours>
    {
        DataTable findAllByProfesseurAndClasse(int professeur, int classe);//Soit classe soit prof ou les deux 
        int insertClasse(int coursID, int classeID);
        DataTable findCoursClasses(int cours);
        DataTable findCoursBySalle(int salleID);
    }
}
