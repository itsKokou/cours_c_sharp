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
    /// Logique d'interaction pour SallePage.xaml
    /// </summary>
    public partial class SallePage : Page,ISallePage
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;

        private SallePage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
        }


        public event EventHandler ClickBtnAddEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler SelectSalleEvent;
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
        
        public Salle SalleSelected { get => dgSalle.SelectedItem as Salle; set => throw new NotImplementedException(); }
        public string Libelle { get => txtLibelle.Text; set => txtLibelle.Text = value; }
        public int NbrePlace { get => int.Parse(txtNbrePlace.Text); set => txtNbrePlace.Text = value.ToString(); }
        public MessageBoxImage Icone { get => icone; set => icone = value; }

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
                MessageBox.Show(Message,"INFORMATION",MessageBoxButton.OK,icone);
            };

            btnEdit.Click += delegate
            {
                ClickBtnEditEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "INFORMATION", MessageBoxButton.OK, icone);
            };

            btnDelete.Click += delegate
            {
                ClickBtnDeleteEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "INFORMATION", MessageBoxButton.OK, icone);
            };

            dgSalle.SelectedCellsChanged += delegate
            {
                SelectSalleEvent.Invoke(this, EventArgs.Empty);
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

        public void setSalleBindingSource(BindingSource salleList)
        {
            dgSalle.ItemsSource = salleList;
        }

        private static SallePage instancePage = null;
        public static SallePage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new SallePage();
            }
            return instancePage;
        }
    }
}
