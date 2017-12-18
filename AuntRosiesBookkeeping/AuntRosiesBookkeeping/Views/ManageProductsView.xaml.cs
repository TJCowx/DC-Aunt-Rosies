using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        #region VARIABLES
        private aunt_rosieDataSet auntRosieDataset;

        private aunt_rosieDataSetTableAdapters.productItemsViewTableAdapter productItemsViewTableAdapter;

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString);
        #endregion


        public ManageProductsView()
        {
            InitializeComponent();
            RefreshProductsView(0);
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

        /// <summary>
        /// Only allows numbers to be entered in the quantity textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQtyProd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var quantity = sender as TextBox;     // Stores the textbox as a variable
            //Tests if text is numeric
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
        }

        /// <summary>
        /// Add a new product into the databse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Remove a product from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Update the products view
        /// </summary>
        /// <param name="selectedRecord"></param>
        private void RefreshProductsView(int selectedRecord)
        {

            // Load the dataset for the listview
            auntRosieDataset = new aunt_rosieDataSet();     // Declare the dataset
            productItemsViewTableAdapter = new aunt_rosieDataSetTableAdapters.productItemsViewTableAdapter();
            productItemsViewTableAdapter.Fill(auntRosieDataset.productItemsView);

            // Populate the listview
            lstProductList.SelectedIndex = selectedRecord;  // Set the selected record
            lstProductList.ItemsSource = auntRosieDataset.productItemsView;
        }
    }
}
