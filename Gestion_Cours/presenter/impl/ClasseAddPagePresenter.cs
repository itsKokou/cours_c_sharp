using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Gestion_Cours.presenter.impl
{
    public class ClasseAddPagePresenter : PagePresenter, IClasseAddPagePresenter
    {
        private readonly IClasseService classeService;
        private readonly IModuleService moduleService;
        private readonly IClasseAddPage view;
        private readonly IMainWindows mainWindow;
        private  Classe classeSelected;
        private BindingSource bindingSourceFiliere = new BindingSource();
        private BindingSource bindingSourceNiveau = new BindingSource();
        private BindingSource bindingSourceModule =  new BindingSource();

        public ClasseAddPagePresenter(IClasseService classeService, IClasseAddPage view, IModuleService moduleService, IMainWindows mainWindows):base(view,mainWindows)
        {
            this.classeService = classeService;
            this.moduleService = moduleService;
            this.view = view;
            this.mainWindow = mainWindows;
            this.classeSelected = null;
            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public ClasseAddPagePresenter(IClasseService classeService, IClasseAddPage view, IMainWindows mainWindows, Classe classeSelected):base(view,mainWindows)
        {
            this.classeService = classeService;
            this.view = view;
            this.mainWindow = mainWindows;
            //Dès que c'est Edit, charger les infos
            this.classeSelected = classeSelected;
            this.view.NiveauSelected = classeSelected.Niveau;
            this.view.FiliereSelected = classeSelected.Filiere; 
            this.view.Libelle = classeSelected.Name;
            this.view.Effectif = classeSelected.Effectif.ToString();

            bindingSourceFiliere.DataSource = classeService.getAllFiliere();
            bindingSourceNiveau.DataSource = classeService.getAllNiveau();
            bindingSourceModule.DataSource = new List<Module>();
            this.view.setClasseBindingSource(bindingSourceFiliere, bindingSourceNiveau, bindingSourceModule);

            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }
        public void ActiveEventHandler()
        {
            view.SelectFiliereEvent += SelectFiliereHandler;
            view.ClickBtnSaveEvent += AjouterClasseHandler;
        }

        public void AjouterClasseHandler(object sender, EventArgs e)
        {
            
            Filiere filiere = view.FiliereSelected;
            Niveau niveau = view.NiveauSelected;
            string libelle = view.Libelle;
            //Niv et Fil ne charge pas donc on force
            if (classeSelected!=null)
            {
                filiere = classeSelected.Filiere;
                niveau = classeSelected.Niveau;
            }

            if (niveau == null)
            {
                view.Message = "Veuillez choisir un niveau";
                view.Icone = MessageBoxImage.Warning;

            }
            else if (filiere == null)
            {
                view.Message = "Veuillez choisir une filiere";
                view.Icone = MessageBoxImage.Warning;
            }
            else
            {
                string strEffectif = view.Effectif;
                if (string.IsNullOrEmpty(strEffectif))
                {
                    view.Message = "Veuillez entrer un effectif pour la classe";
                    view.Icone = MessageBoxImage.Warning;
                }
                else
                {
                    int effectif;
                    try
                    {
                        effectif = Convert.ToInt32(strEffectif);
                        try
                        {
                            int id = 0;
                            if (classeSelected == null)
                            {
                                List<Module> listeModule = view.ModulesSelected;
                                if (listeModule.Equals(null) || listeModule.Count == 0)
                                {
                                    view.Message = "Veuillez entrer au moins un module pour cette classe !";
                                    view.Icone = MessageBoxImage.Warning;
                                }
                                else
                                {

                                    id = classeService.add(new Classe()
                                    {
                                        Name = libelle,
                                        Niveau = niveau,
                                        Filiere = filiere,
                                        Effectif = effectif,
                                        Modules = listeModule
                                    });
                                    
                                }
                            }
                            else
                            {
                                id = classeService.update(new Classe()
                                {
                                    Id = classeSelected.Id,
                                    Name = libelle,
                                    Niveau = niveau,
                                    Filiere = filiere,
                                    Effectif = effectif
                                });
                                //vider les champs
                                this.classeSelected = null;
                                this.view.NiveauSelected = null;
                                this.view.FiliereSelected = null;
                                this.view.Libelle = "";
                                this.view.Effectif = "";
                            }

                            view.IsSuccessFul = id != 0;
                            if (view.IsSuccessFul)
                            {
                                view.Message = "Classe Enrégistrée avec succès";
                                view.Icone = MessageBoxImage.Information;
                            }
                        }
                        catch (Exception)
                        {
                            view.IsSuccessFul = false;
                            view.Message = "Erreur d'enrégistrement de la classe";
                            view.Icone = MessageBoxImage.Error;
                        }
                    }
                    catch (Exception)
                    {
                        view.Message = "Veuillez entrer un effectif valide !";
                        view.Icone = MessageBoxImage.Warning;
                    }
                }
                
            }

        }

        public void LoadData()
        {
            bindingSourceFiliere.DataSource = classeService.getAllFiliere();
            bindingSourceNiveau.DataSource = classeService.getAllNiveau();
            bindingSourceModule.DataSource = moduleService.getAll();
            this.view.setClasseBindingSource(bindingSourceFiliere, bindingSourceNiveau,bindingSourceModule);
        }

        public void SelectFiliereHandler(object sender, EventArgs e)
        {
            Niveau niveau = view.NiveauSelected;
            Filiere filiere = view.FiliereSelected;

            if (niveau !=null && filiere !=null)
            {
                view.Libelle = String.Format("{0} {1}",niveau.Name, filiere.Name);
            }
        }
    }
}
