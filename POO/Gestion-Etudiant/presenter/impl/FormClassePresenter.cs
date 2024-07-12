using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.services;
using Gestion_Etudiant.front.views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Gestion_Etudiant.presenter.impl
{
    public class FormClassePresenter:IFormClassePresenter
    {
        private IClasseService classeService;
        private IFormClasseView view;

        private BindingSource bindingSourceFiliere = new BindingSource();
        private BindingSource bindingSourceNiveau = new BindingSource();
        private BindingSource bindingSourceClasse = new BindingSource();

        public FormClassePresenter(IClasseService classeService, IFormClasseView view)
        {
            this.classeService = classeService;
            this.view = view;
            LoadData();
            ActiveEventHandler();
            this.view.ShowForm();
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += AjouterClasseHandler;
            view.SelectClasseEvent += SelectClasseHandler;
            view.ClickBtnEditEvent += EditClasseHandler;
            view.ClickBtnDeleteEvent += DeleteClasseHandler;
        }

        public void AjouterClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == false)
            {
                /*Niveau niveau = new Niveau()
                {
                    Id = (int)view.Niv["id"],
                    Name = view.Niv["name"].ToString()
                };
                view.Message = string.Format("{0} OKAY", niveau.Name);*/
                try
                 {
                    Filiere filiere = view.FiliereSelected;

                    Niveau niveau = view.NiveauSelected;
                    string code = view.Code;
                    string nomClasse = string.Format("{0} {1} {2}", niveau.Name, filiere.Name, code);
                    int id = classeService.addClasse(new Classe()
                    {
                        Name = nomClasse,
                        Niveau = niveau,
                        Filiere = filiere
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceClasse.DataSource = classeService.getAllClasse();//Recharger à nouveau les classe
                        view.Message = "Classe Ajoutéé avec succès";
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

        public void DeleteClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                DialogResult confirm = MessageBox.Show("Veuillez confirmer la suppression ?","Confirmation Suppression !",MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        int id = classeService.deleteClasse(view.ClasseId);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceClasse.DataSource = classeService.getAllClasse();//Recharger à nouveau les classe
                            view.Message = "Classe Supprimée avec succès";
                            view.IsEdit = false;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression de la classe";
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression de la classe annulée !";
                }
               
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void EditClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                try
                {
                    Filiere filiere = view.FiliereSelected;

                    Niveau niveau = view.NiveauSelected;
                    string code = view.Code;
                    string nomClasse = string.Format("{0} {1} {2}", niveau.Name, filiere.Name, code);
                    int id = classeService.updateClasse(new Classe()
                    {
                        Id = view.ClasseId,
                        Name = nomClasse,
                        Niveau = niveau,
                        Filiere = filiere
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceClasse.DataSource = classeService.getAllClasse();//Recharger à nouveau les classe
                        view.Message = "Classe modifiée avec succès";
                        view.IsEdit = false;
                    }
                }
                catch (Exception)
                {
                    view.IsSuccessFul = false;
                    view.Message = "Erreur de modification de la classe";
                }
            }
            else
            {
                view.Message = "Vous êtes en mode Ajout";
            }
        }

        public void LoadData()
        {
            bindingSourceFiliere.DataSource = classeService.getAllFiliere();
            bindingSourceNiveau.DataSource = classeService.getAllNiveau();
            bindingSourceClasse.DataSource = classeService.getAllClasse();
            this.view.setClasseBindingSource(bindingSourceClasse, bindingSourceFiliere, bindingSourceNiveau);
        }

        public void SelectClasseHandler(object sender, EventArgs e)
        {
            
            view.IsEdit = true;
            DataRowView dataRowView = bindingSourceClasse.Current as DataRowView; //recup line
            DataRow row = dataRowView.Row; // recup line data 

            view.ClasseId = int.Parse(row.ItemArray[0].ToString());
            view.NiveauSelected = new Niveau() { Name= row.ItemArray[2].ToString()};
            view.FiliereSelected = new Filiere() { Name = row.ItemArray[3].ToString() };

            String name = row.ItemArray[1].ToString();
            int foundS1 = name.LastIndexOf(" ");
            view.Code = name.Remove(0, foundS1);

            /*Classe classe = bindingSourceClasse.Current as Classe;

            view.ClasseId = classe.Id;
            view.NiveauSelected = classe.Niveau;
            view.FiliereSelected = classe.Filiere;

            String name = classe.Name;
            int foundS1 = name.LastIndexOf(" ");
            view.Code = name.Remove(0, foundS1);*/


            /*char[] delimiter = { ' '};
            
            string[] strList = CustomString //dataRowView["id"].ToString().Split(delimiter);
            if (strList.Length == 3)
            {
                view.Code = strList[1];
            }*/
        }
    }
}
