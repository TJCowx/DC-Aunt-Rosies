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
    /// Interaction logic for ManageProductsView.xaml
    /// </summary>
    public partial class ManageProductsView : UserControl
    {
        public ManageProductsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open up the Recipe window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeView recipe = new RecipeView();
            recipe.Show();
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var price = sender as TextBox;     // Stores the textbox as a variable
            //Tests if text is numeric
            if (Regex.IsMatch(price.Text, @"^[0-9]+\.[0-9]{2}$"))
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            // Checks to see if there is a decimal point
            else if (price.Text.Contains("."))
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
