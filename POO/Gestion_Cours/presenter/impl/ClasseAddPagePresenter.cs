using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter.impl
{
    public class ClasseAddPagePresenter : IClasseAddPagePresenter
    {
        private readonly IClasseService classeService;
        private readonly IClasseAddPage view;
        private List<Filiere> bindingSourceFiliere = new List<Filiere>();
        private List<Niveau> bindingSourceNiveau = new List<Niveau>();

        public ClasseAddPagePresenter(IClasseService classeService, IClasseAddPage view)
        {
            this.classeService = classeService;
            this.view = view;
            LoadData();
            ActiveEventHandler();
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
            int effectif = view.Effectif;
            string libelle = view.Libelle;
            if (niveau == null) {
                view.Message = "Veuillez choisir un niveau";
            }else if (filiere == null)
            {
                view.Message = "Veuillez choisir une filiere";
            }else if (effectif == 0)
            {
                view.Message = "Veuillez entrer l'effectif de la classe";
            }
            else
            {
                view.Message = libelle;
                try
                {

                    int id = classeService.add(new Classe()
                    {
                        Name = libelle,
                        Niveau = niveau,
                        Filiere = filiere,
                        Effectif = effectif
                    });
                   

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                        view.Message = "Classe Ajoutéé avec succès";
                }

                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur d'ajout de la classe";
                }
            }

        }

        public void LoadData()
        {
            bindingSourceFiliere = classeService.getAllFiliere();
            bindingSourceNiveau = classeService.getAllNiveau();
            this.view.setClasseBindingSource(bindingSourceFiliere, bindingSourceNiveau);
        }

        public void SelectFiliereHandler(object sender, EventArgs e)
        {
            Niveau niveau = view.NiveauSelected;
            Filiere filiere = view.FiliereSelected;

            if (niveau !=null)
            {
                view.Libelle = String.Format("{0} {1}",niveau.Name, filiere.Name);
            }
        }
    }
}
