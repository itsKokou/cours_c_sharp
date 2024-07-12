using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Xceed.Wpf.Toolkit;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace Gestion_Cours.front.views.page
{
    /// <summary>
    /// Logique d'interaction pour CoursAddPage.xaml
    /// </summary>
    public partial class CoursAddPage : Page, ICoursAddPage
    {
        private bool isSuccessful = false;
        private string message;
        private MessageBoxImage icone;
        private CoursAddPage()
        {
            InitializeComponent();
            ActiveEvent();
            ActiveMenuEvent();
        }

        public string Message { get => message; set => message = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public dynamic DateSelected { get => dpDate.SelectedDate; set => throw new NotImplementedException(); }
        public dynamic HeureDSelected { get => tpHeureD.Value; set => throw new NotImplementedException(); }
        public dynamic HeureFSelected { get => tpHeureF.Value; set => throw new NotImplementedException(); }
        public Module ModuleSelected { get => cboModule.SelectedItem as Module; set => throw new NotImplementedException(); }
        public Professeur ProfesseurSelected { get => cboProfesseur.SelectedItem as Professeur; set => throw new NotImplementedException(); }
        public string CodeCours { get => txtCode.Text; set => throw new NotImplementedException(); }
        public Salle SalleSelected { get => cboSalle.SelectedItem as Salle; set => throw new NotImplementedException(); }
        public List<Classe> ClassesSelected { get => lbClasse.SelectedItems.Cast<Classe>().ToList(); set => throw new NotImplementedException(); }
        public MessageBoxImage Icone { get => icone; set => icone = value; }

        public event EventHandler SelectModuleEvent;
        public event EventHandler SelectProfesseurEvent;
        public event EventHandler SelectClassesEvent;
        public event EventHandler SelectSalleEvent;
        public event EventHandler SaisieCodeEvent;
        public event EventHandler ClickBtnSaveEvent;
        public event EventHandler SelectDateEvent;
        public event EventHandler SelectHeureDebutEvent;
        public event EventHandler SelectHeureFinEvent;

        //Menu
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

            cboModule.SelectionChanged += delegate
            {
                SelectModuleEvent.Invoke(this, EventArgs.Empty);
            };

            cboProfesseur.SelectionChanged += delegate
            {
                SelectProfesseurEvent.Invoke(this, EventArgs.Empty);
            };

            lbClasse.SelectionChanged += delegate
            {
                SelectClassesEvent.Invoke(this, EventArgs.Empty);
            };

            cboSalle.SelectionChanged += delegate
            {
                SelectSalleEvent.Invoke(this, EventArgs.Empty);
            };

            txtCode.KeyUp += delegate
            {
                SaisieCodeEvent.Invoke(this, EventArgs.Empty);
            };

            tpHeureD.ValueChanged += delegate
            {
               SelectHeureDebutEvent.Invoke(this, EventArgs.Empty);
            };
            
            tpHeureF.ValueChanged += delegate
            {
               SelectHeureFinEvent.Invoke(this, EventArgs.Empty);
            };
            
            dpDate.SelectedDateChanged += delegate
            {
               SelectDateEvent.Invoke(this, EventArgs.Empty);
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


        public void setCoursBindingSource(BindingSource moduleList, BindingSource professeurList, BindingSource classeList, BindingSource salleList)
        {
            cboModule.ItemsSource = moduleList;
            cboProfesseur.ItemsSource = professeurList;
            lbClasse.ItemsSource = classeList;
            cboSalle.ItemsSource = salleList;
        }

        public void DisableCodeCours()
        {
            this.txtCode.IsEnabled = false;
        }
        public void EnableCodeCours()
        {
            this.txtCode.IsEnabled = true;
        }
        public void DisableSalle()
        {
            this.cboSalle.IsEnabled = false;
        }
        public void EnableSalle()
        {
            this.cboSalle.IsEnabled = true;
        }

        public void EnableHeureDebut()
        {
            this.tpHeureD.IsEnabled = true;
        }
        public void DisableHeureDebut()
        {
            this.tpHeureD.IsEnabled = false;
        }

        public void EnableHeureFin()
        {
            this.tpHeureF.IsEnabled = true;
        }
        public void DisableHeureFin()
        {
            this.tpHeureF.IsEnabled = false;
        }

        public void EnableModule()
        {
            this.cboModule.IsEnabled = true;
        }
        public void DisableModule()
        {
            this.cboModule.IsEnabled = false;
        }

        public void EnableProfessseur()
        {
           this.cboProfesseur.IsEnabled = true;
        }
        public void DisableProfessseur()
        {
           this.cboProfesseur.IsEnabled = false;
        }

        public void EnableClasse()
        {
           this.lbClasse.IsEnabled = true;
        }
        public void DisableClasse()
        {
           this.lbClasse.IsEnabled = false;
        }

        public void EnableBtnEnregistrer()
        {
            this.btnEnregistrer.IsEnabled = true;
        }
         public void DisableBtnEnregistrer()
        {
            this.btnEnregistrer.IsEnabled = false;
        }


        private static CoursAddPage instancePage = null;
        public static CoursAddPage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new CoursAddPage();
            }
            return instancePage;
        }

    }
}
