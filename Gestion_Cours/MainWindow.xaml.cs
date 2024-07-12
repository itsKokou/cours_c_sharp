using Gestion_Cours.back.data.repositories.impl;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.services.impl;
using Gestion_Cours.back.services;
using Gestion_Cours.front.views.page;
using Gestion_Cours.front.views;
using Gestion_Cours.presenter.impl;
using Gestion_Cours.presenter;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gestion_Cours.front;
using Gestion_Cours.back.data.enums;

namespace Gestion_Cours
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IMainWindows
    {
        private bool IsMaximize = false;
        public MainWindow()
        {
            InitializeComponent();
            IUserService userService = FabriqueService.GetInstance(ServiceName.UserService) as IUserService;
            ILoginPage loginPage = LoginPage.GetInstance();
            ILoginPagePresenter loginPagePresenter = new LoginPagePresenter(loginPage, userService, this);

        }

        public Frame GetFrame { get =>MainFrame; set => throw new NotImplementedException(); }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    MainFrame.Width = this.Width;
                    MainFrame.Height = this.Height;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    MainFrame.Width = this.Width;
                    MainFrame.Height = this.Height;
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
    }
}
