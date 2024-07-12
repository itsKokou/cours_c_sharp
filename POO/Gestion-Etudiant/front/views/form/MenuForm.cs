using Gestion_Etudiant.back.data.dto;
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
    public partial class MenuForm : Form, IMenuFormView
    {
        private UserDto userConnectDto;
        public MenuForm()
        {
            InitializeComponent();
            menuClasse.Click += delegate
            {
                showViewClasse.Invoke(this, EventArgs.Empty);
            };
        }

        public UserDto UserConnectDto { get => userConnectDto; set => userConnectDto = value; }

        public event EventHandler showViewClasse;

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ShowForm()
        {
            labelInfo.Text = userConnectDto.NomComplet;
            Show();
        }
    }
}
