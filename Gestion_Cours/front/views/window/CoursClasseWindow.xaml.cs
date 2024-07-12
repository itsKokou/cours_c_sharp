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
    /// Logique d'interaction pour CoursClasseWindow.xaml
    /// </summary>
    public partial class CoursClasseWindow : Window, ICoursClasseWindow
    {
        private CoursClasseWindow()
        {
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
          
        }

        public void setClassesBindingSource(BindingSource classeDuCoursList)
        {
            dgClasse.ItemsSource = classeDuCoursList;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Hide();
            }
        }

        private static CoursClasseWindow instancePage = null;
        public static CoursClasseWindow GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new CoursClasseWindow();
            }
            return instancePage;
        }

        public void ShowWindow()
        {
            Show();
        }
    }
}
