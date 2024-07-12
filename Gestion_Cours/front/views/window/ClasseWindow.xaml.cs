using Gestion_Cours.front.views.page;
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

namespace Gestion_Cours.front.views.window
{
    /// <summary>
    /// Logique d'interaction pour ClasseWindow.xaml
    /// </summary>
    public partial class ClasseWindow : Window, IClasseWindow
    {
        private ClasseWindow()
        {
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }

        public string Message { get => throw new NotImplementedException(); set => txtTitle.Text = value; }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Hide();
            }
        }

        public void setEnseignementBindingSource(BindingSource enseignementList)
        {
            dgClasse.ItemsSource = enseignementList;
        }

        private static ClasseWindow instancePage = null;
        public static ClasseWindow GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new ClasseWindow();
            }
            return instancePage;
        }

        public void ShowWindow()
        {
            Show();
        }
    }
}
