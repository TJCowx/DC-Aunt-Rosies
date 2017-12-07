using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuntRosiesBookkeeping.Views
{
    /// <summary>
    /// Interaction logic for ManageEmployeesView.xaml
    /// </summary>
    public partial class ManageEmployeesView : UserControl
    {
        public ManageEmployeesView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validates all the fields and a confirmation before it submits the changes to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessages = "";      // Holds the error messages

            // TODO: VALIDATE FIELDS


            // If there is no errors confirm changes to datbase
            if (errorMessages == "")
            {
                // TODO: CONFIRM SAVED CHANGES
                if (MessageBox.Show("Save changes?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    // TODO: INSERT CHANGES INTO THE DATABASE

                }
                else
                {
                    // TODO: idk sometihng if necessary
                }
            }
            else
            {
                // Display errors to the user
            }
            
        }

        /// <summary>
        /// Handles checking the length of a textbox
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="length"></param>
        /// <param name="e"></param>
        private bool validateLength(TextBox textbox, int length)
        {
            if (textbox.Text.Length >= length)      // Check if the length is under supplied limit
                return false;
            else
                return true;
        }

        #region ================PREVIEW TEXT INPUTS=====================
        /// <summary>
        /// Previews input and filters input for only numbers,
        /// one decimal point, and 2 decimal points after
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var salary = sender as TextBox;     // Stores the textbox as a variable

            // Checks to see if there is a number to two decimal points
            if (Regex.IsMatch(salary.Text, @"^[0-9]+\.[0-9]{2}$"))
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            // Checks to see if there is a decimal point
            else if (salary.Text.Contains("."))
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
            // Otherwise
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9.-]+");     // Allows numbers and decimals
            }
        }

        /// <summary>
        /// Validates the input in the phone number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var phoneNumber = sender as TextBox;     // Stores the textbox as a variable
            if (phoneNumber.Text.Length >= 10)
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }

        }

        /// <summary>
        /// Validates the input in the cellphone number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCellPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var phoneNumber = sender as TextBox;     // Stores the textbox as a variable
            if(phoneNumber.Text.Length >= 10)
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
        }

        /// <summary>
        /// Validates the input in the hours worked textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHoursWorked_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var hours = sender as TextBox;     // Stores the textbox as a variable

            // Checks to see if there is a number to two decimal points
            if (Regex.IsMatch(hours.Text, @"^[0-9]+\.[0-9]{2}$"))
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            // Checks to see if there is a decimal point
            else if (hours.Text.Contains("."))
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
            // Otherwise
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9.-]+");     // Allows numbers and decimals
            }
        }

        /// <summary>
        /// Allows only 30 characters in the first name box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var inputBox = sender as TextBox;
            if(inputBox.Text.Length >= 30)      // Check if the length is under 30
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
        }

        #endregion

        /// <summary>
        /// Allows only 30 characters to be entered in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var inputBox = sender as TextBox;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
