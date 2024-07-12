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
using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.enums;
using Gestion_Etudiant.back.data.dto;

namespace Gestion_Cours.presenter.impl
{
    public class CoursPagePresenter : PagePresenter, ICoursPagePresenter
    {
        private readonly ICoursService coursService;
        private readonly IProfesseurService professeurService;
        private readonly IClasseService classeService;
        private readonly ICoursPage view;
        private readonly IMainWindows mainWindow;

        private CoursDto coursSelected;
        private UserDto userConnected;

        private BindingSource bindingSourceCours =  new BindingSource();
        private BindingSource bindingSourceProfesseur = new BindingSource();
        private BindingSource bindingSourceClasse = new BindingSource();

        public CoursPagePresenter(ICoursService coursService, IProfesseurService professeurService, IClasseService classeService, ICoursPage view,IMainWindows mainWindows):base(view, mainWindows)
        {
            this.coursService = coursService;
            this.professeurService = professeurService;
            this.classeService = classeService;
            this.view = view;
            this.mainWindow = mainWindows;
            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public CoursPagePresenter(ICoursService coursService, IProfesseurService professeurService, IClasseService classeService, ICoursPage view, IMainWindows mainWindows,UserDto userDto) : base(view, mainWindows, userDto)
        {
            this.coursService = coursService;
            this.professeurService = professeurService;
            this.classeService = classeService;
            this.view = view;
            this.view.UserName = userDto.NomComplet;
            this.mainWindow = mainWindows;
            LoadData();
            ActiveEventHandler();

            this.mainWindow.GetFrame.Navigate(view);
        }

        public void ActiveEventHandler()
        {
            view.SelectCoursEvent += SelectCoursHandler;
            view.ClickBtnAddEvent += AjouterCoursHandler;
            view.FiltreEvent += FiltreHandler;
            view.ClickBtnVoirClasse += VoirClasseHandler;
        }

        public void AjouterCoursHandler(object sender, EventArgs e)
        {
            IModuleService moduleService = FabriqueService.GetInstance(ServiceName.ModuleService) as IModuleService;

            ISalleService salleService = FabriqueService.GetInstance(ServiceName.SalleService) as ISalleService;

            ICoursAddPage coursAddPage = CoursAddPage.GetInstance();
            ICoursAddPagePresenter coursAddPagePresenter = new CoursAddPagePresenter(coursService, moduleService, professeurService, classeService, salleService, coursAddPage, mainWindow);
        }

        public void DeleteCoursHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                MessageBoxResult confirm = MessageBox.Show("Voulez-vous confirmer la suppression ?", "Confirmation Suppression !", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id = coursService.archivate(coursSelected.Id);

                        view.IsSuccessFul = id != 0;
                        if (view.IsSuccessFul)
                        {
                            bindingSourceCours.DataSource = coursService.getAll();//Recharger à nouveau les cours
                            view.Message = "Cours Supprimé avec succès";
                            view.Icone = MessageBoxImage.Information;
                            view.IsEdit = false;
                        }
                    }
                    catch (Exception)
                    {
                        view.IsSuccessFul = false;
                        view.Message = "Erreur de Suppression du cours";
                        view.Icone = MessageBoxImage.Error;
                    }
                }
                else
                {
                    view.IsSuccessFul = false;
                    view.Message = "Suppression du cours annulé !";
                    view.Icone = MessageBoxImage.Asterisk;
                }

            }
            else
            {
                view.Message = "Vueillez sélectionner le cours à Archiver";
                view.Icone = MessageBoxImage.Exclamation;
            }
        }

        public void FiltreHandler(object sender, EventArgs e)
        {
            Professeur professeur = view.ProfesseurSelected;
            Classe classe = view.ClasseSelected;
            
            if (professeur == null && classe != null)
            {
                bindingSourceCours.DataSource = coursService.getAllDtoByProfesseurAndClasse(0, classe.Id);
            }
            else if (classe == null && professeur!=null)
            {
                bindingSourceCours.DataSource = coursService.getAllDtoByProfesseurAndClasse(professeur.Id, 0);
            }
            else if((classe != null && classe.Id!=0) &&(professeur != null && professeur.Id != 0))
            {
                bindingSourceCours.DataSource = coursService.getAllDtoByProfesseurAndClasse(professeur.Id, classe.Id);
            }
            else
            {
                bindingSourceCours.DataSource = coursService.getAllDto();
            }
        }

        public void LoadData()
        {

            if (userConnected==null)
            {
                bindingSourceCours.DataSource = coursService.getAllDto();
            }
            else
            {
                bindingSourceCours.DataSource = coursService.getAllDtoByProfesseurAndClasse(userConnected.Id, 0);
            }
            List<Professeur> profs = new List<Professeur>();
            profs.Add(new Professeur() { Id = 0, NomComplet = "All" });
            profs.AddRange(professeurService.getAll());
            bindingSourceProfesseur.DataSource = profs;
            List<Classe> classes = new List<Classe>();
            classes.Add(new Classe() { Id = 0, Name = "All" });
            classes.AddRange(classeService.getAll());
            bindingSourceClasse.DataSource = classes;

            view.setCoursBindingSource(bindingSourceCours, bindingSourceProfesseur, bindingSourceClasse);
        }

        public void SelectCoursHandler(object sender, EventArgs e)
        {
            view.IsEdit = true;
            this.coursSelected = view.CoursSelected;
        }

        public void VoirClasseHandler(object sender, EventArgs e)
        {
            if (view.IsEdit == true)
            {
                BindingSource bindingSourceCoursClasse = new BindingSource();
                List<Classe> classes = coursService.getCoursClasses(coursSelected.Id);
                List<Classe> classesFinales = new List<Classe>();
                foreach (var cl in classes)
                {
                    classesFinales.Add(classeService.findById(cl.Id));
                }
                bindingSourceCoursClasse.DataSource = classesFinales;
                ICoursClasseWindow coursClasseWindow = CoursClasseWindow.GetInstance();
                coursClasseWindow.ShowWindow();
                coursClasseWindow.setClassesBindingSource(bindingSourceCoursClasse);

            }
            else
            {
                MessageBox.Show("Vueillez sélectionner le cours ", "INFOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
