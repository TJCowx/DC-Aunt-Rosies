using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AuntRosiesBookkeeping.Views
{
    /// <summary>
    /// Interaction logic for AdminLoginView.xaml
    /// </summary>
    public partial class AdminLoginView : Window
    {
        public event EventHandler LoginSuccessful;

        public AdminLoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks if the user is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string adminName = "admin";
            string adminPassword = "password";

            // Checks if password & username are correct
            if (txtPassword.Password.ToString() == adminPassword && txtUsername.Text == adminName)
            {
                OnLoginSuccessful(e);           // Raise login successful event
                this.Close();                   // Close the login box
            }
            else   // Otherwise incorrect login
            {
                MessageBox.Show("Incorrect username & password!", "Incorrect Login", MessageBoxButton.OK);      // Show errored
                txtPassword.Password = "";      // Empty the login box
            }
        }

        /// <summary>
        /// LoginSuccessful check if null
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnLoginSuccessful(EventArgs e)
        {
            if (LoginSuccessful != null)
                LoginSuccessful(this, e);
        }

        /// <summary>
        /// Cancels login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
