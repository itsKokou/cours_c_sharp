using Gestion_Cours.back.data.entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Gestion_Cours.front.views.page
{
    /// <summary>
    /// Logique d'interaction pour ProfesseurAddPage.xaml
    /// </summary>
    public partial class ProfesseurAddPage : Page,IProfesseurAddPage
    {
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;


        private ProfesseurAddPage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
        }

        public string Message { get => message; set => message = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public string NomComplet { get => txtNomComplet.Text; set => txtNomComplet.Text = value; }
        public string Portable { get => txtPortable.Text; set => txtPortable.Text = value; }
        public string Login { get => txtLogin.Text; set => txtLogin.Text = value; }
        public string Password { get => txtPassword.Password; set => throw new NotImplementedException(); }
        public MessageBoxImage Icone { get => icone; set => icone = value; }
        public Classe ClasseSelected { get => cboClasse.SelectedItem as Classe; set => throw new NotImplementedException(); }
        public List<Module> ModulesSelected { get => lbModules.SelectedItems.Cast<Module>().ToList(); set => throw new NotImplementedException(); }

        public event EventHandler SelectClasseEvent;
        public event EventHandler ClickBtnSaveEvent;
        public event EventHandler ClickBtnAddEnseignementEvent;

        //menu
        public event EventHandler ClickBtnClasseEvent;
        public event EventHandler ClickBtnModuleEvent;
        public event EventHandler ClickBtnSalleEvent;
        public event EventHandler ClickBtnCoursEvent;
        public event EventHandler ClickBtnProfesseurEvent;
        public event EventHandler ClickBtnLogoutEvent;

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Application.Current.Shutdown();
            }
        }


        private void ActiveEvent()
        {
            btnEnregistrer.Click += delegate
            {
                ClickBtnSaveEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "INFOS", MessageBoxButton.OK, icone);
            };

            cboClasse.SelectionChanged += delegate
            {
                SelectClasseEvent.Invoke(this, EventArgs.Empty);
            };

            btnAddEnseignement.Click += delegate
            {
                ClickBtnAddEnseignementEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "INFOS", MessageBoxButton.OK, icone);
            };


        }

        private void ActiveMenuEvent()
        {
            btnClasse.Click += delegate
            {
                ClickBtnClasseEvent.Invoke(this, EventArgs.Empty);
            };
            btnCours.Click += delegate
            {
                ClickBtnCoursEvent.Invoke(this, EventArgs.Empty);
            };
            btnModule.Click += delegate
            {
                ClickBtnModuleEvent.Invoke(this, EventArgs.Empty);
            };
            btnProfesseur.Click += delegate
            {
                ClickBtnProfesseurEvent.Invoke(this, EventArgs.Empty);
            };
            btnSalle.Click += delegate
            {
                ClickBtnSalleEvent.Invoke(this, EventArgs.Empty);
            };
            btnLogout.Click += delegate
            {
                ClickBtnLogoutEvent.Invoke(this, EventArgs.Empty);
            };
        }

        public void setProfesseurClasseAndModuleBindingSource(BindingSource classeList, BindingSource moduleList)
        {
            cboClasse.ItemsSource = classeList;
            lbModules.ItemsSource = moduleList;
        }

        private static ProfesseurAddPage instancePage = null;
        public static ProfesseurAddPage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new ProfesseurAddPage();
            }
            return instancePage;
        }

    }
}
