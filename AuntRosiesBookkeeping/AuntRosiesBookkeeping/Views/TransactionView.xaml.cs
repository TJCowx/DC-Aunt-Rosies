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
using AuntRosiesBookkeeping.SpecialClass;
using System.Data.SqlClient;
using System.Configuration;

namespace AuntRosiesBookkeeping.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        #region  VARIABLES
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString);

        const double TAX_RATE = 0.15;

        private aunt_rosieDataSet auntRosieDataset;
        private aunt_rosieDataSetTableAdapters.productsTableAdapter productsTableAdapter;

        private double subTotal;
        private double total;
        private double rounding;
        private double tax;

        #endregion

        public TransactionView()
        {
            InitializeComponent();
            RefreshProductsList(0);
        }

        private void txtQuant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var quantity = sender as TextBox;     // Stores the textbox as a variable
            //Tests if text is numeric
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
        }

        /// <summary>
        /// Add the transaction to the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteTransaction_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Create SQL script for adding a new transaction
            string sqlInsertTransaction = "INSERT INTO transactions(staffId, transactionDate, transactionSubTotal, transactionTotal) " +
                "VALUES(@staffID, @transactionDate, @transactionSubTotal, @transactionTotal); SELECT SCOPE_IDENTITY();";
            string sqlInsertTransactionProducts = "INSERT INTO transaction_products(transactionsId, productId, numberOfProductsSold) " +
                "VALUES(@transId, @productId, @quantity)";


            SqlCommand cmd = new SqlCommand(sqlInsertTransaction, connection);
            SqlDataAdapter insertTransaction = new SqlDataAdapter(cmd);     // SQL Adapter to insert the data into the dataset
            // TODO: Create and execute SQL for adding the products for the transaction
            //cmd.Parameters.Add("@transId");
            cmd.Parameters.AddWithValue("@staffId", 1);         // TODO: Make it so employees can change
            cmd.Parameters.AddWithValue("@transactionSubTotal", subTotal);
            cmd.Parameters.AddWithValue("@transactionTotal", total);
            cmd.Parameters.AddWithValue("@transactionDate", DateTime.Now);

            // Execute the query to insert the transaction
            try
            {
                connection.Open();  // Open the connection
                                    // Execute the query and getthe autnumbered ID
                int transId = Convert.ToInt16(cmd.ExecuteScalar());
                insertTransaction.Update(auntRosieDataset.transactions);        // Update the database
                //MessageBox.Show(transId.ToString());

                // Insert each transaction product into the table
                for(int i = 0; i < lstCurrentTransaction.Items.Count; i++)
                {
                    TransactionItem product = (TransactionItem)lstCurrentTransaction.Items.GetItemAt(i);    // Get the info stored in the listview item
                    

                    // Insert info into the transaction_products table
                    cmd = new SqlCommand(sqlInsertTransactionProducts, connection);
                    cmd.Parameters.AddWithValue("@transId", transId);
                    cmd.Parameters.AddWithValue("@productId", product.ProductId);
                    cmd.Parameters.AddWithValue("@quantity", product.ProductQuantity);

                    insertTransaction = new SqlDataAdapter(cmd);        // Adapter to update the dataset

                    // Execyte the query
                    cmd.ExecuteNonQuery();

                    insertTransaction.Update(auntRosieDataset.transaction_products);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting the transaction!\n" + ex.Message);
            }
            finally
            {   
                connection.Close();     // Close the connection
                // Clear the form for a new transaction
                subTotal = 0;
                lstCurrentTransaction.Items.Clear();
                UpdateTotals();
            }

        }

        /// <summary>
        /// Add the product to the transaction listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            bool updatedProduct = false;    // Flag to check if a product was updated
            // Stores the product to be added information
            int productQuantity;
            int productId;
            string productName;
            double productPrice;
            double addedProductPrice = 0;

            // Parse the quantity
            if (int.TryParse(txtQty.Text, out quantity))
            {
                // Check if there is a quantity above 0 
                if (quantity > 0)
                {
                    // Get the productID
                    productId = (int)((DataRowView)lstProducts.SelectedItems[0])["productId"];
                    // Get the quantity of the product
                    productQuantity = (int)((DataRowView)lstProducts.SelectedItems[0])["productQuantity"];
                    // Get the product name
                    productName = (string)((DataRowView)lstProducts.SelectedItems[0])["productDescription"];
                    // Get the product price
                    productPrice = (double)((DataRowView)lstProducts.SelectedItems[0])["productPrice"];

                    // Search for a matching item in the transaction listview
                    for (int i = 0; i < lstCurrentTransaction.Items.Count; i++)
                    {
                        TransactionItem product = (TransactionItem)lstCurrentTransaction.Items.GetItemAt(i);
                        // Compare items to see if there is already a product in the transaction
                        if(product.ProductDescription == productName)
                        {        
                            addedProductPrice = quantity * productPrice;    // Get the price to be added
                            subTotal += addedProductPrice;     // Add the price to the subtotal
                            addedProductPrice += Convert.ToDouble(product.ProductPrice);
                            // Update the transaction item
                            // Add new values
                            lstCurrentTransaction.Items.Add(new TransactionItem { ProductId = product.ProductId, ProductDescription = product.ProductDescription, ProductPrice = string.Format("{0:0.00}",addedProductPrice), ProductQuantity = (product.ProductQuantity += quantity) });
                            lstCurrentTransaction.Items.RemoveAt(i);    // Remove old values

                            updatedProduct = true;      // Flag that there was a product in the transaction view
                        }
                    }

                    // If there wasn't a product already in the current transaction view
                    if (!updatedProduct)
                    {
                        addedProductPrice = productPrice * quantity;    // get the total product price
                        Math.Round(addedProductPrice, 2);       // Round to two decimal points
                        // Add the item to the current transaction
                        lstCurrentTransaction.Items.Add(new TransactionItem { ProductId=productId, ProductDescription = productName, ProductPrice = string.Format("{0:0.00}", addedProductPrice), ProductQuantity = quantity });
                        subTotal += addedProductPrice;     // Add the price to the subtotal
                    }

                    

                    UpdateTotals();     // Refresh the totals textboxes

                    txtQty.Text = "1";        // reset the quantity textbox to the default
                }
                else
                {
                    MessageBox.Show("You must have a number above 0!", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("You must have a whole number!", "Error!", MessageBoxButton.OK);
            }
            
        }

        /// <summary>
        /// Remove all the products from the transaction listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAllProduct_Click(object sender, RoutedEventArgs e)
        {
            lstCurrentTransaction.Items.Clear();        // Removes all the items from the listview
            subTotal = 0;       // Set the subtotal to 0
            UpdateTotals();     // Update all the totals from the new subtotal
        }

        /// <summary>
        /// Removes the selected product from the transaction listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            // Remove selected products from the current transaction listview
            if (lstCurrentTransaction.SelectedItem != null)
            {
                double priceToRemove;       // The price to be removed from the subtotal
                TransactionItem product = (TransactionItem)lstCurrentTransaction.Items.GetItemAt(lstCurrentTransaction.SelectedIndex);
                priceToRemove = Convert.ToDouble(product.ProductPrice);
                subTotal -= priceToRemove;      // Remove the item's price
                UpdateTotals();         // Update the totals textboxes
                lstCurrentTransaction.Items.RemoveAt(lstCurrentTransaction.SelectedIndex);    // Remove the itme
            }
        }

        /// <summary>
        /// Update all the prices, subtotal, total, taxes, rounding
        /// </summary>
        private void UpdateTotals()
        {            
            tax = subTotal * TAX_RATE;      // Get the tax
            Math.Round(tax, 2);             // Round the tax to two decimal places            
            total = Math.Round((subTotal + tax)*20)/20;      // Get the total
            Math.Round(total, 2);           // Round to 2 decimal places
            rounding = total - (subTotal + tax);        // Get the rounding numbers

            // Update the cost labels
            lblSubTotal.Content = subTotal.ToString("C");
            lblTax.Content = tax.ToString("C");
            lblRounding.Content = rounding.ToString("C");
            lblTotal.Content = total.ToString("C");
        }

        /// <summary>
        /// Refreshed the product listview
        /// </summary>
        /// <param name="selectedRecord"></param>
        private void RefreshProductsList(int selectedRecord)
        {
            auntRosieDataset = new aunt_rosieDataSet();     // Declae the dataset
            productsTableAdapter = new aunt_rosieDataSetTableAdapters.productsTableAdapter();
            productsTableAdapter.Fill(auntRosieDataset.products);

            // Populate the listview
            lstProducts.SelectedIndex = selectedRecord;     // Select the record
            lstProducts.ItemsSource = auntRosieDataset.products;
        }

    }
}
