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
    public partial class LoginForm : Form,ILoginFormView
    {
        private string message;
        public LoginForm()
        {
            InitializeComponent();
            btnConnexion.Click += delegate
            {
                ClickBtnConnexion.Invoke(this, EventArgs.Empty);
                //MessageBox.Show(message);
            };
        }

        public string Message { get => message; set => message = value; }
        public string Login { get => txtLogin.Text.Trim(); set => throw new NotImplementedException(); }
        public string Password { get => txtPassword.Text.Trim(); set => throw new NotImplementedException(); }

        public event EventHandler ClickBtnConnexion;

        public void HideForm()
        {
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
