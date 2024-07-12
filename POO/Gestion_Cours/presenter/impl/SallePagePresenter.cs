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
    public class SallePagePresenter : ISallePagePresenter
    {
        private readonly ISallePage view;
        private readonly ISalleService salleService;
        private List<Salle>bindingSourceSalle = new List<Salle>();
        private Salle selectedSalle;

        public SallePagePresenter(ISallePage view, ISalleService salleService)
        {
            this.view = view;
            this.salleService = salleService;
            LoadData();
            ActiveEventHandler();
        }

        public void ActiveEventHandler()
        {
            view.SelectSalleEvent += SelectSalleHandler;
            view.ClickBtnAddEvent += AjouterSalleHandler;
            view.ClickBtnEditEvent += EditSalleHandler;
            view.ClickBtnDeleteEvent += DeleteSalleHandler;
        }

        public void AjouterSalleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == false)
            {
               
                try
                {
                    string libelle = view.Libelle;
                    int nbrePlace = view.NbrePlace;
                    int id = salleService.add(new Salle()
                    {
                        Name = libelle,
                        NbrePlace = nbrePlace
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceSalle = salleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Salle Ajoutéé avec succès";
                        view.Libelle = "";
                        view.NbrePlace = 0;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur d'ajout de la classe";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Editeur";
            }
        }

        public void DeleteSalleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Veuillez confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = salleService.archivate(this.selectedSalle.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceSalle = salleService.getAll();//Recharger à nouveau les classe
                            view.Message = "Salle Supprimée avec succès";
                            view.IsEdit = false;

                            view.Libelle = "";
                            view.NbrePlace = 0;
                            this.selectedSalle = null;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression de la salle";
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression de la salle annulée !";
                }

            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void EditSalleHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                try
                {
                   
                    string libelle = view.Libelle;
                    int nbrePlace = view.NbrePlace;
                    int id = salleService.update(new Salle()
                    {
                        Id = this.selectedSalle.Id,
                        Name = libelle,
                        NbrePlace = nbrePlace,
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceSalle = salleService.getAll();//Recharger à nouveau les classe
                        view.Message = "Salle modifiée avec succès";
                        view.IsEdit = false;
                        view.Libelle = "";
                        view.NbrePlace = 0;
                        this.selectedSalle = null;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de modification de la salle";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void LoadData()
        {
            bindingSourceSalle = salleService.getAll();
            view.setClasseBindingSource(bindingSourceSalle);
        }

        public void SelectSalleHandler(object sender, EventArgs e)
        {
            view.IsEdit = true;
            this.selectedSalle = view.SalleSelected;
            if (selectedSalle != null)
            {
                view.Libelle = selectedSalle.Name;
                view.NbrePlace = selectedSalle.NbrePlace;
            }
        }
    }
}
