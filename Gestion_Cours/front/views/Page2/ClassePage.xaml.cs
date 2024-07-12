using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Gestion_Cours.front.views.page2
{
    /// <summary>
    /// Logique d'interaction pour ClassePage.xaml
    /// </summary>
    public partial class ClassePage : Page,IClassePage
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;
        //public List<Classe> ClasseCollection { get; set; }

        private ClassePage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
        }

        


        public event EventHandler ClickBtnAddEvent;
        public event EventHandler SelectClasseEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler FiltreEvent;
        public event EventHandler ClickBtnVoirModule;

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
        public Filiere FiliereSelected { get => cboFiliere.SelectedItem as Filiere; set => cboFiliere.Text = value.ToString(); }
        public Niveau NiveauSelected { get => cboNiveau.SelectedItem as Niveau; set => cboNiveau.Text = value.ToString(); }
        public Classe ClasseSelected { get => dgClasse.SelectedItem as Classe ; set => throw new NotImplementedException(); }
        public MessageBoxImage Icone { get => icone; set => icone = value; }
        public string UserName { get => txtName.Text; set => txtName.Text = value; }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1) { 
                Application.Current.Shutdown();
            }
        }

        private void ActiveEvent()
        {
            //btnAdd.Click += delegate
            //{
            //    ClickBtnAddEvent.Invoke(this, EventArgs.Empty);
            //};

            //btnEdit.Click += delegate
            //{
            //    ClickBtnEditEvent.Invoke(this, EventArgs.Empty);
            //};

            //btnDelete.Click += delegate
            //{
            //    ClickBtnDeleteEvent.Invoke(this, EventArgs.Empty);
            //    MessageBox.Show(Message, "infos", MessageBoxButton.OK,icone);
            //};

            dgClasse.SelectedCellsChanged += delegate
            {
                SelectClasseEvent.Invoke(this, EventArgs.Empty);
            };

            cboNiveau.SelectionChanged += delegate
            {
                FiltreEvent.Invoke(this, EventArgs.Empty);
            };

            cboFiliere.SelectionChanged += delegate
            {
                FiltreEvent.Invoke(this, EventArgs.Empty);
            };

            btnVoirModule.Click += delegate
            {
                ClickBtnVoirModule.Invoke(this, EventArgs.Empty);
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

        public void setClasseBindingSource(BindingSource classeList, BindingSource filiereList, BindingSource niveauList)
        {  
            dgClasse.ItemsSource = classeList;
            cboFiliere.ItemsSource = filiereList;
            cboNiveau.ItemsSource = niveauList;
        }


        private static ClassePage instancePage = null;
        public static ClassePage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new ClassePage();
            }
            return instancePage;
        }

    }

}