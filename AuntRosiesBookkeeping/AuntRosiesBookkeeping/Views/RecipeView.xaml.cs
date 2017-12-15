using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Window
    {
        #region DECLARATIONS
        private aunt_rosieDataSet auntRosieDataset;
        private aunt_rosieDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
        private aunt_rosieDataSetTableAdapters.product_recipesTableAdapter productRecipiesTableAdapter;
        #endregion

        public RecipeView()
        {
            InitializeComponent();
        }

        private void txtQuant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var quantity = sender as TextBox;     // Stores the textbox as a variable
            //Tests if text is numeric
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
        }

        /// <summary>
        /// On form loaded populate the listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecipeView_Loaded(object sender, RoutedEventArgs e)
        {
            auntRosieDataset = new aunt_rosieDataSet();
            inventoryTableAdapter = new aunt_rosieDataSetTableAdapters.inventoryTableAdapter();
            inventoryTableAdapter.Fill(auntRosieDataset.inventory);

            lstIngredients.ItemsSource = auntRosieDataset.inventory;        // Fills the list from the data that is needed
            // Load the ingredients listview
            // Populate the columns


            // Empty the recipe listview

        }

        /// <summary>
        /// Add the selected ingredient to the recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add ingredient to the recipe listbox
        }

        /// <summary>
        /// Remove the selected recipe ingredient 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected ingredients from recipe listbox
            foreach(ListViewItem item in lstRecipe.SelectedItems)
            {
                lstRecipe.Items.Remove(item);
            }
        }

        /// <summary>
        /// Remove all ingredients from the recipe table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAllIngredients_Click(object sender, RoutedEventArgs e)
        {
            // Clear recipe listbox
            lstRecipe.Items.Clear();
            
        }

        /// <summary>
        /// Save the recipe and return to the previous menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            // TODO: SQL Query to change/update the recipe

            String sql = "UPDATE ";    // SQL command to be executed

            this.Close();   // Close this box
        }
    }
}
