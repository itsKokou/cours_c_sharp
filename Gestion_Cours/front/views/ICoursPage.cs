using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface ICoursPage : IPage
    {
        string Message { get; set; }
        string UserName { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Professeur ProfesseurSelected { get; set; }
        Classe ClasseSelected { get; set; }
        CoursDto CoursSelected { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectCoursEvent;
        event EventHandler ClickBtnDeleteEvent;
        event EventHandler FiltreEvent;
        event EventHandler ClickBtnVoirClasse;

        //Methodes de chargement de données
        void setCoursBindingSource(BindingSource coursList, BindingSource professeurList, BindingSource classeList);
    }
}
