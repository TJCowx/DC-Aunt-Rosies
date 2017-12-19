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
            lstInventoryList.SelectedIndex = selectedRecord;  // Set the selected record
            lstInventoryList.ItemsSource = auntRosieDataset.inventoryItemsView;
        }

        private void RefreshIngredientsInfo()
        {
            // Get the selected row
            DataRowView inventoryRow = lstInventoryList.Items.GetItemAt(lstInventoryList.SelectedIndex) as DataRowView;

            // If the row isn't null
            if(inventoryRow != null)
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
                SqlDataAdapter unitsAdapter = new SqlDataAdapter("SELECT measurementDescription as string FROM measurement_type", conn);

                DataTable units = new DataTable();  // Data table that holds units for the selected ingredient
                unitsAdapter.Fill(units);       // Fill the datatable with the units

                cmbMeasurementScale.ItemsSource = units.DefaultView;
                cmbMeasurementScale.DisplayMemberPath = "string";       // Set the display to be a string
                cmbMeasurementScale.SelectedValuePath = "measurementDescription";     // Value is the description

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
                SqlDataAdapter typesAdapter = new SqlDataAdapter("SELECT inventoryTypeDescription as string FROM inventory_type", conn);

                DataTable types = new DataTable();  // Data table that holds types for the selected ingredient
                typesAdapter.Fill(types);       // Fill the datatable with the types

                cmbType.ItemsSource = types.DefaultView;
                cmbType.DisplayMemberPath = "string";       // Set the display to be a string
                cmbType.SelectedValuePath = "inventoryTypeDescription";     // Value is the description

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
        #endregion
    }
}
