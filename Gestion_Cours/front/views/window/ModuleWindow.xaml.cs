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
using Application = System.Windows.Application;

namespace Gestion_Cours.front.views.window
{
    /// <summary>
    /// Logique d'interaction pour ModuleWindow.xaml
    /// </summary>
    public partial class ModuleWindow : Window, IModuleWindow
    {
        private ModuleWindow()
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
        public void setModuleBindingSource(BindingSource moduleList)
        {
            dgClasseModule.ItemsSource = moduleList;
        }

        private static ModuleWindow instancePage = null;
        public static ModuleWindow GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new ModuleWindow();
            }
            return instancePage;
        }

        public void ShowWindow()
        {
            Show();
        }
    }
}
