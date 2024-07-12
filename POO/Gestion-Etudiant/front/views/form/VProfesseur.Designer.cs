namespace Gestion_Etudiant.front.views.form
{
    partial class VProfesseur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            dgvProfesseur = new DataGridView();
            groupBox2 = new GroupBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtProfesseurId = new TextBox();
            cboGrade = new ComboBox();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtNomComplet = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox3 = new GroupBox();
            cboFiltreGrade = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfesseur).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvProfesseur);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(862, 453);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Liste des Professeurs";
            // 
            // dgvProfesseur
            // 
            dgvProfesseur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesseur.Location = new Point(6, 46);
            dgvProfesseur.Name = "dgvProfesseur";
            dgvProfesseur.RowHeadersWidth = 62;
            dgvProfesseur.Size = new Size(850, 388);
            dgvProfesseur.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Info;
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Controls.Add(txtProfesseurId);
            groupBox2.Controls.Add(cboGrade);
            groupBox2.Controls.Add(txtLogin);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtNomComplet);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(910, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(545, 533);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nouveau Professeur";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.GradientInactiveCaption;
            btnUpdate.Location = new Point(267, 429);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(92, 48);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "UP";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.GradientInactiveCaption;
            btnDelete.Location = new Point(395, 429);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(92, 48);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "DEL";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.GradientInactiveCaption;
            btnAdd.ForeColor = SystemColors.ControlText;
            btnAdd.Location = new Point(133, 429);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(92, 48);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtProfesseurId
            // 
            txtProfesseurId.Location = new Point(6, 354);
            txtProfesseurId.Name = "txtProfesseurId";
            txtProfesseurId.Size = new Size(115, 39);
            txtProfesseurId.TabIndex = 8;
            txtProfesseurId.Visible = false;
            // 
            // cboGrade
            // 
            cboGrade.FormattingEnabled = true;
            cboGrade.Location = new Point(201, 302);
            cboGrade.Name = "cboGrade";
            cboGrade.Size = new Size(286, 40);
            cboGrade.TabIndex = 7;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(198, 145);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(289, 39);
            txtLogin.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(198, 223);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(289, 39);
            txtPassword.TabIndex = 5;
            // 
            // txtNomComplet
            // 
            txtNomComplet.Location = new Point(198, 63);
            txtNomComplet.Name = "txtNomComplet";
            txtNomComplet.Size = new Size(289, 39);
            txtNomComplet.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 302);
            label5.Name = "label5";
            label5.Size = new Size(83, 30);
            label5.TabIndex = 3;
            label5.Text = "Grade :";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 223);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 2;
            label4.Text = "Password :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 145);
            label3.Name = "label3";
            label3.Size = new Size(77, 30);
            label3.TabIndex = 1;
            label3.Text = "Login :";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 63);
            label2.Name = "label2";
            label2.Size = new Size(161, 30);
            label2.TabIndex = 0;
            label2.Text = "Nom Complet :";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(cboFiltreGrade);
            groupBox3.Controls.Add(label1);
            groupBox3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(16, 16);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(595, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtre";
            // 
            // cboFiltreGrade
            // 
            cboFiltreGrade.FormattingEnabled = true;
            cboFiltreGrade.Location = new Point(139, 42);
            cboFiltreGrade.Name = "cboFiltreGrade";
            cboFiltreGrade.Size = new Size(303, 38);
            cboFiltreGrade.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 45);
            label1.Name = "label1";
            label1.Size = new Size(83, 30);
            label1.TabIndex = 0;
            label1.Text = "Grade :";
            // 
            // VProfesseur
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 595);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "VProfesseur";
            Text = "VProfesseur";
            Load += VProfesseur_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProfesseur).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvProfesseur;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private ComboBox cboFiltreGrade;
        private Label label1;
        private Label label5;
        private Label label4;
        private ComboBox cboGrade;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtNomComplet;
        private TextBox txtProfesseurId;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}