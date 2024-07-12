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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using MessageBox = System.Windows.MessageBox;

namespace Gestion_Cours.presenter.impl
{
    public class ProfesseurAddPagePresenter : PagePresenter ,IProfesseurAddPagePresenter
    {
        private readonly IProfesseurService professeurService;
        private readonly IClasseService classeService;
        private readonly IProfesseurAddPage view;
        private readonly IMainWindows mainWindow;

        private Professeur professeurSelected;
        private Classe classeSelected;

        private BindingSource bindingSourceClasse = new BindingSource();
        private BindingSource bindingSourceModule = new BindingSource();
        
        private List<Enseignement> enseignements = new List<Enseignement>();

        public ProfesseurAddPagePresenter(IProfesseurService professeurService, IClasseService classeService, IProfesseurAddPage view, IMainWindows mainWindow):base(view, mainWindow)
        {
            this.professeurService = professeurService;
            this.classeService = classeService;
            this.view = view;
            this.mainWindow = mainWindow;
            this.mainWindow.GetFrame.Navigate(view);
            LoadData();
            ActiveEventHandler();
        }

        public ProfesseurAddPagePresenter(IProfesseurService professeurService,IProfesseurAddPage view, IMainWindows mainWindow, Professeur professeurSelected) : base(view, mainWindow)
        {
            this.professeurService = professeurService;
            this.view = view;
            this.mainWindow = mainWindow;
            
            this.professeurSelected = professeurSelected;
           
            ActiveEventHandler();

            //Dès que c'est Edit, charger les infos
            view.NomComplet = professeurSelected.NomComplet;
            view.Login = professeurSelected.Login;
            view.Portable = professeurSelected.Portable;

            this.mainWindow.GetFrame.Navigate(view);
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnSaveEvent += SaveProfesseurHandler;
            view.ClickBtnAddEnseignementEvent += AjouterEnseignementHandler;
            view.SelectClasseEvent += SelectClasseHandler;
        }

        public void AjouterEnseignementHandler(object sender, EventArgs e)
        {
            if (professeurSelected==null)
            {
                if (view.ClasseSelected == null)
                {
                    view.Message = "Veuillez choisir une classe !";
                    view.Icone = MessageBoxImage.Warning;
                }
                else
                {
                    List<Module> modulesChoisis = view.ModulesSelected;
                    if (modulesChoisis == null || modulesChoisis.Count == 0)
                    {
                        view.Message = "Veuillez choisir au moins un module à enseigner";
                        view.Icone = MessageBoxImage.Warning;
                    }
                    else
                    {
                        this.enseignements.Add(new Enseignement()
                        {
                            Classe = view.ClasseSelected,
                            Modules = modulesChoisis,
                        });
                        view.Message = "Classe Ajoutée avec succès pour enseignement ";
                        view.Icone = MessageBoxImage.Information;
                        this.classeSelected = view.ClasseSelected;//Sauvegarder la classe avant de recharger
                        bindingSourceClasse.DataSource = this.getClassesNonEnseignees();//recharger classe

                    }
                }
            }
            else
            {
                view.Message = "Fonctionalité non accessible en mode Edition !";
                view.Icone = MessageBoxImage.Warning;
            }
        }

        public void LoadData()
        {
            bindingSourceClasse.DataSource = this.getClassesNonEnseignees();
            view.setProfesseurClasseAndModuleBindingSource(bindingSourceClasse, bindingSourceModule);
        }

