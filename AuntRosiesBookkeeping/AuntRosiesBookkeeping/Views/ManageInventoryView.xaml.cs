using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManageIngredientsView.xaml
    /// </summary>
    public partial class ManageInventoryView : UserControl
    {
        #region VARIABLES
        bool newInventory = false;
        int inventoryId;

        private aunt_rosieDataSet auntRosieDataset;

        private aunt_rosieDataSetTableAdapters.inventoryItemsViewTableAdapter inventoryItemsViewTableAdapter;
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
            if (lstInventoryList.SelectedItem != null)
            {
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
                double inventoryPrice = Convert.ToDouble(inventoryRow["productPrice"]);

                #region LOAD FIELDS
                txtInventoryName.Text = inventoryName;
                txtQty.Text = inventoryQuantity.ToString();
                // TODO: PRICE
                // TODO: MEASUREMENT
                // TODO: TYPE

                #endregion
            }
        }
        #endregion
    }
}
