using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface ISallePage:IPage
    {

        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Salle SalleSelected { get; set; }
        String Libelle { get; set; }
        int NbrePlace { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectSalleEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;

        //Methodes de chargement de données
        void setSalleBindingSource(BindingSource salleList);
    }
}
