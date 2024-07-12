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
using Gestion_Cours.back.data.dto;
using Gestion_Cours.front.views.window;
using Gestion_Cours.back.data.enums;

namespace Gestion_Cours.presenter.impl
{
    public class ProfesseurPagePresenter : PagePresenter, IProfesseurPagePresenter
    {
        private readonly IProfesseurService professeurService;
        private readonly IProfesseurPage view;
        private readonly IMainWindows mainWindow;

        private readonly IClasseService classeService;

        private Professeur professeurSelected;

        BindingSource bindingSourceProfesseur =  new BindingSource();
        BindingSource bindingSourceClasseEnseignee = new BindingSource();
        public ProfesseurPagePresenter(IProfesseurService professeurService, IProfesseurPage view,IMainWindows mainWindows, IClasseService classeService) :base(view,mainWindows)
        {
            this.professeurService = professeurService;
            this.view = view;
            this.classeService = classeService;
            this.mainWindow = mainWindows;

            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += AjouterProfesseurHandler;
            view.ClickBtnDeleteEvent += DeleteProfesseurHandler;
            view.ClickBtnEditEvent += EditProfesseurHandler;
            view.ClickBtnVoirClasse += VoirClasseHandler;
            view.FiltreEvent += FiltreHandler;
            view.SelectProfesseurEvent += SelectProfesseurHandler;
        }

        public void AjouterProfesseurHandler(object sender, EventArgs e)
        {
            //creer le presenter de professeurAddPage
            IClasseService classeService = FabriqueService.GetInstance(ServiceName.ClasseService) as IClasseService;
            IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;
            IProfesseurAddPage professeurAddPage = ProfesseurAddPage.GetInstance();
            IProfesseurAddPagePresenter professeurAddPagePresenter = new ProfesseurAddPagePresenter(professeurService,classeService,professeurAddPage,this.mainWindow);
        }

        public void DeleteProfesseurHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Voulez-vous confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = professeurService.archivate(this.professeurSelected.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceProfesseur.DataSource = professeurService.getAll();//Recharger à nouveau
                            view.Message = "Professeur Supprimée avec succès";
                            view.Icone = MessageBoxImage.Information;
                            view.IsEdit = false;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression du Professeur";
                        view.Icone = MessageBoxImage.Error;
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression du Professeur annulée !";
                    view.Icone = MessageBoxImage.Asterisk;
                }

            }
            else
            {
                view.Message = "Vueillez sélectionner le Professeur à Archiver";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void EditProfesseurHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;
                IProfesseurAddPage professeurAddPage = ProfesseurAddPage.GetInstance();
                IProfesseurAddPagePresenter professeurAddPagePresenter = new ProfesseurAddPagePresenter(professeurService, professeurAddPage, this.mainWindow,this.professeurSelected);
            }
            else
            {
                MessageBox.Show("Vueillez sélectionner le Professeur à Editer", "INFOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void FiltreHandler(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.Portable))
            {
                bindingSourceProfesseur.DataSource = professeurService.getProfesseurByPortable(view.Portable);
            }
            else
            {
                bindingSourceProfesseur.DataSource = professeurService.getAll();
            }
        }

        public void LoadData()
        {
            bindingSourceProfesseur.DataSource = professeurService.getAll();
            view.setProfeseurBindingSource(bindingSourceProfesseur);
        }

        public void SelectProfesseurHandler(object sender, EventArgs e)
        {
            view.IsEdit = true;
            this.professeurSelected = view.ProfesseurSelected;
        }

        public void VoirClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                IClasseWindow classeWindow = ClasseWindow.GetInstance();
                classeWindow.ShowWindow();
                classeWindow.Message = string.Format("Les Classes de {0}", professeurSelected.NomComplet);
                bindingSourceClasseEnseignee.DataSource = prepareDataForClasseWindow();
                classeWindow.setEnseignementBindingSource(bindingSourceClasseEnseignee);

            }
            else
            {
                MessageBox.Show("Vueillez d'abord sélectionner le Professeur", "INFOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

         private List<ClasseEnseigneeDto> prepareDataForClasseWindow()
        {
            List<ClasseEnseigneeDto> classeEnseigneeDtos = new List<ClasseEnseigneeDto>();
            List<Enseignement> enseignements = professeurService.getEnseignementsByProfesseur(professeurSelected.Id);
            foreach (var ens in enseignements)
            {
                classeEnseigneeDtos.Add(new ClasseEnseigneeDto()
                {
                    Id = ens.Id,
                    Name = ens.Classe.Name,
                    Effectif = ens.Classe.Effectif,
                    Niveau = ens.Classe.Niveau,
                    Filiere = ens.Classe.Filiere,
                    Modules = changeModuleListToString(professeurService.getModulesByEnseignement(ens.Id))
                }) ;
            }

            return classeEnseigneeDtos;
        }

        private string changeModuleListToString(List<Module> modules)
        {
            string strModules = "| ";
            foreach (var module in modules)
            {
                strModules += module.ToString();
                strModules += " | ";
            }
            return strModules;
        }
    }
}
