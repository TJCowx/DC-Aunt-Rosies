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
using System.Configuration;
using System.ComponentModel;

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

        int productId;

        private const string SAVE_CHANGES = "Save Changes";
        private const string ADD_PRODUCT = "Add Product";
        private const string CANCEL = "Cancel";


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
            RecipeView recipe = new RecipeView(productId);
            recipe.Show();
        }

        /// <summary>
        /// Preview text input for price to make it only be able to type in certain characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (btnAddProduct.Content.ToString() == ADD_PRODUCT)
            {
                DisableFields(true);
                txtPrice.Text = "";
                txtProductName.Text = "";
                txtQtyProd.Text = "";
                cmbProductType.SelectedIndex = 0;
            }
            else
            {
                DisableFields(false);
            }
        }

        /// <summary>
        /// Remove a product from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            int recipeId;
            DataRowView productRow = lstProductList.Items.GetItemAt(lstProductList.SelectedIndex) as DataRowView;

            if (productRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the product?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    productId = (int)productRow["productId"];   // Product ID

                    // Get the recipe the product is in
                    string sqlGetRecipeId = "SELECT productRecipeId FROM product_recipes " +
                        "WHERE productId='" + productId + "';";
                    SqlCommand cmd = new SqlCommand(sqlGetRecipeId, connection);
                    connection.Open();
                    recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();

                    // Remove the product from everywhere
                    string sqlRemoveProducts = "DELETE FROM products " +
                        "WHERE productId='" + productId + "'; " +
                        "DELETE FROM product_recipes " +
                        "WHERE productId='" + productId + "'; " +
                        "DELETE FROM recipe_inventory " +
                        "WHERE productRecipeId='" + recipeId + "';";
                    cmd = new SqlCommand(sqlRemoveProducts, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    RefreshProductsView(0);
                }
            }
        }

        private void lstProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When a product is selected
            if (lstProductList.SelectedItem != null)
            {
                RefreshProductsInfo();
            }
        }

        
        #region CUSTOM FUNCTIONS
        /// <summary>
        /// Refresh the ingredients listview
        /// </summary>
        private void RefreshProductsInfo()
        {
            // Get the selected row
            DataRowView productRow = lstProductList.Items.GetItemAt(lstProductList.SelectedIndex) as DataRowView;

            // If the row isn't null
            if (productRow != null)
            {
                
                // Load the information from the record
                productId = (int)productRow["productId"];

                string productName = (String)productRow["productDescription"];
                int productQuantity = (int)productRow["productQuantity"];
                string productTypeDescription = (String)productRow["productTypeDescriptions"];
                double productPrice = (double)productRow["productPrice"];

                #region LOAD FIELDS
                txtProductName.Text = productName;
                txtQtyProd.Text = productQuantity.ToString();
                txtPrice.Text = productPrice.ToString();

                #region GET TYPE
                var conn = ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString;
                // Data adapter to get the type
                SqlDataAdapter typeAdapter = new SqlDataAdapter("SELECT productTypeId, productTypeDescriptions FROM product_types", conn);

                DataTable type = new DataTable();  // Data table that holds units for the selected ingredient
                typeAdapter.Fill(type);       // Fill the datatable with the units

                cmbProductType.ItemsSource = type.DefaultView;
                cmbProductType.DisplayMemberPath = "productTypeDescriptions";       // Set the display to be a string
                cmbProductType.SelectedValuePath = "productTypeId";     // Value is the description

                if (productTypeDescription == "Pie")
                {
                    cmbProductType.SelectedIndex = 0;
                }
                else if (productTypeDescription == "Preserves")
                {
                    cmbProductType.SelectedIndex = 1;
                }
                else if (productTypeDescription == "Preserve")
                {
                    cmbProductType.SelectedIndex = 1;
                }
                #endregion
                #endregion

            }
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
            lstProductList.ItemsSource = auntRosieDataset.productItemsView;
            lstProductList.SelectedIndex = selectedRecord;  // Set the selected record
        }

        private void DisableFields(bool disable)
        {
            if(disable)
            {
                // Rename the buttons
                btnAddProduct.Content = CANCEL;
                btnSaveChanges.Content = ADD_PRODUCT;

                // Enable the fields
                btnRemoveProduct.IsEnabled = false;
                btnChangeRecipe.IsEnabled = false;
                lstProductList.IsEnabled = false;
            }
            else
            {
                // Rename the buttons
                btnAddProduct.Content = ADD_PRODUCT;
                btnSaveChanges.Content = SAVE_CHANGES;

                // Enable the fields
                btnRemoveProduct.IsEnabled = true;
                btnChangeRecipe.IsEnabled = true;
                lstProductList.IsEnabled = true;
                RefreshProductsView(0);
            }
        }

        #endregion

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string errorMessages = "";

            #region VALIDATION
            // Validate product name
            if(txtProductName.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a product name!";
            }
            else if(txtProductName.Text.Length > 100)
            {
                errorMessages += "\nThe product name must be less than 100 characters";
            }

            // Validate the quantity
            if(txtQtyProd.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a quantity";
            }
            else if(Regex.IsMatch(txtQtyProd.Text, "[^0-9]+"))
            {
                errorMessages += "\nYou must enter a whole numerical value";
            }
            // Validate the price    
            if(txtPrice.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a price!";
            }
            else if(!Regex.IsMatch(txtPrice.Text, @"\d+(\.\d{1,2})?"))
            {
                errorMessages += "\nYou must enter a valid numerical value";
            }

            #endregion

            // If there are no error messages
            if (errorMessages == "")
            {
                if (btnSaveChanges.Content.ToString() == SAVE_CHANGES)
                {
                    if (MessageBox.Show("Save changes?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        #region UPDATE PRODUCT
                        // SQL statement to update the employee info
                        string sqlUpdateProduct = "UPDATE products SET " +
                            " productDescription=@productDescription, productQuantity=@productQuantity, " +
                            " productPrice=@productPrice " +
                            " WHERE productId='" + productId + "'";
                        SqlCommand cmd = new SqlCommand(sqlUpdateProduct, connection);    // Command to execute

                        // Add the parameters
                        cmd.Parameters.AddWithValue("@productDescription", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@productQuantity", txtQtyProd.Text);
                        cmd.Parameters.AddWithValue("@productPrice", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@productTypeId", cmbProductType.SelectedIndex);

                        // Execute the query
                        connection.Open();      // Open the connection
                        auntRosieDataset = new aunt_rosieDataSet();
                        SqlDataAdapter productsAdapter = new SqlDataAdapter(cmd);     // Create the data adapter
                        cmd.ExecuteNonQuery();  // Execute the query
                        productsAdapter.Update(auntRosieDataset.staff);      // Update the information into the dataset

                        connection.Close(); // Close the connection

                        // Refresh the employee listview
                        RefreshProductsView(productId);

                        #endregion
                    }
                }
                else
                {
                    #region ADD INVENTORY ITEM
                    // SQL to insert product info
                    string sqlInsertProduct = "INSERT INTO products (" +
                        " productTypeId, productDescription, productQuantity," +
                        " productPrice) VALUES (@productTypeId, @productDescription," +
                        " @productQuantity, @productPrice); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(sqlInsertProduct, connection);
                    auntRosieDataset = new aunt_rosieDataSet();
                    SqlDataAdapter insertProductAdapter = new SqlDataAdapter(cmd);

                    // Add the values
                    cmd.Parameters.AddWithValue("@productTypeId", cmbProductType.SelectedValue);
                    cmd.Parameters.AddWithValue("@productDescription", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@productQuantity", Convert.ToDouble(txtQtyProd.Text));
                    cmd.Parameters.AddWithValue("@productPrice", Convert.ToDouble(txtPrice.Text));

                    // Open connection
                    connection.Open();

                    // Execute the query and get the product Id
                    int prodId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Update information
                    insertProductAdapter.Update(auntRosieDataset.products);

                    connection.Close();

                    // Add product into the recipe table
                    // SQL for inserting a record into the recipe table
                    string sqlInsertRecipe = "INSERT INTO product_recipes " +
                        " (productId) VALUES (@productId)";
                    cmd = new SqlCommand(sqlInsertRecipe, connection);
                    cmd.Parameters.AddWithValue("@productId", prodId);

                    SqlDataAdapter insertRecipeAdapter = new SqlDataAdapter(cmd);

                    connection.Open();
                    // Execute the query
                    cmd.ExecuteNonQuery();

                    connection.Close();

                    DisableFields(false);
                    RefreshProductsView(lstProductList.Items.Count);

                    #endregion
                }
            }
            else
            {
                // Display errors to the user
                MessageBox.Show(errorMessages, "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
