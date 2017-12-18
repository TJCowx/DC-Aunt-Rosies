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
    /// Interaction logic for ManageEmployeesView.xaml
    /// </summary>
    public partial class ManageEmployeesView : UserControl
    {
        #region ========VARIABLES===========
        // Constants
        private const int NAME_MAX_LENGTH = 30;
        private const int PHONE_LENGTH = 10;
        private const int ADDRESS_MAX_LENGTH = 50;
        private const int CITY_MAX_LENGTH = 50;
        private const int PROVINCE_MAX_LENGTH = 2;
        private const int POSTAL_CODE_LENGTH = 6;
        private const int HOURS_WORKED_MAX_LENGTH = 6;

        private int empId;      // Employee that is currently selected

        // Dataset
        private aunt_rosieDataSet auntRosieDataset;
        // Table Adapters
        private aunt_rosieDataSetTableAdapters.staffTableAdapter employeeTableAdapter;
        private aunt_rosieDataSetTableAdapters.staffHoursTableAdapter staffHoursTableAdapter;

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString);
        #endregion

        public ManageEmployeesView()
        {
            InitializeComponent();
        }

        #region EVENT HANDLERS



        #region ================PREVIEW TEXT INPUTS=====================

        /// <summary>
        /// Limits the amount of characters someone can input into a textbox
        /// </summary>
        /// <param name="inputBox">Textbox that is being inputted into</param>
        /// <param name="length">Number of characters allowed in the textbox</param>
        /// <param name="e"></param>
        private void limitCharacters(TextBox inputBox, int length, TextCompositionEventArgs e)
        {
            if (inputBox.Text.Length >= length)      // Check if the length is under 30
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
        }

        /// <summary>
        /// Previews input and filters input for only numbers,
        /// one decimal point, and 2 decimal points after
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
        /// Validates the input in the phone number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var phoneNumber = sender as TextBox;     // Stores the textbox as a variable
            if (phoneNumber.Text.Length >= PHONE_LENGTH)
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }

        }

        /// <summary>
        /// Validates the input in the cellphone number textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCellPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var phoneNumber = sender as TextBox;     // Stores the textbox as a variable
            if(phoneNumber.Text.Length >= PHONE_LENGTH)
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
        }

        /// <summary>
        /// Validates the input in the hours worked textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHoursWorked_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var hours = sender as TextBox;     // Stores the textbox as a variable

            // Checks to see if there is a number to two decimal points
            if (Regex.IsMatch(hours.Text, @"^[0-9]+\.[0-9]{2}$"))
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            // Checks to see if there is a decimal point
            else if (hours.Text.Contains("."))
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");  // Allows only numbers 
            }
            else if(hours.Text.Length >= HOURS_WORKED_MAX_LENGTH)     // If there is more than 3 characters
            {
                e.Handled = !Regex.IsMatch(e.Text, "a^");   // Filters out any input
            }
            // Otherwise
            else
            {
                e.Handled = Regex.IsMatch(e.Text, "[^0-9.-]+");     // Allows numbers and decimals
            }
        }

        /// <summary>
        /// Allows only 30 characters in the first name box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, NAME_MAX_LENGTH, e);      // Limits characters
        }

        /// <summary>
        /// Allows only 30 characters to be entered in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, NAME_MAX_LENGTH, e);      // Limits characters
        }

        /// <summary>
        /// Limit the amount of characters allowed to 50
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, NAME_MAX_LENGTH, e);      // Limits characters
        }

        /// <summary>
        /// Limit the amount of characters allowed to 50
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, CITY_MAX_LENGTH, e);      // Limits characters
        }

        /// <summary>
        /// Limit the number of characters allowed to 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProvince_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, PROVINCE_MAX_LENGTH, e);      // Limits characters
        }

        /// <summary>
        /// Limit the number of characters allowed to 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPostalCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            limitCharacters(sender as TextBox, POSTAL_CODE_LENGTH, e);      // Limits characters
        }

        #endregion

        /// <summary>
        /// Validates all the fields and a confirmation before it submits the changes to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string errorMessages = "";      // Holds the error messages

            #region VALIDATION
            // [ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]
            // Validate firstname textbox
            if (txtEmployeeFirstName.Text.Length > NAME_MAX_LENGTH)
            {
                errorMessages += "\nEmployee first name must " + NAME_MAX_LENGTH + " characters or shorter!";
                txtEmployeeFirstName.Text = "";
            }
            else if (txtEmployeeFirstName.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a first name for the employee!";
            }

            // Validate lastname textbox
            if (txtEmployeeLastName.Text.Length > NAME_MAX_LENGTH)
            {
                errorMessages += "\nEmployee last name must be " + NAME_MAX_LENGTH + " characters or shorter!";
                txtEmployeeLastName.Text = "";
            }
            else if (txtEmployeeLastName.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a first name for the employee!";
            }

            // Validate phone textbox
            // Check if there is content inside the textbox
            if (txtPhoneNumber.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a phone number!";
            }
            // Check to see the length of the textbox
            else if (txtPhoneNumber.Text.Length != PHONE_LENGTH)
            {
                errorMessages += "\nPhone number length must be 10 characters";
                txtPhoneNumber.Text = "";
            }
            // Make sure the characters are all numerical
            else if (Regex.IsMatch(txtPhoneNumber.Text, "[^0-9]+"))
            {
                errorMessages += "\nPhone number must be numeric characters only!";
            }

            // Validate cell phone textbox
            if (txtCellPhoneNumber.Text.Length == 0)    // Check if there is nothing in the textbox
            {
                // HEY NOTHING IS WRONG BUT DON'T NEGATIVE TEST, IT'S FINE TRUST THE PROCESS
            }
            else   // If there is something in the textbox validate the textbox
            {
                // Validate to make sure the length is 10
                if (txtCellPhoneNumber.Text.Length != PHONE_LENGTH)
                {
                    errorMessages += "\nCell Phone number length must be 10 characters";
                    txtCellPhoneNumber.Text = "";
                }
                // Make sure all the characters are numerical
                else if (Regex.IsMatch(txtCellPhoneNumber.Text, "[^0-9]+"))
                {
                    errorMessages += "\nCell Phone number must be numeric characters only!";
                }
            }

            // Validate the hours worked textbox
            // Check to see if there is anything in hours worked
            if (txtHoursWorked.Text.Length == 0)
            {
                errorMessages += "\nMust have a number in hours worked!";
            }
            // Check to see if hours worked is numerical and whole
            else if (Regex.IsMatch(txtHoursWorked.Text, "[^0-9]+"))
            {
                errorMessages += "\nHours worked must be a numerical whole value!";
                txtHoursWorked.Text = "";
            }

            // Validate address
            // Check to see if there is an address
            if (txtAddress.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a address!";
            }
            // Check to see the length of the max length of an address
            else if (txtAddress.Text.Length > ADDRESS_MAX_LENGTH)
            {
                errorMessages += "\nAddress must be equal to or less than " + ADDRESS_MAX_LENGTH + " characters long!";
                txtAddress.Text = "";
            }

            // Validate City
            // Check to see if there is a city entered
            if (txtCity.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a city!";
            }
            // Check to see if the city name exceeds max length
            else if (txtCity.Text.Length > CITY_MAX_LENGTH)
            {
                errorMessages += "\nCity length must be equal to or less than " + CITY_MAX_LENGTH + " characters long!";
                txtCity.Text = "";
            }

            // Validate Province
            if (txtProvince.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a province!";
            }
            else if (txtProvince.Text.Length > PROVINCE_MAX_LENGTH)
            {
                errorMessages += "\nProvince length must be equal to or less than " + PROVINCE_MAX_LENGTH + " characters long!";
                txtProvince.Text = "";
            }

            // Validate postal code
            if (txtPostalCode.Text.Length == 0)
            {
                errorMessages += "\nYou must enter in a postal code!";
            }
            // Validate the postal code
            else if (txtPostalCode.Text.Length != POSTAL_CODE_LENGTH || !Regex.IsMatch(txtPostalCode.Text, @"[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]"))
            {
                errorMessages += "\nYou must enter a valid postal code!";
                txtPostalCode.Text = "";
            }

            // Validate Salary
            // Check to see if salary is there
            if (txtSalary.Text.Length == 0)
            {
                errorMessages += "\nYou must enter a salary!";
            }
            // Check if the number is a valid currency
            else if (!Regex.IsMatch(txtSalary.Text, @"\d+(\.\d{1,2})?"))
            {
                errorMessages += "\nYou must enter in a valid number in salary!";
            }

            #endregion

            // If there is no errors confirm changes to database
            if (errorMessages == "")
            {
                // TODO: CONFIRM SAVED CHANGES
                if (MessageBox.Show("Save changes?", "Confirm Changes", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    // TODO: INSERT CHANGES INTO THE DATABASE
                    int currentSelectedEmp = lstEmployees.SelectedIndex;        // Get the selected view

                    // SQL statement to update the employee info
                    string sqlUpdateEmployee = "UPDATE staff SET " +
                        " staffFirstName=@staffFirstName, staffLastName=@staffLastName, staffType=@staffType, " +
                        " staffPhoneNumber=@staffPhoneNumber, staffMobileNumber=@staffMobileNumber, staffStreetAddress=@staffAddress, " +
                        " staffCity=@staffCity, staffProvince=@staffProvince, staffPostalCode=@staffPostalCode " +
                        " WHERE staffId='" + empId + "'";
                    SqlCommand cmd = new SqlCommand(sqlUpdateEmployee, connection);    // Command to execute

                    // Add the parameters
                    //cmd.Parameters.AddWithValue("@staffId", empId);
                    cmd.Parameters.AddWithValue("@staffFirstName", txtEmployeeFirstName.Text);
                    cmd.Parameters.AddWithValue("@staffLastName", txtEmployeeLastName.Text);
                    cmd.Parameters.AddWithValue("@staffType", cmbEmployeeType.SelectionBoxItem);
                    cmd.Parameters.AddWithValue("@staffPhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@staffMobileNumber", txtCellPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@staffAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@staffCity", txtCity.Text);
                    cmd.Parameters.AddWithValue("@staffProvince", txtProvince.Text);
                    cmd.Parameters.AddWithValue("@staffPostalCode", txtPostalCode.Text);
                    //cmd.Parameters.AddWithValue("@staffHoursNumberOfHours", Convert.ToDouble(txtSalary.Text));

                    // Execute the query
                    connection.Open();      // Open the connection
                    auntRosieDataset = new aunt_rosieDataSet();
                    SqlDataAdapter staffEmployees = new SqlDataAdapter(cmd);     // Create the data adapter
                    cmd.ExecuteNonQuery();  // Execute the query
                    staffEmployees.Update(auntRosieDataset.staff);      // Update the information into the dataset

                    connection.Close(); // Close the connection

                    // Refresh the employee listview
                    RefreshEmployeeListView(currentSelectedEmp);
                    // RefreshEmployeeInfo(true);
                }
            }
            else
            {
                // Display errors to the user
                MessageBox.Show(errorMessages, "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Loads the listview on startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeForm_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshEmployeeListView(0);
        }

        /// <summary>
        /// Load the employee info when a new employee is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstEmployees.SelectedItem != null)
                RefreshEmployeeInfo(true);  // Loads the employee information on the table
        }

        /// <summary>
        /// Create a new pay period for the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPayPeriod_Click(object sender, RoutedEventArgs e)
        {
            // Get most recent startdate
            DataRow lastRangeRow = ((DataRowView)cmbPayPeriod.Items.GetItemAt(cmbPayPeriod.Items.Count - 1)).Row;   // Get the most recent range
            DateTime lastStartDate = Convert.ToDateTime(lastRangeRow["staffHoursStartDate"]);   // Get the previous range's start date

            // Get the new start date and end date
            DateTime newStartDate = lastStartDate.AddDays(15);
            DateTime newEndDate = newStartDate.AddDays(14);

            // SQL Command to add the new pay range for the employee
            string sqlInsertPayPeriod = "INSERT INTO staffHours(staffId, staffHoursStartDate,staffHoursEndDate,staffHoursNumberOfHours) VALUES(@empId, @staffHoursStartDate, @staffHoursEndDate,0)";
            SqlCommand cmd = new SqlCommand(sqlInsertPayPeriod, connection);    // Command to execute

            // Add values to the sql command
            cmd.Parameters.AddWithValue("@empId", empId);
            cmd.Parameters.AddWithValue("@staffHoursStartDate", newStartDate);
            cmd.Parameters.AddWithValue("@staffHoursEndDate", newEndDate);

            // Execute the query
            connection.Open();      // Open the connection
            auntRosieDataset = new aunt_rosieDataSet();
            SqlDataAdapter staffHoursAdapter = new SqlDataAdapter(cmd);     // Create the data adapter
            cmd.ExecuteNonQuery();  // Execute the query
            staffHoursAdapter.Update(auntRosieDataset.staffHours);      // Update the information into the dataset
            
            connection.Close(); // Close the connection
            RefreshEmployeeInfo(true);      // Refresh the info fields
            
        }

        /// <summary>
        /// Refreshes the employee information fields on the range change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPayPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshEmployeeInfo(false);     // Refresh the employee info
        }

        #endregion

        #region CUSTOM FUNCTIONS

        /// <summary>
        /// Repopulates the employee information
        /// </summary>
        private void RefreshEmployeeInfo(bool getRange)
        {
            // Get the selected row
            DataRowView empRow = lstEmployees.Items.GetItemAt(lstEmployees.SelectedIndex) as DataRowView;

            // If the row isn't null populate the boxes
            if (empRow != null)
            {
                // Load all the information for the selected staff into a variable
                empId = (int)empRow["staffId"];
                string empFirstName = (String)empRow["staffFirstName"];
                string empLastName = (String)empRow["staffLastName"];
                string empType = (String)empRow["staffType"];
                string empPhoneNumber = (String)empRow["staffPhoneNumber"];
                string empMobileNumber = (String)empRow["staffMobileNumber"];
                string empAddress = (String)empRow["staffStreetAddress"];
                string empCity = (String)empRow["staffCity"];
                string empProvince = (String)empRow["staffProvince"];
                string empPostalCode = (String)empRow["staffPostalCode"];
                double empSalary = Convert.ToDouble(empRow["staffSalary"]);
                double empHoursWorked;

                // Get the pay range
                #region GET PAY RANGE
                if (getRange == true)
                {
                    // Connection string
                    var conn = ConfigurationManager.ConnectionStrings["aunt_rosieConnectionString"].ConnectionString;
                    // Data adapter to get the pay period, formats start and end into a range
                    SqlDataAdapter payPeriodAdapter = new SqlDataAdapter("SELECT staffHoursStartDate, CONCAT(staffHoursStartDate, ' to ', staffHoursEndDate) as range FROM staffHours WHERE(staffId = '" + empId + "')", conn);
                    DataTable payPeriod = new DataTable();  // Data table that holds all the pay ranges for the selected employee

                    payPeriodAdapter.Fill(payPeriod);       // Fill the datatable with the pay ranges

                    // Populate the dropdown menu with the pay ranges
                    cmbPayPeriod.ItemsSource = payPeriod.DefaultView;
                    cmbPayPeriod.DisplayMemberPath = "range";       // Set the display to be the formatted range
                    cmbPayPeriod.SelectedValuePath = "staffHoursStartDate";     // Value is the start date
                    cmbPayPeriod.SelectedIndex = cmbPayPeriod.Items.Count - 1; // Set the first index to be selected by default
                }
                #endregion

                // Get hours worked
                // Declare the connection
                connection.Open();      // Open the connection
                SqlCommand hoursWorkedCommand = new SqlCommand("SELECT staffHoursNumberOfHours FROM staffHours WHERE staffId='" + empId + "' AND staffHoursStartDate='" + cmbPayPeriod.SelectedValue + "'", connection);
                empHoursWorked = Convert.ToDouble(hoursWorkedCommand.ExecuteScalar());    // Populate the number of hours worked in the range
                txtHoursWorked.Text = empHoursWorked.ToString();        // Populate the hours worked textbox
                connection.Close();     // Close the connection

                // Load all the staff information into the textboxes
                #region LOAD FIELDS
                txtEmployeeFirstName.Text = empFirstName;
                txtEmployeeLastName.Text = empLastName;
                txtPhoneNumber.Text = empPhoneNumber;
                txtCellPhoneNumber.Text = empMobileNumber;
                txtAddress.Text = empAddress;
                txtCity.Text = empCity;
                txtProvince.Text = empProvince;
                txtPostalCode.Text = empPostalCode;
                txtSalary.Text = Convert.ToString(empSalary);

                // Load the employee type
                if (empType == "PT")
                {
                    cmbEmployeeType.SelectedIndex = 0;      // Set the selected index to PT
                }
                else if (empType == "FT")
                {
                    cmbEmployeeType.SelectedIndex = 1;      // Set the selected index to FT
                }
                #endregion

            }
        }

        /// <summary>
        /// Refreshes the employee list view
        /// </summary>
        /// <param name="selectedRecord">The record that is selected after list view is reloaded</param>
        private void RefreshEmployeeListView(int selectedRecord)
        {
            // Load the listview
            auntRosieDataset = new aunt_rosieDataSet();     // Declare the dataset that is being loaded
            employeeTableAdapter = new aunt_rosieDataSetTableAdapters.staffTableAdapter();      // Instantiate the employee table adapter
            employeeTableAdapter.Fill(auntRosieDataset.staff);      // Fill the datatable

            // Populate the listview
            lstEmployees.SelectedIndex = selectedRecord;     // Select the first employee by default
            lstEmployees.ItemsSource = auntRosieDataset.staff;


        }

        #endregion
    }
}
