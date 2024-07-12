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
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Exam.front.views
{
    /// <summary>
    /// Logique d'interaction pour FormView.xaml
    /// </summary>
    public partial class FormView : Window , IFormView
    {
        public FormView()
        {
            InitializeComponent();
            ActiveEvent();
            
        }

        public double Total { get => throw new NotImplementedException(); set => txtTotal.Text = value.ToString(); }
        public int QteSaisie { get => int.Parse(txtQteCmd.Text) ; set => txtQteCmd.Text = value.ToString(); }
        public string PortableSaisi { get => txtPortable.Text; set => txtPortable.Text = value; }
        public string ReferenceSaisie { get => txtReference.Text; set => txtReference.Text = value; }
        public string Nom { get => throw new NotImplementedException(); set => txtNom.Text = value; }
        public string Prenom { get => throw new NotImplementedException(); set => txtPrenom.Text = value; }
        public double Prix { get => throw new NotImplementedException(); set => txtPrix.Text =  value.ToString(); }
        public string Libelle { get => throw new NotImplementedException(); set => txtLibelle.Text = value; }
        public int QteStock { get => throw new NotImplementedException(); set => txtQteStock.Text = value.ToString(); }

        public event EventHandler SaisiePortableEvent;
        public event EventHandler SaisieReferenceEvent;
        public event EventHandler ClickBtnAddEvent;
        public event EventHandler ClickBtnEnregistrerEvent;


        private void ActiveEvent()
        {
            txtPortable.KeyUp += delegate
            {
                SaisiePortableEvent.Invoke(this, EventArgs.Empty);
            };
            txtReference.KeyUp += delegate
            {
                SaisieReferenceEvent.Invoke(this, EventArgs.Empty);
            };
            btnAdd.Click += delegate
            {
                ClickBtnAddEvent.Invoke(this, EventArgs.Empty);
            };
            btnEnregistrer.Click += delegate
            {
                ClickBtnEnregistrerEvent.Invoke(this, EventArgs.Empty);
            };
        }
        public void DisableAdd()
        {
            btnAdd.IsEnabled = false;
        }



        public void EnableAdd()
        {
            btnAdd.IsEnabled = true;
        }

        public void EnableBtnEnregistrer()
        {
            btnEnregistrer.IsEnabled = true;
        }

        public void setArticleBindingSource(BindingSource articleCommandes)
        {
            dgArticle.ItemsSource = articleCommandes;
        }

        public void ShowForm()
        {
            this.Show();
        }
    }
}
