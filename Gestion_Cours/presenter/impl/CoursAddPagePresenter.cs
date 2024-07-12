using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Effects;
using MessageBox = System.Windows.MessageBox;

namespace Gestion_Cours.presenter.impl
{
    public class CoursAddPagePresenter : PagePresenter, ICoursAddPagePresenter
    {
        private readonly ICoursService coursService;
        private readonly IModuleService moduleService;
        private readonly IProfesseurService professeurService;
        private readonly IClasseService classeService;
        private readonly ISalleService salleService;

        private readonly ICoursAddPage view;
        private readonly IMainWindows mainWindows;

        private Module moduleSelected;
        private Professeur professeurSelected;
        private Salle salleSelected = null;
        private List<Classe> classesSelected;
        private DateTime dateSelected;
        private DateTime heureDebutSelected;
        private DateTime heureFinSelected;
        private string codeCoursSaisi;

        //Reactive salle  si code vide et liste salle était remplie
        private bool reactiveSalle = false;

        private BindingSource bindingSourceModule = new BindingSource();
        private BindingSource bindingSourceProfesseur = new BindingSource();
        private BindingSource bindingSourceClasse = new BindingSource();
        private BindingSource bindingSourceSalle = new BindingSource();

        public CoursAddPagePresenter(ICoursService coursService, IModuleService moduleService, IProfesseurService professeurService, IClasseService classeService, ISalleService salleService, ICoursAddPage view, IMainWindows mainWindows):base(view,mainWindows)
        {
            this.coursService = coursService;
            this.moduleService = moduleService;
            this.professeurService = professeurService;
            this.classeService = classeService;
            this.salleService = salleService;
            this.view = view;
            this.mainWindows = mainWindows;

            this.mainWindows.GetFrame.Navigate(view);

            ActiveEventHandler();
            LoadData();
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnSaveEvent += AjouterCoursHandler;
            view.SelectModuleEvent += SelectModuleHandler;
            view.SelectProfesseurEvent += SelectProfesseurHandler;
            view.SelectSalleEvent += SelectSalleHandler;
            view.SelectClassesEvent += SelectClassesHandler;
            view.SaisieCodeEvent += SaisieCodeHandler;
            view.SelectDateEvent += SelectDateHandler;
            view.SelectHeureDebutEvent += SelectHeureDebutHandler;
            view.SelectHeureFinEvent += SelectHeureFinHandler;
        }

        public void AjouterCoursHandler(object sender, EventArgs e)
        { 
            try
            {
                
                int id = coursService.add(new Cours()
                {
                    Date = dateSelected,
                    HeureD = heureDebutSelected,
                    HeureF = heureFinSelected,
                    Module = moduleSelected,
                    Professeur = professeurSelected,
                    Code = codeCoursSaisi,
                    Salle = salleSelected,
                    Classes = classesSelected
                });


                view.IsSuccessFul = id != 0;
                if (view.IsSuccessFul)
                {
                    view.Message = "Cours Planifié avec succès";
                    view.Icone = MessageBoxImage.Information;
                    view.DisableBtnEnregistrer();
                }
            }
            catch (Exception)
            {
                view.IsSuccessFul = false;
                view.Message = "Erreur d'enrégistrement du Cours";
                view.Icone = MessageBoxImage.Error;
            }
            
        }

        public void LoadData()
        {
            bindingSourceModule.DataSource = moduleService.getAll();
            view.setCoursBindingSource(bindingSourceModule,bindingSourceProfesseur,bindingSourceClasse,bindingSourceSalle);
        }

