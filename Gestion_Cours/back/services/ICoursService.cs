using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Gestion_Cours.back.services
{
    public interface ICoursService : IService<Cours>
    {
        List<CoursDto> getAllDtoByProfesseurAndClasse(int professeur, int classe);//Soit classe soit prof ou les deux 
        List<CoursDto> getAllDto();
        List<CoursDto5Attributs> getAllByProfesseurAndClasse(int professeur, int classe);//Pour disponibilité
        List<Classe> getCoursClasses(int cours);//Pour classe d'un cours. id, name
        List<CoursDto4Attributs> getCoursBySalle(int salleID);//Pour disponibilité

    }

}
