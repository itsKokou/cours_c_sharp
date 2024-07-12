using Exam.back.data.repositories;
using Exam.back.data.repositories.impl;
using Exam.back.services;
using Exam.back.services.impl;
using Exam.front;
using Exam.front.views;
using Exam.presenter;
using Exam.presenter.impl;
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

namespace Exam
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();

            IArticleRepository articleRepository = new ArticleRepository();
            IArticleService articleService = new ArticleService(articleRepository);

            IClientRepository clientRepository = new ClientRepository();
            IClientService clientService = new ClientService(clientRepository);

            IFormView view = new FormView();

            IArticlePresenter presenter = new ArticlePresenter(clientService,articleService,view);
        }
    }
}
