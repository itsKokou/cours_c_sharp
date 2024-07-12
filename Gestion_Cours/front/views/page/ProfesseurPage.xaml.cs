using Gestion_Cours.back.data.entities;
using System;
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
    /// Logique d'interaction pour ProfesseurPage.xaml
    /// </summary>
    public partial class ProfesseurPage : Page,IProfesseurPage
    {

        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;


        private ProfesseurPage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
        }

        public event EventHandler ClickBtnAddEvent;
        public event EventHandler SelectProfesseurEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler FiltreEvent;
        public event EventHandler ClickBtnVoirClasse;

        //Menu
        public event EventHandler ClickBtnClasseEvent;
        public event EventHandler ClickBtnModuleEvent;
        public event EventHandler ClickBtnSalleEvent;
        public event EventHandler ClickBtnCoursEvent;
        public event EventHandler ClickBtnProfesseurEvent;
        public event EventHandler ClickBtnLogoutEvent;

        public string Message { get => message; set => message = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public MessageBoxImage Icone { get => icone; set => icone = value; }
        public string Portable { get => txtPortable.Text; set => txtPortable.Text = value; }
        public Professeur ProfesseurSelected { get => dgProfesseur.SelectedItem as Professeur; set => throw new NotImplementedException(); }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Application.Current.Shutdown();
            }
        }

        private void ActiveEvent()
        {
            btnAdd.Click += delegate
            {
                ClickBtnAddEvent.Invoke(this, EventArgs.Empty);
            };

            btnEdit.Click += delegate
            {
                ClickBtnEditEvent.Invoke(this, EventArgs.Empty);
            };

            btnDelete.Click += delegate
            {
                ClickBtnDeleteEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "infos", MessageBoxButton.OK, icone);
            };

            dgProfesseur.SelectedCellsChanged += delegate
            {
                SelectProfesseurEvent.Invoke(this, EventArgs.Empty);
            };

            txtPortable.KeyUp += delegate
            {
                FiltreEvent.Invoke(this, EventArgs.Empty);
            };

            btnVoirClasse.Click += delegate
            {
                ClickBtnVoirClasse.Invoke(this, EventArgs.Empty);
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

        public void setProfeseurBindingSource(BindingSource professeurList)
        {
            dgProfesseur.ItemsSource = professeurList;
        }

        private static ProfesseurPage instancePage = null;
        public static ProfesseurPage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new ProfesseurPage();
            }
            return instancePage;
        }

    }
}
