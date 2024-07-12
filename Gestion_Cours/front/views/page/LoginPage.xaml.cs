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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = System.Windows.Application;

namespace Gestion_Cours.front.views.page
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, ILoginPage
    {
        public string ErrorMessage { get => txtError.Text; set => txtError.Text = value; }
        public string Login { get =>txtEmail.Text; set => txtEmail.Text = value; }
        public string Password { get => passwordBox.Password; set => passwordBox.Password=value; }

        public event EventHandler ClickBtnConnexion;

        private LoginPage()
        {
            InitializeComponent();

            btnConnexion.Click += delegate
            {
                ClickBtnConnexion.Invoke(this, EventArgs.Empty);
            };
        }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }


        private static LoginPage instancePage = null;
        public static LoginPage GetInstance()
        {
            if (instancePage == null)
            {
                instancePage = new LoginPage();
            }
            return instancePage;
        }
    }
}
