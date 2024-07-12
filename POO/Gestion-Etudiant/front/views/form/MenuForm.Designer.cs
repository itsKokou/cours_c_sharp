namespace Gestion_Etudiant.front.views.form
{
    partial class MenuForm
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
            panel1 = new Panel();
            labelInfo = new Label();
            menuDeconnexion = new Button();
            menuClasse = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(labelInfo);
            panel1.Controls.Add(menuDeconnexion);
            panel1.Controls.Add(menuClasse);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 954);
            panel1.TabIndex = 1;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInfo.Location = new Point(12, 9);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(76, 30);
            labelInfo.TabIndex = 2;
            labelInfo.Text = "label1";
            labelInfo.Click += label1_Click;
            // 
            // menuDeconnexion
            // 
            menuDeconnexion.Location = new Point(12, 808);
            menuDeconnexion.Name = "menuDeconnexion";
            menuDeconnexion.Size = new Size(185, 34);
            menuDeconnexion.TabIndex = 1;
            menuDeconnexion.Text = "Deconnexion";
            menuDeconnexion.UseVisualStyleBackColor = true;
            // 
            // menuClasse
            // 
            menuClasse.Location = new Point(12, 136);
            menuClasse.Name = "menuClasse";
            menuClasse.Size = new Size(185, 34);
            menuClasse.TabIndex = 0;
            menuClasse.Text = "Classe";
            menuClasse.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1898, 954);
            Controls.Add(panel1);
            ImeMode = ImeMode.Off;
            IsMdiContainer = true;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += MenuForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button menuDeconnexion;
        private Button menuClasse;
        private Label labelInfo;
    }
}