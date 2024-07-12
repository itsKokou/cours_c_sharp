using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories.impl;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.services;
using Gestion_Cours.back.services.impl;
using Gestion_Cours.front.views;
using Gestion_Cours.front.views.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Gestion_Cours.front.views.window;
using Gestion_Cours.back.data.enums;
using Gestion_Etudiant.back.data.dto;

namespace Gestion_Cours.presenter.impl
{
    class ClassePagePresenter: PagePresenter ,IClassePagePresenter
    {
       
        private IClasseService classeService;
        private IClassePage view;
        private readonly IMainWindows mainWindow;
        private Classe classeSelected;
        private BindingSource bindingSourceFiliere = new BindingSource();
        private BindingSource bindingSourceNiveau = new BindingSource();
        private BindingSource bindingSourceClasse = new BindingSource();

        public ClassePagePresenter(IClasseService classeService, IClassePage view,IMainWindows mainWindow):base(view, mainWindow)
        {
            this.classeService = classeService;
            this.view = view;
            this.mainWindow = mainWindow;
            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }
        public ClassePagePresenter(IClasseService classeService, IClassePage view,IMainWindows mainWindow, UserDto userDto):base(view, mainWindow,userDto)
        {
            this.classeService = classeService;
            this.view = view;
            view.UserName = userDto.NomComplet;
            this.mainWindow = mainWindow;
            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += AjouterClasseHandler;
            view.SelectClasseEvent += SelectClasseHandler;
            view.ClickBtnEditEvent += EditClasseHandler;
            view.ClickBtnDeleteEvent += DeleteClasseHandler;
            view.FiltreEvent += FiltreHandler;
            view.ClickBtnVoirModule += VoirModulesHandler;
        }

        public void AjouterClasseHandler(object sender, EventArgs e)
        {
            IClasseAddPage classeAddView = ClasseAddPage.GetInstance();
            IModuleService moduleService = FabriqueService.GetInstance(ServiceName.ModuleService) as IModuleService;
            IClasseAddPagePresenter classeAddPagePresenter = new ClasseAddPagePresenter(this.classeService,classeAddView,moduleService,this.mainWindow);
        }

        public void DeleteClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Voulez-vous confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = classeService.archivate(this.classeSelected.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceClasse.DataSource = classeService.getAll();//Recharger à nouveau les classe
                            view.Message = "Classe Supprimée avec succès";
                            view.Icone = MessageBoxImage.Information;
                            view.IsEdit = false;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression de la classe";
                        view.Icone = MessageBoxImage.Error;
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression de la classe annulée !";
                    view.Icone = MessageBoxImage.Asterisk;
                }

            }
            else
            {
                view.Message = "Vueillez sélectionner la classe à Archiver";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void EditClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                IClasseAddPage classeAddView = ClasseAddPage.GetInstance();
                IClasseAddPagePresenter classeAddPagePresenter = new ClasseAddPagePresenter(this.classeService, classeAddView, this.mainWindow,this.classeSelected);
            }
            else
            {
                MessageBox.Show("Vueillez sélectionner la classe à Editer", "INFOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void FiltreHandler(object sender, EventArgs e)
        {
            Filiere filiere = view.FiliereSelected;
            Niveau niveau = view.NiveauSelected;
            if (filiere == null && niveau!=null)
            {
                //view.Message = niveau.Id.ToString();
                bindingSourceClasse.DataSource = classeService.getAllByNiveauAndFiliere(niveau.Id, 0);
            }
            else if (niveau == null && filiere!=null)
            {
                //view.Message = filiere.Id.ToString();
                bindingSourceClasse.DataSource = classeService.getAllByNiveauAndFiliere(0, filiere.Id);
            }
            else if(niveau != null && filiere != null)
            {
                //view.Message = String.Format(" {0}  {1}", niveau.Id, filiere.Id);
                bindingSourceClasse.DataSource = classeService.getAllByNiveauAndFiliere(niveau.Id, filiere.Id);
            }
            else
            {
                bindingSourceClasse.DataSource = classeService.getAll();
            }
            
        }

        public void VoirModulesHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                
                IModuleWindow moduleWindow = ModuleWindow.GetInstance();
                moduleWindow.ShowWindow();
                moduleWindow.Message = string.Format("Les Modules de {0}", classeSelected.Name);
                BindingSource bindingSourceClasseModules = new BindingSource();
                if (userConnected==null)
                {
                    bindingSourceClasseModules.DataSource = classeService.getClasseModules(classeSelected.Id);
                }
                else
                {
                    IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;
                    List<Enseignement> enseignements = professeurService.getEnseignementsByProfesseur(userConnected.Id);
                    List<Module> modules = new List<Module>();
                    foreach (var ens in enseignements)
                    {
                        if (ens.Classe.Id == classeSelected.Id)
                        {
                            modules.AddRange(professeurService.getModulesByEnseignement(ens.Id));
                        }
                    }
                    bindingSourceClasseModules.DataSource = modules;
                }
                moduleWindow.setModuleBindingSource(bindingSourceClasseModules);
                view.IsEdit = false;
                
            }
            else
            {
                MessageBox.Show("Vueillez sélectionner la classe ", "INFOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        public void LoadData()
        {
            if (userConnected ==null)
            {
                List<Filiere> listFiliere = new List<Filiere>();
                listFiliere.Add(new Filiere() { Id = 0, Name = "ALL" });
                listFiliere.AddRange(classeService.getAllFiliere());
                bindingSourceFiliere.DataSource = listFiliere;
                List<Niveau> listNiveau = new List<Niveau>();
                listNiveau.Add(new Niveau() { Id = 0, Name = "ALL" });
                listNiveau.AddRange(classeService.getAllNiveau());
                bindingSourceNiveau.DataSource = listNiveau;
                bindingSourceClasse.DataSource = classeService.getAll();
            }
            else
            {
                IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;
                bindingSourceClasse.DataSource = professeurService.getClassesEnseigneesByProfesseur(userConnected.Id);
            }
                this.view.setClasseBindingSource(bindingSourceClasse, bindingSourceFiliere, bindingSourceNiveau);


        }

        public void SelectClasseHandler(object sender, EventArgs e)
        {

            view.IsEdit = true;
            this.classeSelected = view.ClasseSelected;
        }

    }
}