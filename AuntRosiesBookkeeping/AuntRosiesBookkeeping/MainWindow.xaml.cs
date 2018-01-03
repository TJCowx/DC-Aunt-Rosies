using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using AuntRosiesBookkeeping.ViewModels;
using AuntRosiesBookkeeping.Views;
using AuntRosiesBookkeeping.SpecialClass;

namespace AuntRosiesBookkeeping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

        }

        /// <summary>
        /// On page load set the defaults
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
            
        }


        #region "Menu Items"
        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Go to the home menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHome_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        #region "Report Items"
        /// <summary>
        /// View the report on the ingredients inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRptIngredientsInv_Click(object sender, RoutedEventArgs e)
        {
            
            DataContext = new ReportsViewModel();
            ReportTabInfo._tabIndex = 2;        //Opens the tab into the ingredients inventory report
        }

        /// <summary>
        /// Opens the view product inventory report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRptProductsInv_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsViewModel();
            ReportTabInfo._tabIndex = 3;        //Opens the tab into the products inventory report
            
        }

        /// <summary>
        /// Opens the sales report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRptSales_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsViewModel();
            ReportTabInfo._tabIndex = 1;    //Opens the tab to the sales 
        }

        /// <summary>
        /// Opens the employees report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRptEmployees_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsViewModel();       //Opens new view
            ReportTabInfo._tabIndex = 0;        //Opens the tab to the employees tab
        }

        /// <summary>
        /// Opens the recipe report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRptRecipes_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsViewModel();       //Opens new view
            ReportTabInfo._tabIndex = 4;        //Opens the tab to the employees tab
        }

        #endregion

        #region "Tools"

        /// <summary>
        /// Opens the process transactions page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void mnuProcessTransactions_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TransactionViewModel();
        }


        /// <summary>
        /// Open the manage ingredients inventory page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuManageIngredients_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ManageInventoryViewModel();
        }

        /// <summary>
        /// Open the manage products inventory page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuManageProducts_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ManageProductsViewModel();
        }

        /// <summary>
        /// Open the manage employees page on correct login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuManageEmployees_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginView login = new AdminLoginView();
            login.LoginSuccessful += loginSuccessful_OpenEmployee;      // Add loginsuccessful event trigger
            login.ShowDialog();     // Opens the login view
        }

        /// <summary>
        /// EventHandler: if the login is successful open the employee view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginSuccessful_OpenEmployee(object sender, EventArgs e)
        {
            DataContext = new ManageEmployeeViewModel();
        }

        #endregion

        #endregion

        #region Main Menu

        /// <summary>
        /// Opens the ingredient inventory view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngredientInventory_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ManageInventoryViewModel();
        }

        /// <summary>
        /// Opens the Product Inventory View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductInventory_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ManageProductsViewModel();
        }

        /// <summary>
        /// Opens the Report View on the default tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsViewModel();
            ReportTabInfo._tabIndex = 0;    //Sets the chosen tab to the first one
        }

        /// <summary>
        /// Opens the transactions view page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactions_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TransactionViewModel();
        }


        #endregion


    }
}
