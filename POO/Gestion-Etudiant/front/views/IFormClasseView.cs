using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.front.views
{
    public interface IFormClasseView:IView
    {
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        int ClasseId { get; set; }//recuperer l'id au moment du update
        Filiere FiliereSelected { get; set; }
        Niveau NiveauSelected { get; set; }
        String Code { get; set; }

        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectClasseEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;

        //Methodes de chargement de données
        void setClasseBindingSource(BindingSource classeList, BindingSource filiereList, BindingSource niveauList);

    }
}
