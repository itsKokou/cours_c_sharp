using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.front.views
{
    public interface IClasseAddPage
    {
        string Message { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        Filiere FiliereSelected { get; set; }
        Niveau NiveauSelected { get; set; }
        String Libelle { get; set; }
        int Effectif { get; set; }



        //Events (CallBack)
        event EventHandler SelectFiliereEvent;
        event EventHandler ClickBtnSaveEvent;

        //Methodes de chargement de données
        void setClasseBindingSource(List<Filiere> filiereList, List<Niveau> niveauList);
    }
}
