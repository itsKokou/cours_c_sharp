using Gestion_Etudiant.back.data.repositories;
using Gestion_Etudiant.back.data.repositories.impl;
using Gestion_Etudiant.back.services;
using Gestion_Etudiant.back.services.impl;
using Gestion_Etudiant.front.views;
using Gestion_Etudiant.front.views.form;
using Gestion_Etudiant.presenter;
using Gestion_Etudiant.presenter.impl;

namespace Gestion_Etudiant
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            //IFormProfesseurView viewProf = new VProfesseur();
            //IGradeRepository gradeRepository = new GradeRepository();
            //IProfesseurRepository professeurRepository = new ProfesseurRepository();
            //IProfesseurService professeurService = new ProfesseurService(professeurRepository, gradeRepository);
            //IFormProfesseurPresenter formProfesseurPresenter = new FormProfesseurPresenter(professeurService, viewProf);

            ILoginFormView viewLogin = new LoginForm();
            IUserRepository userRepository = new UserRepository();
            IUserService userService = new UserService(userRepository);
            IFormLoginPresenter formLoginPresenter = new FormLoginPresenter(viewLogin,userService);



            Application.Run(viewLogin as Form);
        }
    }
}