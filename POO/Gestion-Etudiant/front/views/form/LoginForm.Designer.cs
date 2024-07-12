namespace Gestion_Etudiant.front.views.form
{
    partial class LoginForm
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
            btnConnexion = new Button();
            txtPassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtLogin = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConnexion);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtLogin);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(99, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(574, 297);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulaire ";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(344, 235);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(202, 45);
            btnConnexion.TabIndex = 4;
            btnConnexion.Text = "Se Connecter";
            btnConnexion.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(187, 156);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(359, 37);
            txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 159);
            label2.Name = "label2";
            label2.Size = new Size(103, 30);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 74);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(186, 74);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(360, 37);
            txtLogin.TabIndex = 0;
            txtLogin.TextChanged += textBox1_TextChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connexion";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtLogin;
        private Button btnConnexion;
        private TextBox txtPassword;
    }
}