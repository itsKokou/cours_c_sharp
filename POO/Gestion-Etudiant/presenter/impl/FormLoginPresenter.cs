using Gestion_Etudiant.back.data.dto;
using Gestion_Etudiant.back.services;
using Gestion_Etudiant.front.views;
using Gestion_Etudiant.front.views.form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.presenter.impl
{
    public class FormLoginPresenter : IFormLoginPresenter
    {
        private readonly ILoginFormView view;
        private readonly IUserService userService;

        public FormLoginPresenter(ILoginFormView view, IUserService userService)
        {
            this.view = view;
            this.userService = userService;

            view.ClickBtnConnexion += connexionHandler;
        }

        public void connexionHandler(object sender, EventArgs e)
        {
            UserDto userConnected =userService.Connexion(view.Login, view.Password);

            if (!string.IsNullOrEmpty(view.Login) && !string.IsNullOrEmpty(view.Password))
            {
                if (userConnected != null)
                {
                    view.HideForm();
                    IMenuFormView menuView = new MenuForm();
                    IFormMenuPresenter presenter = new FormMenuPresenter(menuView, userConnected);//inclus lancement vue
                }
                else
                {
                    view.Message = "Login ou Mot de passe incorrect !";
                }
            }
            else
            {
                view.Message = "Login ou Mot de passe invalide !";
            }
        }
    }
}
