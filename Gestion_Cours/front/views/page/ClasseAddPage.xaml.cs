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
    /// Logique d'interaction pour ClasseAddPage.xaml
    /// </summary>
    public partial class ClasseAddPage : Page,IClasseAddPage
    {
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;

        private ClasseAddPage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
            //this.IsMaximize = maximize;
        }


        public event EventHandler SelectFiliereEvent;
        public event EventHandler ClickBtnSaveEvent;


        //Menu
        public event EventHandler ClickBtnClasseEvent;
        public event EventHandler ClickBtnModuleEvent;
        public event EventHandler ClickBtnSalleEvent;
        public event EventHandler ClickBtnCoursEvent;
        public event EventHandler ClickBtnProfesseurEvent;
        public event EventHandler ClickBtnLogoutEvent;

        public string Message { get => message; set => message = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public Filiere FiliereSelected { get => cboFiliere.SelectedItem as Filiere; set => cboFiliere.Text = value.ToString(); }

        public Niveau NiveauSelected { get => cboNiveau.SelectedItem as Niveau; set => cboNiveau.Text = value.ToString(); }
        public string Libelle { get => txtLibelle.Text; set => txtLibelle.Text = value; }
        public string Effectif { get => txtEffectif.Text; set => txtEffectif.Text = value.ToString(); }
        public MessageBoxImage Icone { get => icone; set => icone = value; }
        public List<Module> ModulesSelected { get => lbModule.SelectedItems.Cast<Module>().ToList(); set => throw new NotImplementedException(); }



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
                MessageBox.Show(Message,"INFOS",MessageBoxButton.OK,icone);
            };

            cboFiliere.SelectionChanged += delegate
            {
                SelectFiliereEvent.Invoke(this, EventArgs.Empty);
            };

            cboNiveau.SelectionChanged += delegate
            {
                SelectFiliereEvent.Invoke(this, EventArgs.Empty);
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

        public void setClasseBindingSource(BindingSource filiereList, BindingSource niveauList, BindingSource moduleList)
        {
            cboFiliere.ItemsSource = filiereList;
            cboNiveau.ItemsSource = niveauList;
            lbModule.ItemsSource = moduleList;
        }



        private static ClasseAddPage instancePage = null;
        public static ClasseAddPage GetInstance()
        {
            if (instancePage==null)
            {
               instancePage = new ClasseAddPage();
            }
            return instancePage;
        }

       
    }
}
