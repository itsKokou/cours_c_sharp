using Examen_C_.back.data.repositories;
using Examen_C_.back.data.repositories.impl;
using Examen_C_.back.services;
using Examen_C_.back.services.impl;
using Examen_C_.front;
using Examen_C_.front.views;
using Examen_C_.presenter;
using Examen_C_.presenter.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_C_
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IFormView view = new FormView();
            IClientRepository clientRepository = new ClientRepositoryImpl();
            IArticleRepository articleRepository = new ArticleRepositoryImpl();
            ICommandeRepository commandeRepository = new CommandeRepositoryImpl(articleRepository);

            IClientService clientService = new ClientServiceImpl(clientRepository);
            IArticleService articleService = new ArticleServiceImpl(articleRepository);
            ICommandeService commandeService = new CommandeServiceImpl(commandeRepository);

            IPresenter presenter = new Presenter(view, clientService, articleService, commandeService);

            Application.Run(view as FormView);
        }
    }
}
