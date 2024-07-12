using Gestion_Cours.back.data.repositories.impl;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.services.impl;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views;
using Gestion_Cours.front.views.page;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gestion_Cours.presenter;
using Gestion_Cours.presenter.impl;

namespace Gestion_Cours
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsMaximize = false;

       

        public MainWindow()
        {
            InitializeComponent();
            

            //Affichage Classe
            IClassePage classeView = new ClassePage();
            IFiliereRepository filiereRepository = new FiliereRepository();
            INiveauRepository niveauRepository = new NiveauRepository();
            IClasseRepository classeRepository = new ClasseRepository();
            IClasseService classeService = new ClasseService(classeRepository,niveauRepository, filiereRepository);
            IClassePagePresenter classePagePresenter = new ClassePagePresenter(classeService, classeView);

            //Affichage de ajout classe
            IClasseAddPage classeAddView = new ClasseAddPage();
            IClasseAddPagePresenter classeAddPagePresenter = new ClasseAddPagePresenter(classeService, classeAddView);

            //Affichage Salle
            ISalleRepository salleRepository = new SalleRepository();
            ISalleService salleService = new SalleService(salleRepository);
            ISallePage salleView = new SallePage();
            ISallePagePresenter sallePagePresenter = new SallePagePresenter(salleView, salleService);

            //Affichage Module
            IModuleRepository moduleRepository = new ModuleRepository();
            IModuleService moduleService = new ModuleService(moduleRepository);
            IModulePage moduleView = new ModulePage();
            IModulePagePresenter modulePagePresenter = new ModulePagePresenter(moduleService,moduleView);

            MainFrame.Navigate(classeView);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

   
}