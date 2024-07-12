using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_C_.front.views
{
    public partial class FormView : Form, IFormView
    {
        public FormView()
        {
            InitializeComponent();
            ActiveEvent();
        }

        public string Portable { get => txtPortable.Text; set => throw new NotImplementedException(); }
        public string Nom { get => throw new NotImplementedException(); set => txtNom.Text = value; }
        public string Prenom { get => throw new NotImplementedException(); set => txtPrenom.Text = value; }
        public string Reference { get => txtReference.Text; set => throw new NotImplementedException(); }
        public string Libelle { get => throw new NotImplementedException(); set => txtLibelle.Text = value; }
        public double Prix { get => throw new NotImplementedException(); set => txtPrix.Text = value.ToString(); }
        public int QteStock { get => throw new NotImplementedException(); set => txtQteStock.Text = value.ToString(); }
        public int QteCmde { get => int.Parse(txtQteCmde.Text); set => throw new NotImplementedException(); }
        public double Total { get => throw new NotImplementedException(); set => txtTotal.Text = value.ToString(); }

        public event EventHandler ClickBtnAjouter;
        public event EventHandler ClickBtnEnregistrer;
        public event EventHandler SaisiePortable;
        public event EventHandler SaisieReference;
        void ActiveEvent()
        {
            btnAjouter.Click += delegate
            {
                ClickBtnAjouter.Invoke(this, EventArgs.Empty);
            };

            btnEnregistrer.Click += delegate
            {
                ClickBtnEnregistrer.Invoke(this, EventArgs.Empty);
            };

            txtPortable.KeyUp += delegate
            {
                SaisiePortable.Invoke(this, EventArgs.Empty);
            };

            txtReference.KeyUp += delegate
            {
                SaisieReference.Invoke(this, EventArgs.Empty);
            };
        }

        public void DisableBtnAjouter()
        {
            btnAjouter.Enabled = false;
        }

        public void EnableBtnAjouter()
        {
           btnAjouter.Enabled =true;
        }

        public void EnableBtnEnregistrer()
        {
            btnEnregistrer.Enabled = true;
        }

        public void setCommandeBindingSource(BindingSource listeArticle)
        {
            dgvCommande.DataSource = listeArticle;
        }
    }
}
