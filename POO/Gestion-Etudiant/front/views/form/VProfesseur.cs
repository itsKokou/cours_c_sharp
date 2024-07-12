using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Etudiant.front.views.form
{
    public partial class VProfesseur : Form, IFormProfesseurView
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        public VProfesseur()
        {
            InitializeComponent();
            ActiveEvent();
        }

        public string Message { get => message; set => message = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public int ProfesseurId { get => int.Parse(txtProfesseurId.Text); set => txtProfesseurId.Text = value.ToString(); }
        public Grade FiltreGradeSelected { get => cboFiltreGrade.SelectedItem as Grade; set => throw new NotImplementedException(); }
        public string NomComplet { get => txtNomComplet.Text; set => txtNomComplet.Text = value; }
        public string Login { get => txtLogin.Text; set => txtLogin.Text = value; }
        public string Password { get => txtPassword.Text; set => throw new NotImplementedException(); }
        public Grade GradeSelected { get => cboGrade.SelectedItem as Grade; set => cboGrade.Text = value.ToString(); }

        public event EventHandler ClickBtnAddEvent;
        public event EventHandler SelectProfesseurEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;

        //Active event et le relie à un callback
        private void ActiveEvent()
        {
            btnAdd.Click += delegate
            {
                ClickBtnAddEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            btnUpdate.Click += delegate
            {
                ClickBtnEditEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            btnDelete.Click += delegate
            {
                ClickBtnDeleteEvent.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };

            dgvProfesseur.CellClick += delegate
            {
                SelectProfesseurEvent.Invoke(this, EventArgs.Empty);
            };

        }

        public void setProfesseurBindingSource(BindingSource professeurList, BindingSource gradeList, BindingSource filtreGradeList)
        {
            cboFiltreGrade.DataSource = filtreGradeList;
            cboFiltreGrade.DisplayMember = "name"; //Le champ à afficher 
            cboFiltreGrade.ValueMember = "id";
            cboGrade.DataSource = gradeList;
            cboGrade.DisplayMember = "name";
            cboGrade.ValueMember = "id";
            dgvProfesseur.DataSource = professeurList;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void VProfesseur_Load(object sender, EventArgs e)
        {

        }
    }
}
