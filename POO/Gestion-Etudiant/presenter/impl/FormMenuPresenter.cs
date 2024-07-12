using Gestion_Etudiant.back.data.dto;
using Gestion_Etudiant.back.data.repositories.impl;
using Gestion_Etudiant.back.data.repositories;
using Gestion_Etudiant.back.services.impl;
using Gestion_Etudiant.back.services;
using Gestion_Etudiant.front.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.presenter.impl
{
    public class FormMenuPresenter : IFormMenuPresenter
    {
        private readonly IMenuFormView view;

        public FormMenuPresenter(IMenuFormView view, UserDto userConnectDto)
        {
            this.view = view;
            this.view.UserConnectDto = userConnectDto;
            view.showViewClasse += showClasseHandler;
            this.view.ShowForm(); //Lancer la vue 
        }

        public void showClasseHandler(object sender, EventArgs e)
        {
            IFormClasseView viewClasse = new VClasse();
            IFiliereRepository filiereRepository = new FiliereRepository();
            INiveauRepository niveauRepository = new NiveauRepository();
            IClasseRepository classeRepository = new ClasseRepository();
            IClasseService classeService = new ClasseService(classeRepository, filiereRepository, niveauRepository);
            IFormClassePresenter formClassePresenter = new FormClassePresenter(classeService, viewClasse);//show classe
        }

        
    }
}