        private int calculateNbrePlace()
        {
            int nbrePlace = 0;
            if(classesSelected.Count > 0)
            {
                foreach (var classe in classesSelected)
                {
                    nbrePlace += classe.Effectif;
                }
            }
            return nbrePlace;
        }
        private bool checkIfClassesSameNiveau(List<Classe> classes)
        {
            Classe firstClasse = null;
            if (classes.Count>0)
            {
                firstClasse = classes.First();
                foreach (var classe in classes)
                {
                    if (firstClasse.Niveau.Id != classe.Niveau.Id)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;//Rien dans la liste
            }
        }
        public void SelectClassesHandler(object sender, EventArgs e)
        {
            classesSelected = view.ClassesSelected;
            if (checkIfClassesSameNiveau(classesSelected))
            {
                if (classesSelected.Count>0)
                {
                    view.EnableCodeCours();
                    if (heureFinSelected.CompareTo(DateTime.Parse("17:00")) <= 0)
                    {
                        List<Salle>salles = salleService.getSalleDisponibles(calculateNbrePlace(),moduleSelected,dateSelected,heureDebutSelected,heureFinSelected);
                        if (salles.Count >0)
                        {
                            view.EnableSalle();
                            bindingSourceSalle.DataSource = salles;
                            reactiveSalle = true;
                        }
                        else
                        {
                            bindingSourceSalle.DataSource = new List<Salle>();
                            view.DisableSalle();
                            reactiveSalle=false;
                        }
                    }
                }
                else
                {
                    view.DisableCodeCours() ;
                    view.DisableSalle();
                    reactiveSalle = false;
                    view.DisableBtnEnregistrer();
                }
            }
            else
            {
                MessageBox.Show("Seules les classes de même niveau peuvent suivre le même cours !", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
                view.DisableCodeCours();
                view.DisableSalle();
                view.DisableBtnEnregistrer();
            }
        }

        public void SelectDateHandler(object sender, EventArgs e)
        {
            DateTime now =DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime dateS = view.DateSelected;

            if (dateS.CompareTo(now) <= 0)
            {
                //changement Date 
                view.DisableHeureDebut();
                view.DisableHeureFin();
                view.DisableModule();
                bindingSourceModule.DataSource = new List<Module>();
                view.DisableProfessseur();
                bindingSourceProfesseur.DataSource = new List<Professeur>();
                view.DisableClasse();
                bindingSourceClasse.DataSource = new List<Classe>();
                view.DisableBtnEnregistrer();
                MessageBox.Show(string.Format("Veuillez choisir une date qui vient après aujourd'hui : {0}", now.ToString("dd-MM-yyyy")),"INFORMATION",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else if (dateS.ToString("dddd").Equals("dimanche"))
            {
                //changement Date 
                view.DisableHeureDebut();
                view.DisableHeureFin();
                view.DisableModule();
                bindingSourceModule.DataSource = new List<Module>();
                view.DisableProfessseur();
                bindingSourceProfesseur.DataSource = new List<Professeur>();
                view.DisableClasse();
                bindingSourceClasse.DataSource = new List<Classe>();
                view.DisableBtnEnregistrer();
                MessageBox.Show("Un cours ne peut se faire un dimache !", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                dateSelected = dateS;
                view.EnableHeureDebut();
            }
        }

        public void SelectHeureDebutHandler(object sender, EventArgs e)
        {
            DateTime heureD = DateTime.Parse("08:00");
            DateTime heureF = DateTime.Parse("17:00");
            DateTime heureDebut = view.HeureDSelected; 
            if (heureDebut.CompareTo(heureD) <0 || heureDebut.CompareTo(heureF) > 0)
            {
                //changement Heure Debut 
                view.DisableHeureFin();
                view.DisableModule();
                bindingSourceModule.DataSource = new List<Module>();
                view.DisableProfessseur();
                bindingSourceProfesseur.DataSource = new List<Professeur>();
                view.DisableClasse();
                bindingSourceClasse.DataSource = new List<Classe>();
                view.DisableBtnEnregistrer();
                MessageBox.Show("Veuillez choisir une heure entre 08:00 et 17:00", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                heureDebutSelected = heureDebut;
                view.EnableHeureFin();
            }
        }

        public void SelectHeureFinHandler(object sender, EventArgs e)
        {
            DateTime heureD = DateTime.Parse("11:00");
            DateTime heureF = DateTime.Parse("20:00");
            DateTime heureFin = view.HeureFSelected;
            if (heureFin.CompareTo(heureD) < 0 || heureFin.CompareTo(heureF) > 0)
            {
                //changement Heure Fin 
                view.DisableModule();
                bindingSourceModule.DataSource = new List<Module>();
                view.DisableProfessseur();
                bindingSourceProfesseur.DataSource = new List<Professeur>();
                view.DisableClasse();
                bindingSourceClasse.DataSource = new List<Classe>();
                view.DisableBtnEnregistrer();
                MessageBox.Show("Veuillez choisir une heure entre 11:00 et 20:00", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                TimeSpan difference = heureFin - heureDebutSelected;
                Double diff = difference.TotalMinutes;
                if (diff <180 || diff>240)
                {
                    //changement Heure Fin 
                    view.DisableModule();
                    bindingSourceModule.DataSource = new List<Module>();
                    view.DisableProfessseur();
                    bindingSourceProfesseur.DataSource = new List<Professeur>();
                    view.DisableClasse();
                    bindingSourceClasse.DataSource = new List<Classe>();
                    view.DisableBtnEnregistrer();
                    MessageBox.Show("La durée d'un cours est compris entre 3-4 heures !","INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    heureFinSelected = heureFin;
                    view.EnableModule();
                    bindingSourceModule.DataSource = moduleService.getAll();
                }
            }
        }

        public void SelectModuleHandler(object sender, EventArgs e)
        {
            this.moduleSelected = view.ModuleSelected;
            //Charger Binding de prof en fonction de module et dispo
            if (moduleSelected!=null)
            {
                List<Professeur> professeurs = professeurService.getProfDisponibles(moduleSelected, dateSelected, heureDebutSelected, heureFinSelected);
                if (professeurs.Count > 0)
                {
                    bindingSourceProfesseur.DataSource = professeurs;
                    view.EnableProfessseur();
                }
                else
                {
                    //changement Module 
                    view.DisableProfessseur();
                    bindingSourceProfesseur.DataSource = new List<Professeur>();
                    view.DisableClasse();
                    bindingSourceClasse.DataSource = new List<Classe>();
                    view.DisableBtnEnregistrer();
                    MessageBox.Show("Aucun professeur disponible pour ce cours !", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void SelectProfesseurHandler(object sender, EventArgs e)
        {
            this.professeurSelected = view.ProfesseurSelected;
            //Charger Binding de classe en fonction des classes du prof et dispo
            if (professeurSelected!=null)//Test pour user bizarre
            {
                List<Classe> classes = classeService.getClasseDisponibles(moduleSelected, dateSelected, heureDebutSelected, heureFinSelected, professeurService.getClassesEnseigneesByProfesseurAndModule(professeurSelected.Id, moduleSelected));
                if (classes.Count > 0)
                {
                    bindingSourceClasse.DataSource = classes;
                    view.EnableClasse();
                }
                else
                {
                    //changement Prof
                    view.DisableClasse();
                    bindingSourceClasse.DataSource = new List<Classe>();
                    view.DisableBtnEnregistrer();
                    MessageBox.Show("Aucune Classe disponible pour ce cours !", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void SelectSalleHandler(object sender, EventArgs e)
        {
            salleSelected = view.SalleSelected;
            if (salleSelected != null)
            {
                view.DisableCodeCours();
                view.EnableBtnEnregistrer();
            }
            else
            {
                view.DisableBtnEnregistrer();
            }

        }

        public void SaisieCodeHandler(object sender, EventArgs e)
        {
            //Annuler bindingSource de salle 
            codeCoursSaisi = view.CodeCours;
            if (string.IsNullOrEmpty(codeCoursSaisi) && reactiveSalle)
            {
                view.EnableSalle();
                view.DisableBtnEnregistrer();
            }
            else
            {
                view.DisableSalle();
                view.EnableBtnEnregistrer();
            }
        }
    }
}
