using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.front.views
{
    public interface IFormProfesseurView
    {
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        int ProfesseurId { get; set; }//recuperer l'id au moment du update
        Grade FiltreGradeSelected { get; set; }
        String NomComplet { get; set; }
        String Login { get; set; }
        String Password { get; set; }
        Grade GradeSelected { get; set; }

        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectProfesseurEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;

        //Methodes de chargement de données
        void setProfesseurBindingSource(BindingSource professeurList, BindingSource gradeList, BindingSource filtreGradeList);

    }
}
