using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Gestion_Cours.front.views
{
    public interface IClassePage : IPage
    {
        string Message { get; set; }
        string UserName{ get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Filiere FiliereSelected { get; set; }
        Niveau NiveauSelected { get; set; }
        Classe ClasseSelected { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectClasseEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;
        event EventHandler FiltreEvent;
        event EventHandler ClickBtnVoirModule;

        //Methodes de chargement de données
        void setClasseBindingSource(BindingSource classeList, BindingSource filiereList, BindingSource niveauList);
    }
}