        public void SaveProfesseurHandler(object sender, EventArgs e)
        {
            string nomComplet = view.NomComplet;
            string portable = view.Portable;
            string login = view.Login;
            string password = view.Password;

            if (string.IsNullOrEmpty(nomComplet))
            {
                view.Message = "Veuillez saisir le nom et prénoms du professeur";
                view.Icone = MessageBoxImage.Warning;

            }
            else if (string.IsNullOrEmpty(portable))
            {
                view.Message = "Veuillez saisir son numero de téléphone";
                view.Icone = MessageBoxImage.Warning;
            }
            else
            {
                if (string.IsNullOrEmpty(login))
                {
                    view.Message = "Veuillez saisir le Login";
                    view.Icone = MessageBoxImage.Warning;
                }
                else if (!login.Contains('@') || !login.Contains(".com"))
                {
                    view.Message = "Le Login doit être un Email";
                    view.Icone = MessageBoxImage.Warning;
                }
                else if (string.IsNullOrEmpty(password) || password.Length <= 4)
                {
                    view.Message = "Veuillez saisir un mot de passe valide";
                    view.Icone = MessageBoxImage.Warning;
                }
                else
                {
                    try
                    {
                        int id = 0;
                        if (professeurSelected == null)
                        {  
        
                            if (enseignements == null || enseignements.Count == 0)
                            {
                                view.Message = "Veuillez entrer au moins une classe pour ce professeur !";
                                view.Icone = MessageBoxImage.Warning;
                            }
                            else
                            {
                               
                                id = professeurService.add(new Professeur()
                                {
                                    NomComplet = nomComplet,
                                    Portable = portable,
                                    Login = login,
                                    Password = password,
                                    Enseignements = enseignements
                                }) ;

                            }
                        }
                        else
                        {
                            id = professeurService.update(new Professeur()
                            {
                                Id = professeurSelected.Id,
                                NomComplet = nomComplet,
                                Portable = portable,
                                Login = login,
                                Password = password,
                            });
                        }

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            view.Message = "Professeur Enrégistré avec succès";
                            view.Icone = MessageBoxImage.Information;
                            //view.NomComplet = "";
                            //view.Login = "";
                            //view.Portable = "";
                            //this.enseignements = new List<Enseignement>();
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur d'enrégistrement du professeur";
                        view.Icone = MessageBoxImage.Error;
                    }
                }

            }
        }

        public void SelectClasseHandler(object sender, EventArgs e)
        {
            //Charger les modules non enseigner
            if (view.ClasseSelected!=null)
            {
                this.classeSelected = view.ClasseSelected;
                bindingSourceModule.DataSource = getModulesNonEnseignes(this.classeSelected);
            }
            else
            {
                bindingSourceModule.DataSource = new List<Module>();//Vider les modules
            }
        }

        //Verifie si classe est déjà choisie
        //Recuperer les modules de classe pour voir si elle en a :::::: fonction existante
        //Si oui, charger module
        //professeurService.findModulesEnseignesByClasse(classe.getId());
        //modules.size()==modulesEnseignes.size()
        
        private List<Module> getModulesEnseignes(Classe classe)
        {
            List<Enseignement> classesEnseignees = professeurService.getEnseignementsByClasse(classe.Id);
            List<Module> modulesenseignes = new List<Module>();
            foreach (var item in classesEnseignees)
            {
                modulesenseignes.AddRange(professeurService.getModulesByEnseignement(item.Id));
            }
            return modulesenseignes;
        }

        private List<Module> getModulesNonEnseignes(Classe classe)
        {
            List<Module> modules = classeService.getClasseModules(classe.Id);
            List<Module> modulesEnseignes = getModulesEnseignes(classe);
            List<Module> modulesNonEnseignes = new List<Module>();
            foreach (var mod in modules)
            {
                bool choix = false;
                foreach (var me in modulesEnseignes)
                {
                    if(mod.Id == me.Id)
                    {
                        choix = true;
                    }
                }
                if (!choix)
                {
                    modulesNonEnseignes.Add(mod);
                }
            }
            return modulesNonEnseignes;
        }

        private List<Classe> getClassesNonEnseignees()
        {
            List<Classe> classes = classeService.getAll();
            List<Classe> classesNonEnseignes = new List<Classe>();
            List<Module> modules = new List<Module>();
            List<Module> modulesEnseignes = new List<Module>();
            foreach (var classe in classes)
            {
                modules = classeService.getClasseModules(classe.Id);
                modulesEnseignes = getModulesEnseignes(classe);
                if (modules.Count > modulesEnseignes.Count && checkClasseInClassesEnseignees(this.enseignements,classe)==-1)
                {
                    classesNonEnseignes.Add(classe);
                }
            }
            return classesNonEnseignes;
        }

        private int checkClasseInClassesEnseignees(List<Enseignement> classesEnseignees, Classe classe)
        {
            foreach (var ens in classesEnseignees)
            {
                if (ens.Classe.Id == classe.Id)
                {
                    return classe.Id;
                }
            }
            return -1;
        }
    }
}
