using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views;
using Gestion_Cours.front.views.page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gestion_Cours.presenter.impl
{
    class ClassePagePresenter:IClassePagePresenter
    {
       
        private IClasseService classeService;
        private IClassePage view;
        private List<Filiere> bindingSourceFiliere = new List<Filiere>();
        private List<Niveau> bindingSourceNiveau = new List<Niveau>();
        private List<Classe> bindingSourceClasse = new List<Classe>();

        public ClassePagePresenter(IClasseService classeService, IClassePage view)
        {
            this.classeService = classeService;
            this.view = view;
            LoadData();
            ActiveEventHandler();
        }

        public void ActiveEventHandler()
        {
            view.ClickBtnAddEvent += AjouterClasseHandler;
            view.SelectClasseEvent += SelectClasseHandler;
            view.ClickBtnEditEvent += EditClasseHandler;
            view.ClickBtnDeleteEvent += DeleteClasseHandler;
            view.FiltreEvent += FiltreHandler;
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
                    int id = classeService.add(new Classe()
                    {
                        Name = nomClasse,
                        Niveau = niveau,
                        Filiere = filiere
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceClasse = classeService.getAll();//Recharger à nouveau les classe
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
                MessageBoxResult confirm = MessageBox.Show("Veuillez confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = classeService.archivate(view.ClasseId);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceClasse = classeService.getAll();//Recharger à nouveau les classe
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
                    int id = classeService.update(new Classe()
                    {
                        Id = view.ClasseId,
                        Name = nomClasse,
                        Niveau = niveau,
                        Filiere = filiere
                    });

                    view.IsSuccessFul = id != 0;
                    if (view.IsSuccessFul)
                    {
                        bindingSourceClasse = classeService.getAll();//Recharger à nouveau les classe
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

        public void FiltreHandler(object sender, EventArgs e)
        {
            Filiere filiere = view.FiliereSelected;
            Niveau niveau = view.NiveauSelected;
            if (filiere == null)
            {
                //view.Message = niveau.Id.ToString();
                bindingSourceClasse.Clear();
                bindingSourceClasse.AddRange(classeService.getAllByNiveauAndFiliere(niveau.Id, 0));
            }
            else if (niveau == null)
            {
                //view.Message = filiere.Id.ToString();
                bindingSourceClasse.Clear();
                bindingSourceClasse = classeService.getAllByNiveauAndFiliere(0, filiere.Id);
            }
            else
            {
                //view.Message = String.Format(" {0}  {1}", niveau.Id, filiere.Id);
                bindingSourceClasse.Clear();
                bindingSourceClasse = classeService.getAllByNiveauAndFiliere(niveau.Id, filiere.Id);
            }
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                this.view.setClasseBindingSource(bindingSourceClasse, bindingSourceFiliere, bindingSourceNiveau);
            }));
        }


        public void LoadData()
        {
            bindingSourceFiliere.Add(new Filiere() { Id = 0, Name = "ALL" });
            bindingSourceFiliere.AddRange(classeService.getAllFiliere());
            bindingSourceNiveau.Add(new Niveau() { Id = 0, Name = "ALL" });
            bindingSourceNiveau.AddRange(classeService.getAllNiveau());
            bindingSourceClasse = bindingSourceClasse = classeService.getAllByNiveauAndFiliere(1,2);
            this.view.setClasseBindingSource(bindingSourceClasse, bindingSourceFiliere, bindingSourceNiveau);

        }

        public void SelectClasseHandler(object sender, EventArgs e)
        {

            view.IsEdit = true;
            Classe classe = view.ClasseSelected;
            view.Message = classe.ToString();

            //DataRowView dataRowView = bindingSourceClasse.Current as DataRowView; //recup line
            //DataRow row = dataRowView.Row; // recup line data 

            //view.ClasseId = int.Parse(row.ItemArray[0].ToString());
            //view.NiveauSelected = new Niveau() { Name= row.ItemArray[2].ToString()};
            //view.FiliereSelected = new Filiere() { Name = row.ItemArray[3].ToString() };

            //String name = row.ItemArray[1].ToString();
            //int foundS1 = name.LastIndexOf(" ");
            //view.Code = name.Remove(0, foundS1);

            //Classe classe = view.ClasseSelected as Classe;

            //view.ClasseId = classe.Id;
            //view.NiveauSelected = classe.Niveau;
            //view.FiliereSelected = classe.Filiere;

            //String name = classe.Name;
            //int foundS1 = name.LastIndexOf(" ");
            //view.Code = name.Remove(0, foundS1);


            /*char[] delimiter = { ' '};
            
            string[] strList = CustomString //dataRowView["id"].ToString().Split(delimiter);
            if (strList.Length == 3)
            {
                view.Code = strList[1];
            }*/
        }
    }
}