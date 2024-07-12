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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestion_Cours.front.views.page
{
    /// <summary>
    /// Logique d'interaction pour ClassePage.xaml
    /// </summary>
    public partial class ClassePage : Page,IClassePage
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        //public List<Classe> ClasseCollection { get; set; }

        public ClassePage()
        {
            InitializeComponent();
            ActiveEvent();
            Container.DataContext = this;
        }


        private bool IsMaximize = false;

        public event EventHandler ClickBtnAddEvent;
        public event EventHandler SelectClasseEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler FiltreEvent;

        public string Message { get => message; set => message = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public int ClasseId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Filiere FiliereSelected { get => cboFiliere.SelectedItem as Filiere; set => cboFiliere.Text = value.ToString(); }
        public Niveau NiveauSelected { get => cboNiveau.SelectedItem as Niveau; set => cboNiveau.Text = value.ToString(); }
        public Classe ClasseSelected { get => dgClasse.SelectedItem as Classe ; set => throw new NotImplementedException(); }
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
                    btnEdit.Margin = new Thickness(this.Width *0.585,0,10,0);

                    IsMaximize = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1) { 
                Application.Current.Shutdown();
            }
        }

        private void ActiveEvent()
        {
            btnAdd.Click += delegate
            {
                ClickBtnAddEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            btnEdit.Click += delegate
            {
                ClickBtnEditEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            btnDelete.Click += delegate
            {
                ClickBtnDeleteEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            dgClasse.SelectedCellsChanged += delegate
            {
                SelectClasseEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            cboNiveau.SelectionChanged += delegate
            {
                FiltreEvent.Invoke(this, EventArgs.Empty);
            };

            cboFiliere.SelectionChanged += delegate
            {
                FiltreEvent.Invoke(this, EventArgs.Empty);
            };

        }

        public void setClasseBindingSource(List<Classe> classeList, List<Filiere> filiereList, List<Niveau> niveauList)
        {  
            dgClasse.ItemsSource = classeList;
            cboFiliere.ItemsSource = filiereList;
            cboNiveau.ItemsSource = niveauList;
        }

       
    }

}