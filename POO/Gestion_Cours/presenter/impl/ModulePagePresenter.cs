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

namespace Gestion_Cours.presenter.impl
{
    public class ModulePagePresenter : IModulePagePresenter
    {
        private readonly IModuleService moduleService;
        private readonly IModulePage view;
        private List<Module> bindingSourceModule = new List<Module>();
        private Module selectedModule;

        public ModulePagePresenter(IModuleService moduleService, IModulePage view)
        {
            this.moduleService = moduleService;
            this.view = view;
            ActiveEventHandler();
            LoadData();
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
                        bindingSourceModule = moduleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Module Ajouté avec succès";
                        view.Libelle = "";
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur d'ajout du module";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Editeur";
            }
        }

        public void DeleteModuleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Veuillez confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = moduleService.archivate(this.selectedModule.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceModule = moduleService.getAll();//Recharger à nouveau les classe
                            view.Message = "Module Supprimé avec succès";
                            view.IsEdit = false;

                            view.Libelle = "";
                            this.selectedModule = null;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression du module";
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression du module annulé !";
                }

            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
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
                        bindingSourceModule = moduleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Module modifié avec succès";
                        view.IsEdit = false;
                        view.Libelle = "";
                        this.selectedModule = null;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de modification du module";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void LoadData()
        {
            bindingSourceModule = moduleService.getAll();
            view.setClasseBindingSource(bindingSourceModule);
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
