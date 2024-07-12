using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface IModulePage : IPage
    {
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Module ModuleSelected { get; set; }
        String Libelle { get; set; }



        //Events (CallBack)
        event EventHandler ClickBtnAddEvent;
        event EventHandler SelectModuleEvent;
        event EventHandler ClickBtnEditEvent;
        event EventHandler ClickBtnDeleteEvent;

        //Methodes de chargement de données
        void setModuleBindingSource(BindingSource moduleList);
    }
}
