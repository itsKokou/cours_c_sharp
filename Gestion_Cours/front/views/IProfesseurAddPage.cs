using Gestion_Cours.back.data.entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface IProfesseurAddPage:IPage
    {
        string Message { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        string NomComplet { get; set; }
        string Portable { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        Classe ClasseSelected { get; set; }
        List<Module> ModulesSelected { get; set; }//Modules par classes



        //Events (CallBack)
        event EventHandler SelectClasseEvent; // charger les modules
        event EventHandler ClickBtnSaveEvent;
        event EventHandler ClickBtnAddEnseignementEvent;
        //Methodes de chargement de données
        void setProfesseurClasseAndModuleBindingSource(BindingSource classeList, BindingSource moduleList);
    }
}
