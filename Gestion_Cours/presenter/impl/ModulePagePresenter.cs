using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.services;
using Gestion_Cours.back.services.impl;
using Gestion_Cours.front.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Gestion_Cours.presenter.impl
{
    public class ModulePagePresenter : PagePresenter, IModulePagePresenter
    {
        private readonly IModuleService moduleService;
        private readonly IModulePage view;
        private readonly IMainWindows mainWindow;
        private BindingSource bindingSourceModule = new BindingSource();
        private Module selectedModule;

        public ModulePagePresenter(IModuleService moduleService, IModulePage view,IMainWindows mainWindows):base(view,mainWindows)
        {
            this.moduleService = moduleService;
            this.view = view;
            this.mainWindow = mainWindows;
            ActiveEventHandler();
            LoadData();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public void ActiveEventHandler()
        {
            view.SelectModuleEvent += SelectModuleHandler;
            view.ClickBtnAddEvent += AjouterModuleHandler;
            view.ClickBtnEditEvent += EditModuleHandler;
            view.ClickBtnDeleteEvent += DeleteModuleHandler;
        }

        public void AjouterModuleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == false)
            {

                try
                {
                    string libelle = view.Libelle;
                    int id = moduleService.add(new Module()
                    {
                        Name = libelle
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceModule.DataSource = moduleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Module Ajouté avec succès";
                        view.Icone = MessageBoxImage.Information;
                        view.Libelle = "";
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur d'ajout du module";
                    view.Icone = MessageBoxImage.Error;
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Editeur";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void DeleteModuleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Veuillez confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = moduleService.archivate(this.selectedModule.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceModule.DataSource = moduleService.getAll();//Recharger à nouveau les classe
                            view.Message = "Module Supprimé avec succès";
                            view.Icone = MessageBoxImage.Information;
                            view.IsEdit = false;

                            view.Libelle = "";
                            this.selectedModule = null;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression du module";
                        view.Icone = MessageBoxImage.Error;
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression du module annulé !";
                    view.Icone = MessageBoxImage.Information;
                }

            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void EditModuleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                try
                {

                    string libelle = view.Libelle;
                    int id = moduleService.update(new Module()
                    {
                        Id = this.selectedModule.Id,
                        Name = libelle,
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceModule.DataSource = moduleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Module modifié avec succès";
                        view.Icone = MessageBoxImage.Information;
                        view.IsEdit = false;
                        view.Libelle = "";
                        this.selectedModule = null;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de modification du module";
                    view.Icone = MessageBoxImage.Error;
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void LoadData()
        {
            bindingSourceModule.DataSource = moduleService.getAll();
            view.setModuleBindingSource(bindingSourceModule);
        }

        public void SelectModuleHandler(object sender, EventArgs e)
        {
            view.IsEdit = true;
            this.selectedModule = view.ModuleSelected;
            if (selectedModule != null)
            {
                view.Libelle = selectedModule.Name;
            }
        }
    }
}
