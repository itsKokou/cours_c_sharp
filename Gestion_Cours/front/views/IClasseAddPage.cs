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
    public interface IClasseAddPage : IPage
    {
        string Message { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Filiere FiliereSelected { get; set; }
        Niveau NiveauSelected { get; set; }
        String Libelle { get; set; }
        String Effectif { get; set; }
        List<Module> ModulesSelected { get; set; }



        //Events (CallBack)
        event EventHandler SelectFiliereEvent;
        event EventHandler ClickBtnSaveEvent;

        //Methodes de chargement de données
        void setClasseBindingSource(BindingSource filiereList, BindingSource niveauList,BindingSource moduleList);
    }
}
