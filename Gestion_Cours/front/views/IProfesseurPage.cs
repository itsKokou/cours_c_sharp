using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface IProfesseurPage : IPage
    {
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        string Portable { get; set; }
        Professeur ProfesseurSelected { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectProfesseurEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;
        event EventHandler FiltreEvent;
        event EventHandler ClickBtnVoirClasse;

        //Methodes de chargement de données
        void setProfeseurBindingSource(BindingSource professeurList);
    }
}
