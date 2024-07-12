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
    /// Logique d'interaction pour SallePage.xaml
    /// </summary>
    public partial class SallePage : Page,ISallePage
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        private bool IsMaximize = false;
        public SallePage()
        {
            InitializeComponent();
            ActiveEvent();
        }


        public event EventHandler ClickBtnAddEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler SelectSalleEvent;

        public string Message { get => message; set => message = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        
        public Salle SalleSelected { get => dgSalle.SelectedItem as Salle; set => throw new NotImplementedException(); }
        public string Libelle { get => txtLibelle.Text; set => txtLibelle.Text = value; }
        public int NbrePlace { get => int.Parse(txtNbrePlace.Text); set => txtNbrePlace.Text = value.ToString(); }

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
                    //btnEdit.Margin = new Thickness(this.Width * 0.585, 0, 10, 0);

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

            dgSalle.SelectedCellsChanged += delegate
            {
                SelectSalleEvent.Invoke(this, EventArgs.Empty);
            };

            
        }

        public void setClasseBindingSource(List<Salle> salleList)
        {
            dgSalle.ItemsSource = salleList;
        }
    }
}
