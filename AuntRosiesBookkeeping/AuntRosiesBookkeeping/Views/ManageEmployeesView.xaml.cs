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
            else if(salary.Text.Contains("."))
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
            // Otherwise
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9.-]+");     // Allows numbers and decimals
            }
        }
        
    }
}
