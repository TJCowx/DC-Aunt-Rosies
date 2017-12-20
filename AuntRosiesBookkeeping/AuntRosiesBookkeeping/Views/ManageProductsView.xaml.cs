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
                SqlDataAdapter typeAdapter = new SqlDataAdapter("SELECT productTypeDescriptions as string FROM product_types", conn);

                DataTable type = new DataTable();  // Data table that holds units for the selected ingredient
                typeAdapter.Fill(type);       // Fill the datatable with the units

                cmbProductType.ItemsSource = type.DefaultView;
                cmbProductType.DisplayMemberPath = "string";       // Set the display to be a string
                cmbProductType.SelectedValuePath = "productTypeDescriptions";     // Value is the description

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

        #endregion

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string errorMessages = "";
            #region VALIDATION
            #endregion
            if (errorMessages == "")
            {
                // TODO: CONFIRM SAVED CHANGES
                if (MessageBox.Show("Save changes?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    // SQL statement to update the employee info
                    string sqlUpdateProduct = "UPDATE products SET " +
                        " productDescription=@productDescription, productQuanitiy=@productQuanitiy, productTypeId=@productTypeId, " +
                        " productPrice=@productPrice, " +
                        " WHERE staffId='" + productId + "'";
                    SqlCommand cmd = new SqlCommand(sqlUpdateProduct, connection);    // Command to execute

                    // Add the parameters
                    cmd.Parameters.AddWithValue("@productDescription", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@productQuanitiy", txtQtyProd.Text);
                    cmd.Parameters.AddWithValue("@productPrice", txtPrice);
                    cmd.Parameters.AddWithValue("@productTypeId", cmbProductType.SelectedIndex);

                    // Execute the query
                    connection.Open();      // Open the connection
                    auntRosieDataset = new aunt_rosieDataSet();
                    SqlDataAdapter staffEmployees = new SqlDataAdapter(cmd);     // Create the data adapter
                    cmd.ExecuteNonQuery();  // Execute the query
                    staffEmployees.Update(auntRosieDataset.staff);      // Update the information into the dataset

                    connection.Close(); // Close the connection

                    // Refresh the employee listview
                    RefreshProductsView(productId);
                    // RefreshEmployeeInfo(true);
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
