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
using System.Windows.Forms;
using Gestion_Cours.back.data.enums;
using Gestion_Etudiant.back.data.dto;

namespace Gestion_Cours.presenter.impl
{
    public class PagePresenter : IPagePresenter
    {
        private readonly IPage viewPage;
        private readonly IMainWindows mainWindow;
        protected readonly UserDto userConnected;

        public PagePresenter(IPage view, IMainWindows mainWindow)
        {
            this.viewPage = view;
            this.mainWindow = mainWindow;
            ActiveMenuEventHandler();
        }

        public PagePresenter(IPage view, IMainWindows mainWindow,UserDto userDto)
        {
            this.viewPage = view;
            this.mainWindow = mainWindow;
            ActiveMenuEventHandler();
            userConnected = userDto;
        }


        public void ActiveMenuEventHandler()
        {
            viewPage.ClickBtnClasseEvent += ShowClasseHandler;
            viewPage.ClickBtnModuleEvent += ShowModuleHandler;
            viewPage.ClickBtnCoursEvent += ShowCoursHandler;
            viewPage.ClickBtnProfesseurEvent += ShowProfesseurHandler;
            viewPage.ClickBtnSalleEvent += ShowSalleHandler;
            viewPage.ClickBtnLogoutEvent += LogoutHandler;
        }

        public void LogoutHandler(object sender, EventArgs e)
        {
            IUserService userService = FabriqueService.GetInstance(ServiceName.UserService) as IUserService;
            ILoginPage loginPage = LoginPage.GetInstance();
            ILoginPagePresenter loginPagePresenter = new LoginPagePresenter(loginPage, userService, this.mainWindow);
        }

        public void ShowClasseHandler(object sender, EventArgs e)
        {
            //Affichage Classe
            IClasseService classeService = FabriqueService.GetInstance(ServiceName.ClasseService) as IClasseService;
            if (userConnected==null)
            {                
                IClassePage classeView = ClassePage.GetInstance();
                IClassePagePresenter classePagePresenter = new ClassePagePresenter(classeService, classeView, this.mainWindow);
            }
            else
            {
                IClassePage classeView2 = front.views.page2.ClassePage.GetInstance();
                IClassePagePresenter classePagePresenter2 = new ClassePagePresenter(classeService, classeView2, this.mainWindow, userConnected);
            }
        }

        public void ShowCoursHandler(object sender, EventArgs e)
        {
            IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;

            IClasseService classeService = FabriqueService.GetInstance(ServiceName.ClasseService) as IClasseService;

            ISalleService salleService = FabriqueService.GetInstance(ServiceName.SalleService) as ISalleService;

            ICoursService coursService = FabriqueService.GetInstance(ServiceName.CoursService) as ICoursService;
            if (userConnected==null)
            {
                professeurService.CoursService = coursService;
                classeService.CoursService = coursService;
                salleService.CoursService = coursService;
                ICoursPage coursPage = CoursPage.GetInstance();
                ICoursPagePresenter coursPagePresenter = new CoursPagePresenter(coursService, professeurService,classeService,coursPage,this.mainWindow);
            }
            else
            {
                ICoursPage coursPage = front.views.page2.CoursPage.GetInstance();
                ICoursPagePresenter coursPagePresenter = new CoursPagePresenter(coursService, professeurService, classeService, coursPage, this.mainWindow,userConnected);
            }
        }

        public void ShowModuleHandler(object sender, EventArgs e)
        {
            IModuleService moduleService = FabriqueService.GetInstance(ServiceName.ModuleService) as IModuleService;
            IModulePage modulePage = ModulePage.GetInstance();
            IModulePagePresenter modulePagePresenter = new ModulePagePresenter(moduleService, modulePage,this.mainWindow);
        }

        public void ShowProfesseurHandler(object sender, EventArgs e)
        {
            IClassePage classeView = ClassePage.GetInstance();

            IClasseService classeService = FabriqueService.GetInstance(ServiceName.ClasseService) as IClasseService;

            IProfesseurService professeurService = FabriqueService.GetInstance(ServiceName.ProfesseurService) as IProfesseurService;
            IProfesseurPage professeurPage = ProfesseurPage.GetInstance();
            IProfesseurPagePresenter professeurPagePresenter = new ProfesseurPagePresenter(professeurService,professeurPage,this.mainWindow,classeService);
        }

        public void ShowSalleHandler(object sender, EventArgs e)
        {
            ISalleService salleService = FabriqueService.GetInstance(ServiceName.SalleService) as ISalleService;
            ISallePage sallePage = SallePage.GetInstance();
            ISallePagePresenter sallePagePresenter = new SallePagePresenter(sallePage,salleService,this.mainWindow);
        }
    }
}
 