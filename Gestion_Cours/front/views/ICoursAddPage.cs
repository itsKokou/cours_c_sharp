using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface ICoursAddPage : IPage
    {
        string Message { get; set; }
        bool IsSuccessFul { get; set; }

        //Champs (qu'on recupère de la vue)
        dynamic DateSelected { get; set; }
        dynamic HeureDSelected { get; set; }
        dynamic HeureFSelected { get; set; }
        Module ModuleSelected { get; set; }
        Professeur ProfesseurSelected { get; set; }
        String CodeCours { get; set; }
        Salle SalleSelected { get; set; }
        List<Classe> ClassesSelected { get; set; }



        //Events (CallBack)
        event EventHandler SelectModuleEvent;
        event EventHandler SelectProfesseurEvent;
        event EventHandler SelectClassesEvent;
        event EventHandler SelectSalleEvent; //fermer codeCours
        event EventHandler SaisieCodeEvent; //retirer les elements de salle
        event EventHandler ClickBtnSaveEvent;

        event EventHandler SelectDateEvent; 
        event EventHandler SelectHeureDebutEvent; 
        event EventHandler SelectHeureFinEvent;

        //Bloquer saisie code
        void DisableCodeCours();
        void EnableCodeCours();
        void DisableSalle();
        void EnableSalle();
        void EnableHeureDebut();
        void DisableHeureDebut();
        void EnableHeureFin();
        void DisableHeureFin();
        void EnableModule();
        void DisableModule();
        void EnableProfessseur();
        void DisableProfessseur();
        void EnableClasse();
        void DisableClasse();
        void EnableBtnEnregistrer();
        void DisableBtnEnregistrer();

        //Methodes de chargement de données
        void setCoursBindingSource(BindingSource moduleList, BindingSource professeurList, BindingSource classeList, BindingSource salleList);
    }
}
