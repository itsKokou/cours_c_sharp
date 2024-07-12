namespace Gestion_Etudiant
{
    partial class VClasse
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            cboNiveau = new ComboBox();
            txtId = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            label3 = new Label();
            txtCode = new TextBox();
            label2 = new Label();
            cboFiliere = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvClasse = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasse).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboNiveau);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboFiliere);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(4, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1127, 214);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nouvelle Classe";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cboNiveau
            // 
            cboNiveau.FormattingEnabled = true;
            cboNiveau.Location = new Point(18, 78);
            cboNiveau.Name = "cboNiveau";
            cboNiveau.Size = new Size(221, 40);
            cboNiveau.TabIndex = 10;
            // 
            // txtId
            // 
            txtId.Location = new Point(389, 169);
            txtId.Name = "txtId";
            txtId.Size = new Size(99, 39);
            txtId.TabIndex = 9;
            txtId.Visible = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ControlLight;
            btnDelete.Location = new Point(980, 158);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 46);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "DEL";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button3_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ControlLight;
            btnUpdate.Location = new Point(837, 158);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 46);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "UP";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ControlLight;
            btnAdd.Location = new Point(701, 158);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 46);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(638, 44);
            label3.Name = "label3";
            label3.Size = new Size(65, 30);
            label3.TabIndex = 5;
            label3.Text = "Code";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(638, 78);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(175, 39);
            txtCode.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(340, 46);
            label2.Name = "label2";
            label2.Size = new Size(71, 30);
            label2.TabIndex = 3;
            label2.Text = "Filiere";
            // 
            // cboFiliere
            // 
            cboFiliere.FormattingEnabled = true;
            cboFiliere.Location = new Point(340, 77);
            cboFiliere.Name = "cboFiliere";
            cboFiliere.Size = new Size(219, 40);
            cboFiliere.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 44);
            label1.Name = "label1";
            label1.Size = new Size(80, 30);
            label1.TabIndex = 1;
            label1.Text = "Niveau";
            label1.Click += label1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvClasse);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(12, 247);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1127, 427);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Liste des Classes";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // dgvClasse
            // 
            dgvClasse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasse.Location = new Point(29, 52);
            dgvClasse.Name = "dgvClasse";
            dgvClasse.RowHeadersWidth = 62;
            dgvClasse.Size = new Size(1055, 360);
            dgvClasse.TabIndex = 0;
            // 
            // VClasse
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "VClasse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClasse).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label3;
        private TextBox txtCode;
        private Label label2;
        private ComboBox cboFiliere;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvClasse;
        private TextBox txtId;
        private ComboBox cboNiveau;
    }
}
