using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.services;
using Gestion_Etudiant.back.services.impl;
using Gestion_Etudiant.front.views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.presenter.impl
{
    public class FormProfesseurPresenter : IFormProfesseurPresenter
    {
        private IProfesseurService professeurService;
        private IFormProfesseurView view;

        BindingSource bindingSourceProfesseur = new BindingSource();
        BindingSource bindingSourceGrade = new BindingSource();
        BindingSource bindingSourceFiltreGrade = new BindingSource();

        public FormProfesseurPresenter(IProfesseurService professeurService, IFormProfesseurView view)
        {
            this.professeurService = professeurService;
            this.view = view;
            LoadData();
            ActiveEventHandler();
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += AjouterProfesseurHandler;
            view.SelectProfesseurEvent += SelectProfesseurHandler;
            view.ClickBtnEditEvent += EditProfesseurHandler;
            view.ClickBtnDeleteEvent += DeleteProfesseurHandler;
        }

        public void AjouterProfesseurHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == false)
            {
                try
                {
                    Grade grade = view.GradeSelected;

                    string nomComplet = view.NomComplet;
                    string login = view.Login;
                    string password = view.Password;
                   
                    int id = professeurService.addProfesseur(new Professeur()
                    {
                        NomComplet = nomComplet,
                        Login = login,
                        Password = password,
                        Grade = grade,
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceProfesseur.DataSource = professeurService.getAllProfesseur();//Recharger à nouveau les classe
                        view.Message = "Professeur Ajouté avec succès";
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur d'ajout du professeur";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Editeur";
            }
        }

        public void DeleteProfesseurHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                try
                {
                    int id = professeurService.deleteProfesseur(view.ProfesseurId);

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceProfesseur.DataSource = professeurService.getAllProfesseur();//Recharger à nouveau les classe
                        view.Message = "Professeur Supprimé avec succès";
                        view.IsEdit = false;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de Suppression du professeur";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void EditProfesseurHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                try
                {
                    Grade grade = view.GradeSelected;

                    string nomComplet = view.NomComplet;
                    string login = view.Login;
                    string password = view.Password;
                    int id = professeurService.updateProfesseur(new Professeur()
                    {
                        Id = view.ProfesseurId,
                        NomComplet = nomComplet,
                        Login = login,
                        Password = password,
                        Grade = grade,
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceProfesseur.DataSource = professeurService.getAllProfesseur();//Recharger à nouveau les classe
                        view.Message = "Professeur modifié avec succès";
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de modification du professeur";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void LoadData()
        {
            bindingSourceProfesseur.DataSource = professeurService.getAllProfesseur();
            bindingSourceGrade.DataSource = professeurService.getAllGrade();
            bindingSourceFiltreGrade.DataSource = professeurService.getAllGrade();
            view.setProfesseurBindingSource(bindingSourceProfesseur, bindingSourceGrade, bindingSourceFiltreGrade);
        }

        public void SelectProfesseurHandler(object sender, EventArgs e)
        {
            view.IsEdit = true;
            DataRowView dataRowView = bindingSourceProfesseur.Current as DataRowView; //recup line
            DataRow row = dataRowView.Row;

            view.ProfesseurId = int.Parse(row.ItemArray[0].ToString());
            view.NomComplet = row.ItemArray[1].ToString();
            view.Login = row.ItemArray[2].ToString();
            view.GradeSelected = new Grade(){Name= row.ItemArray[3].ToString()};

            /*Professeur prof = bindingSourceProfesseur.Current as Professeur;
            view.ProfesseurId = prof.Id;
            view.NomComplet = prof.NomComplet;
            view.Login = prof.Login;
            view.GradeSelected = prof.Grade;*/
        }
    }
}
