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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_Cours.front.views.page
{
    /// <summary>
    /// Logique d'interaction pour ClasseAddPage.xaml
    /// </summary>
    public partial class ClasseAddPage : Page,IClasseAddPage
    {
        private bool isSuccessful = false;
        private string message;
        public ClasseAddPage()
        {
            InitializeComponent();
            ActiveEvent();

        }

        private bool IsMaximize = false;

        public event EventHandler SelectFiliereEvent;
        public event EventHandler ClickBtnSaveEvent;

        public string Message { get => message; set => message = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public Filiere FiliereSelected { get => cboFiliere.SelectedItem as Filiere; set => throw new NotImplementedException(); }
        public Niveau NiveauSelected { get => cboNiveau.SelectedItem as Niveau; set => throw new NotImplementedException(); }
        public string Libelle { get => txtLibelle.Text; set => txtLibelle.Text = value; }
        public int Effectif { get => int.Parse(txtEffectif.Text); set => throw new NotImplementedException(); }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.Width = SystemParameters.PrimaryScreenWidth;
                    this.Height = SystemParameters.PrimaryScreenHeight;

                    IsMaximize = true;
                }
            }
        }

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
                MessageBox.Show(Message);
            };

            cboFiliere.SelectionChanged += delegate
            {
                SelectFiliereEvent.Invoke(this, EventArgs.Empty);
            };
        }

        public void setClasseBindingSource(List<Filiere> filiereList, List<Niveau> niveauList)
        {
            cboFiliere.ItemsSource = filiereList;
            cboNiveau.ItemsSource = niveauList;
        }

    }
}
