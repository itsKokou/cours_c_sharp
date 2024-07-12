using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gestion_Cours.front.views
{
    public interface IClassePage
    {
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        int ClasseId { get; set; }//recuperer l'id au moment du update
        Filiere FiliereSelected { get; set; }
        Niveau NiveauSelected { get; set; }
        Classe ClasseSelected { get; set; }
        String Code { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectClasseEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;
        event EventHandler FiltreEvent;

        //Methodes de chargement de données
        void setClasseBindingSource(List<Classe> classeList, List<Filiere> filiereList, List<Niveau> niveauList);
    }
}
