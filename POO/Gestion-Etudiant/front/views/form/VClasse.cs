using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.front.views;
using System.Data;

namespace Gestion_Etudiant
{
    public partial class VClasse : Form, IFormClasseView
    {
        private bool isEdit = false;
        private bool isSuccessful = false;
        private string message;
        public VClasse()
        {
            InitializeComponent();//Le activeEvent est appelé ici 
            ActiveEvent();
        }

        public int ClasseId { get => int.Parse(txtId.Text); set => txtId.Text = value.ToString(); }
        public Filiere FiliereSelected { get => cboFiliere.SelectedItem as Filiere; set => cboFiliere.Text = value.ToString(); }
        public Niveau NiveauSelected { get =>cboNiveau.SelectedItem as Niveau; set => cboNiveau.Text = value.ToString(); }
        public string Code { get => txtCode.Text; set => txtCode.Text = value; }//pas de set car code pas dans db
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessFul { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }
        

        public event EventHandler ClickBtnAddEvent;
        public event EventHandler ClickBtnEditEvent;
        public event EventHandler ClickBtnDeleteEvent;
        public event EventHandler SelectClasseEvent;

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
            
            dgvClasse.CellClick += delegate
            {
                SelectClasseEvent.Invoke(this, EventArgs.Empty);
            };

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void setClasseBindingSource(BindingSource classeList, BindingSource filiereList, BindingSource niveauList)
        {
            cboFiliere.DataSource = filiereList;
            cboFiliere.DisplayMember = "name"; //Le champ à afficher 
            cboFiliere.ValueMember = "id";
            cboNiveau.DisplayMember = "name"; //Le champ à afficher 
            cboNiveau.ValueMember = "id";
            cboNiveau.DataSource = niveauList;
            dgvClasse.DataSource = classeList;
            

        }

        public void ShowForm()
        {
           Show();
        }
    }
}
