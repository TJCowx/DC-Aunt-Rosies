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
    /// Interaction logic for ManageIngredientsView.xaml
    /// </summary>
    public partial class ManageInventoryView : UserControl
    {
        #region VARIABLES
        bool newInventory = false;
        int inventoryId;

        // Constants for button contents
        private const string ADD_INVENTORY = "Add Inventory";
        private const string CANCEL = "Cancel";
        private const string SAVE_CHANGES = "Save Changes";


        private aunt_rosieDataSet auntRosieDataset;

        private aunt_rosieDataSetTableAdapters.inventoryItemsViewTableAdapter inventoryItemsViewTableAdapter;

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString);
        #endregion

        public ManageInventoryView()
        {
            InitializeComponent();
            RefreshIngredientsView(0);
        }

        #region EVENT HANDLERS

        private void txtQty_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var quantity = sender as TextBox;     // Stores the textbox as a variable
            //Tests if text is numeric
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
        }


        private void lstInventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When a product is selected
            if (lstInventoryList.SelectedItem != null)
            {
                RefreshIngredientsInfo();
                if (!newInventory)
                {

                }
            }
        }

        /// <summary>
        /// Saves changes that are made to the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string errorMessages = "";
            
            #region VALIDATION
            // Validate inventory name
            if (txtInventoryName.Text.Length <= 0)
            {
                errorMessages += "\nYou must have an inventory name";
            }
            else if(txtInventoryName.Text.Length > 100)
            {
                errorMessages += "\nMust only have a max of 100 characters";
            }

            // Validate quantity
            if (txtQty.Text.Length == 0)
            {
                errorMessages += "\nMust enter a quantity";
            }
            else if(!Regex.IsMatch(txtQty.Text, @"\d+(\.\d{1,2})?"))
            {
                errorMessages += "\nQuantity must be a numerical value";
            }

            // Validate price
            if(txtPrice.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a price!";
            }
            else if(!Regex.IsMatch(txtPrice.Text, @"\d+(\.\d{1,2})?"))
            {
                errorMessages += "\nThe price must be a numerical value";
            }

            #endregion

            // If there is no errors
            if(errorMessages == "")
            {
                int currentSelectedInventory = lstInventoryList.SelectedIndex;  // Get selected index

                if (btnSaveChanges.Content.ToString() == SAVE_CHANGES)
                {
                    // Confirm changes
                    if (MessageBox.Show("Save changes?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        #region UPDATE INVENTORY

                        // SQL to update the ingredient info
                        string sqlUpdate = "UPDATE inventory SET " +
                            " inventoryDescription=@inventoryDescription, " +
                            " inventoryTypeId=@inventoryTypeId, " +
                            " inventoryQuantity=@inventoryQuantity, " +
                            " measurementId=@measurementId," +
                            " inventoryPrice=@inventoryPrice " +
                            " WHERE inventoryId='" + inventoryId + "'";

                        SqlCommand cmd = new SqlCommand(sqlUpdate, connection);

                        // Add the values
                        cmd.Parameters.AddWithValue("@inventoryDescription", txtInventoryName.Text);
                        cmd.Parameters.AddWithValue("@inventoryTypeId", cmbType.SelectedValue);
                        cmd.Parameters.AddWithValue("@inventoryQuantity", Convert.ToDouble(txtQty.Text));
                        cmd.Parameters.AddWithValue("@measurementId", cmbMeasurementScale.SelectedValue);
                        cmd.Parameters.AddWithValue("@inventoryPrice", Convert.ToDouble(txtPrice.Text));

                        // Execute the query
                        connection.Open();

                        // Declare dataset and adapter
                        auntRosieDataset = new aunt_rosieDataSet();
                        SqlDataAdapter inventoryItemAdapter = new SqlDataAdapter(cmd);

                        cmd.ExecuteNonQuery();  // Execute

                        // Update information
                        inventoryItemAdapter.Update(auntRosieDataset.inventory);

                        connection.Close();

                        // Refresh the listview
                        RefreshIngredientsView(currentSelectedInventory);
                        
                        #endregion
                    }
                }
                else
                {
                    #region ADD INVENTORY ITEM
                    // SQL to insert product info
                    string sqlInsertInventory = "INSERT INTO inventory (" +
                        " inventoryDescription, inventoryTypeId, " +
                        " inventoryQuantity, measurementId, " +
                        " inventoryPrice) VALUES (" +
                        " @inventoryDescription, @inventoryTypeId," +
                        " @inventoryQuantity, @measurementId, " +
                        " @inventoryPrice)";

                    SqlCommand cmd = new SqlCommand(sqlInsertInventory, connection);
                    // Declare dataset and adapter
                    SqlDataAdapter insertInventoryAdapter = new SqlDataAdapter(cmd);
                    auntRosieDataset = new aunt_rosieDataSet();

                    // Add the values
                    cmd.Parameters.AddWithValue("@inventoryDescription", txtInventoryName.Text);
                    cmd.Parameters.AddWithValue("@inventoryTypeId", cmbType.SelectedValue);
                    cmd.Parameters.AddWithValue("@inventoryQuantity", Convert.ToDouble(txtQty.Text));
                    cmd.Parameters.AddWithValue("@measurementId", cmbMeasurementScale.SelectedValue);
                    cmd.Parameters.AddWithValue("@inventoryPrice", Convert.ToDouble(txtPrice.Text));


                    // Open connection
                    connection.Open();
                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Update information
                    insertInventoryAdapter.Update(auntRosieDataset.inventory);

                    // Close the connection
                    connection.Close();
                    #endregion
                    DisableFields(false);   // Renable the fields
                    // Refresh the listview
                    RefreshIngredientsView(lstInventoryList.Items.Count);
                }
            }
            else
            {
                // Display errors to the user
                MessageBox.Show(errorMessages, "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Sets up form to add new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (btnAddProduct.Content.ToString() == ADD_INVENTORY)
            {
                DisableFields(true);

                // Empty the text boxes
                txtInventoryName.Text = "";
                txtPrice.Text = "";
                txtQty.Text = "";
                cmbMeasurementScale.SelectedIndex = 0;
                cmbType.SelectedIndex = 0;
            }
            else
            {
                DisableFields(false);
                RefreshIngredientsView(0);
            }
        }

        #endregion

        #region CUSTOM FUNCTIONS
        /// <summary>
        /// Refresh the ingredients listview
        /// </summary>
        private void RefreshIngredientsView(int selectedRecord)
        {
            // Load the dataset for the listview
            auntRosieDataset = new aunt_rosieDataSet();     // Declare the dataset
            inventoryItemsViewTableAdapter = new aunt_rosieDataSetTableAdapters.inventoryItemsViewTableAdapter();
            inventoryItemsViewTableAdapter.Fill(auntRosieDataset.inventoryItemsView);

            // Populate the listview            
            lstInventoryList.ItemsSource = auntRosieDataset.inventoryItemsView;
            lstInventoryList.SelectedIndex = selectedRecord;  // Set the selected record
        }

        private void RefreshIngredientsInfo()
        {
            // Get the selected row
            DataRowView inventoryRow = lstInventoryList.Items.GetItemAt(lstInventoryList.SelectedIndex) as DataRowView;

            // If the row isn't null
            if (inventoryRow != null)
            {
                // Load the information from the record
                inventoryId = (int)inventoryRow["inventoryId"];

                string inventoryName = (String)inventoryRow["inventoryDescription"];
                int inventoryQuantity = (int)inventoryRow["inventoryQuantity"];
                string inventoryTypeDescription = (String)inventoryRow["inventoryTypeDescription"];
                string measurementDescription = (String)inventoryRow["measurementDescription"];
                double inventoryPrice = (double)inventoryRow["inventoryPrice"];

                #region LOAD FIELDS
                txtInventoryName.Text = inventoryName;
                txtQty.Text = inventoryQuantity.ToString();
                txtPrice.Text = inventoryPrice.ToString();

                #region GET MEASUREMENT
                var conn = ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString;
                // Data adapter to get the units
                SqlDataAdapter unitsAdapter = new SqlDataAdapter("SELECT measurementId, measurementDescription FROM measurement_type", conn);

                DataTable units = new DataTable();  // Data table that holds units for the selected ingredient
                unitsAdapter.Fill(units);       // Fill the datatable with the units

                cmbMeasurementScale.ItemsSource = units.DefaultView;
                cmbMeasurementScale.DisplayMemberPath = "measurementDescription";       // Set the display to be a string
                cmbMeasurementScale.SelectedValuePath = "measurementId";     // Value is the id

                if (measurementDescription == "mL")
                {
                    cmbMeasurementScale.SelectedIndex = 0;
                }
                else if (measurementDescription == "L")
                {
                    cmbMeasurementScale.SelectedIndex = 1;
                }
                else if (measurementDescription == "tbsp.")
                {
                    cmbMeasurementScale.SelectedIndex = 2;
                }
                else if (measurementDescription == "tsp")
                {
                    cmbMeasurementScale.SelectedIndex = 3;
                }
                else if (measurementDescription == "cups")
                {
                    cmbMeasurementScale.SelectedIndex = 4;
                }
                else if (measurementDescription == "lbs")
                {
                    cmbMeasurementScale.SelectedIndex = 5;
                }
                else if (measurementDescription == "oz")
                {
                    cmbMeasurementScale.SelectedIndex = 6;
                }
                else if (measurementDescription == "g")
                {
                    cmbMeasurementScale.SelectedIndex = 7;
                }
                else if (measurementDescription == "units")
                {
                    cmbMeasurementScale.SelectedIndex = 8;
                }
                #endregion

                #region GET TYPE
                conn = ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString;
                // Data adapter to get the types
                SqlDataAdapter typesAdapter = new SqlDataAdapter("SELECT inventoryTypeId, inventoryTypeDescription FROM inventory_type", conn);

                DataTable types = new DataTable();  // Data table that holds types for the selected ingredient
                typesAdapter.Fill(types);       // Fill the datatable with the types

                cmbType.ItemsSource = types.DefaultView;
                cmbType.DisplayMemberPath = "inventoryTypeDescription";       // Set the display to be a string
                cmbType.SelectedValuePath = "inventoryTypeId";     // Value is the id

                if (inventoryTypeDescription == "Ingredient")
                {
                    cmbType.SelectedIndex = 0;
                }
                else if (inventoryTypeDescription == "Tool")
                {
                    cmbType.SelectedIndex = 1;
                }
                #endregion

                #endregion
            }
        }


        /// <summary>
        /// Disable fields and rename buttons depending on enabling or not
        /// used for adding new inventory items
        /// </summary>
        /// <param name="disable"></param>
        private void DisableFields(bool disable)
        {
            if(disable)
            {
                // Rename the buttons
                btnAddProduct.Content = CANCEL;
                btnSaveChanges.Content = ADD_INVENTORY;

                // Enable the fields
                btnRemoveProduct.IsEnabled = false;
                lstInventoryList.IsEnabled = false;
            }
            else
            {
                // Rename the buttons
                btnSaveChanges.Content = SAVE_CHANGES;
                btnAddProduct.Content = ADD_INVENTORY;

                // Enable the fields
                btnRemoveProduct.IsEnabled = true;
                lstInventoryList.IsEnabled = true;
            }
        }


        #endregion

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRowView inventoryRow = lstInventoryList.Items.GetItemAt(lstInventoryList.SelectedIndex) as DataRowView;

            if (inventoryRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the inventory item?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    int inventoryId = (int)inventoryRow["inventoryId"];

                    string sqlRemoveIngredient = "DELETE FROM inventory " +
                        "WHERE inventoryId='" + inventoryId + "'; " +
                        "DELETE FROM recipe_inventory " +
                        "WHERE inventoryId='" + inventoryId + "';";
                    SqlCommand cmd = new SqlCommand(sqlRemoveIngredient, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    RefreshIngredientsView(0);
                }
            }
        }
    }
}
