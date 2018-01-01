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
using System.Configuration;
using System.Windows.Shapes;
using AuntRosiesBookkeeping.SpecialClass;

namespace AuntRosiesBookkeeping.Views
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Window
    {
        #region DECLARATIONS
        private aunt_rosieDataSet auntRosieDataset;
        //private aunt_rosieDataSetTableAdapters.recipe_inventoryTableAdapter inventoryItemsTableAdapter;
        private aunt_rosieDataSetTableAdapters.inventoryItemsViewTableAdapter inventoryItemsTableAdapter;
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString);
        private int productId;
        #endregion

        public RecipeView()
        {
            InitializeComponent();
        }

        public RecipeView(int prodId)
        {
            InitializeComponent();
            this.productId = prodId;
            RefreshProductsList(0);
            RefreshRecipeList(0);
            txtQuant.Text = "1";
        }

        private void txtQuant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var salary = sender as TextBox;     // Stores the textbox as a variable

            // Checks to see if there is a number to two decimal points
            if (Regex.IsMatch(salary.Text, @"^[0-9]*\.[0-9]{2}$"))
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
        /// On form loaded populate the listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecipeView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Add the selected ingredient to the recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            double quantity = 0;       // Quantity to be added to recipe
            bool updatedIngredient = false;     // Flag to check if something was updated

            // Variables on information to be stored into the recipe
            int inventoryId;
            string inventoryName;
            string inventoryType;
            string measurement;

            // Check if there is a selected item
            if (lstIngredients.SelectedItem != null)
            {
                // Parse the quantity
                if(double.TryParse(txtQuant.Text, out quantity))
                {
                    // Check if there is a quantity
                    if (quantity > 0)
                    {
                        inventoryId = (int)((DataRowView)lstIngredients.SelectedItems[0])["inventoryId"];
                        inventoryName = (string)((DataRowView)lstIngredients.SelectedItems[0])["inventoryDescription"];
                        inventoryType = (string)((DataRowView)lstIngredients.SelectedItems[0])["inventoryTypeDescription"];
                        measurement = (string)((DataRowView)lstIngredients.SelectedItems[0])["measurementDescription"];

                        // Check to see if there is already the ingredient in the recipe view
                        for(int i = 0; i < lstRecipe.Items.Count; i++)
                        {
                            InventoryItem item = (InventoryItem)lstRecipe.Items.GetItemAt(i);

                            // Compare items to see if there is already the ingredient in the recipe
                            if(item.InventoryDescription == inventoryName)
                            {
                                lstRecipe.Items.Add(new InventoryItem
                                {
                                    InventoryId = item.InventoryId,
                                    InventoryDescription = item.InventoryDescription,
                                    InventoryType = item.InventoryType,
                                    InventoryQuantity = item.InventoryQuantity + quantity,
                                    Measurement = item.Measurement
                                });
                                
                                lstRecipe.Items.RemoveAt(i);    // Remove old values
                                i = lstRecipe.Items.Count;      // Break out of the loop or will double add
                                updatedIngredient = true;   // Flag so new product isn't added
                            }
                        }

                        // If an ingredient wasn't already updated
                        if(!updatedIngredient)
                        {
                            // Add the ingredient to the recipe
                            lstRecipe.Items.Add(new InventoryItem
                            {
                                InventoryId = inventoryId,
                                InventoryDescription = inventoryName,
                                InventoryType = inventoryType,
                                InventoryQuantity = quantity,
                                Measurement = measurement
                            });
                        }
                        // Reset the quantity textbox to the default
                        txtQuant.Text = "1";

                    }
                    else
                    {
                        MessageBox.Show("You must have a quantity above 0!", "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("You must enter a valid number for quantity!", "Error!", MessageBoxButton.OK);
                }

            }

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
            auntRosieDataset = new aunt_rosieDataSet();

            // Get the product recipe Id        
            string sqlRecipeId = "SELECT productRecipeId FROM product_recipes " +
                " WHERE productId='" + productId + "';";
            SqlCommand cmd = new SqlCommand(sqlRecipeId, connection);

            // Get the recipe ID
            connection.Open();
            int recipeId = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            // Remove from database
            string sqlRemoveRecipeInventory = "DELETE FROM recipe_inventory " +
                " WHERE productRecipeId='" + recipeId + "';";
            cmd = new SqlCommand(sqlRemoveRecipeInventory, connection);

            // Execute the remove script
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            // Readd all the recipe items to the recipe inventory table
            string sqlInsertRecipeItem = "INSERT INTO recipe_inventory(" +
                "productRecipeId, inventoryId, inventoryQty) VALUES " +
                "(@productRecipeId, @inventoryId, @inventoryQty);";
            SqlDataAdapter recipeInventoryAdapter;

            // for each item in the recipe list
            for(int i = 0; i < lstRecipe.Items.Count; i++)
            {
                InventoryItem item = (InventoryItem)lstRecipe.Items.GetItemAt(i);
                cmd = new SqlCommand(sqlInsertRecipeItem, connection);
                // Add the values needed for the table
                cmd.Parameters.AddWithValue("@productRecipeId", recipeId);
                cmd.Parameters.AddWithValue("@inventoryId", item.InventoryId);
                cmd.Parameters.AddWithValue("@inventoryQty", item.InventoryQuantity);
                
                // Adapter for the recipe inventory table
                recipeInventoryAdapter = new SqlDataAdapter(cmd);
                connection.Open();
                cmd.ExecuteNonQuery();      // Execute the query
                recipeInventoryAdapter.Update(auntRosieDataset.recipe_inventory);
                connection.Close();
            }

            this.Close();   // Close this box
        }

        private void lstIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region CUSTOM FUNCTIONS
        /// <summary>
        /// Loads the products list
        /// </summary>
        /// <param name="selectedRecord"></param>
        private void RefreshProductsList(int selectedRecord)
        {
            
            auntRosieDataset = new aunt_rosieDataSet();     // Declare the dataset
            inventoryItemsTableAdapter = new aunt_rosieDataSetTableAdapters.inventoryItemsViewTableAdapter();
            inventoryItemsTableAdapter.Fill(auntRosieDataset.inventoryItemsView);

            // Populate the listview
            
            lstIngredients.SelectedIndex = selectedRecord;  // Set the selected record
            lstIngredients.ItemsSource = auntRosieDataset.inventoryItemsView;
        }

        /// <summary>
        /// Loads the recipe list
        /// </summary>
        /// <param name="selectedRecord"></param>
        private void RefreshRecipeList(int selectedRecord)
        {
            auntRosieDataset = new aunt_rosieDataSet();     // Insantiate the dataset

            // SQL to get the recipe ID
            string sqlGetRecipeId = "SELECT productRecipeId FROM product_recipes " +
                " WHERE productId='" + productId + "';";
            SqlCommand cmd = new SqlCommand(sqlGetRecipeId, connection);

            // get the recipe id
            connection.Open();
            int recipeId = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            // Get the recipe items
            string sqlGetRecipeItems = "SELECT recipe_inventory.inventoryId, inventory.inventoryDescription, " +
                " recipe_inventory.inventoryQty, measurement_type.measurementDescription, " +
                " inventory_type.inventoryTypeDescription " +
                " FROM recipe_inventory" +
                " LEFT JOIN inventory ON inventory.inventoryId = recipe_inventory.inventoryId " +
                " INNER JOIN inventory_type ON inventory_type.inventoryTypeId = inventory.inventoryTypeId " +
                " INNER JOIN measurement_type ON measurement_type.measurementId = inventory.measurementId " +
                " WHERE productRecipeId ='" + recipeId + "';";

            cmd = new SqlCommand(sqlGetRecipeItems, connection);
            SqlDataReader reader;
            connection.Open();
            reader = cmd.ExecuteReader();

            // While reading get information to be loaded into the recipe field
            while(reader.Read())
            {
                InventoryItem item = new InventoryItem();

                
                item.InventoryId = reader.GetInt32(0);              // Get the ID
                item.InventoryDescription = reader.GetString(1);    // Get inventory name
                item.InventoryQuantity = reader.GetDouble(2);       // get the quantity
                item.Measurement = reader.GetString(3);             // get the measurement
                item.InventoryType = reader.GetString(4);           // get the inventory type

                lstRecipe.Items.Add(item);      // Add the item to the listview
                

            }

            connection.Close();
        }

        #endregion
    }
}
