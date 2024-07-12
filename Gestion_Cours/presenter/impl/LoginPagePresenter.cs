using Gestion_Cours.back.data.repositories.impl;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.services;
using Gestion_Cours.back.services.impl;
using Gestion_Cours.front.views;
using Gestion_Cours.front.views.page;
using Gestion_Etudiant.back.data.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Cours.back.data.enums;
using Gestion_Cours.front.views.page2;
using ClassePage = Gestion_Cours.front.views.page.ClassePage;

namespace Gestion_Cours.presenter.impl
{
    internal class LoginPagePresenter : ILoginPagePresenter
    {
        private readonly ILoginPage view;
        private readonly IUserService userService;
        private readonly IMainWindows mainWindow;

        public LoginPagePresenter(ILoginPage view, IUserService userService, IMainWindows mainWindows)
        {
            this.view = view;
            this.userService = userService;
            this.mainWindow = mainWindows;
            this.mainWindow.GetFrame.Width = 800;
            this.mainWindow.GetFrame.Height = 500;
            this.view.ClickBtnConnexion += ConnexionHandler;
            
            this.mainWindow.GetFrame.Navigate(this.view);//Crée la vue
        }

        public void ConnexionHandler(object sender, EventArgs e)
        {
           
                view.ErrorMessage = "";
                if (!string.IsNullOrEmpty(view.Login) && !string.IsNullOrEmpty(view.Password))
                {
                    if (view.Login.Contains('@') && view.Login.Contains(".com"))
                    {
                        UserDto userConnected = userService.Connexion(view.Login, view.Password);
                        if (userConnected != null)
                        {

                            view.Login = "";
                            view.Password = "";
                            //Tester si c'est prof ou si c'est admin
                            //Affichage Classe
                            this.mainWindow.GetFrame.Width = 1080;
                            this.mainWindow.GetFrame.Height = 720;
                            IClasseService classeService = FabriqueService.GetInstance(ServiceName.ClasseService) as IClasseService;
                            if (userConnected.RoleName=="ROLE_PROF")
                            {
                                IClassePage classeView2 = front.views.page2.ClassePage.GetInstance();
                                IClassePagePresenter classePagePresenter2 = new ClassePagePresenter(classeService, classeView2,this.mainWindow,userConnected);
                            }
                            else
                            {
                                IClassePage classeView = ClassePage.GetInstance();
                                IClassePagePresenter classePagePresenter = new ClassePagePresenter(classeService, classeView,this.mainWindow);
                            }

                        }
                        else
                        {
                            view.ErrorMessage = "Login ou Mot de passe incorrect !";
                        }
                    }
                    else
                    {
                        view.ErrorMessage = "L'identifiant doit être un Email !";
                    }
                }
                else
                {
                    view.ErrorMessage = "Login ou Mot de passe invalide !";
                }
           
        }
    }
}
