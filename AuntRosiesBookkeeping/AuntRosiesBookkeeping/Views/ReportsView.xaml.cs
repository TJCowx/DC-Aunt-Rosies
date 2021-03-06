﻿using System;
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
using AuntRosiesBookkeeping.SpecialClass;
using AuntRosiesBookkeeping.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace AuntRosiesBookkeeping.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        #region DECLARATIONS
        // Dataset
        private aunt_rosieDataSet auntRosieDataset;

        // Table Adapters
        private aunt_rosieDataSetTableAdapters.BiWeeklyEmployeePayReportTableAdapter employeeReportTableAdapter;           // Employee Report
        private aunt_rosieDataSetTableAdapters.dailySalesReportTableAdapter dailySalesReportTableAdapter;       // Daily sales report
        private aunt_rosieDataSetTableAdapters.inventoryQuantityReportTableAdapter inventoryReportTableAdapter; // Inventory report
        private aunt_rosieDataSetTableAdapters.productQuantityReportTableAdapter productReportTableAdapter;     // Product report

        protected InventoryReport anInventoryReport = new InventoryReport();
        protected SalesReport aSalesReport = new SalesReport();
        protected ProductReport aProductReport = new ProductReport();
        protected EmployeeReport anEmployeeReport = new EmployeeReport();
        #endregion

        public ReportsView()
        {
            InitializeComponent();
            tabReports.SelectedIndex = ReportTabInfo._tabIndex;
        }


        private void tabReports_Loaded(object sender, RoutedEventArgs e)
        {
      
            // Load report depending on the selected object when the tab control loads
            if (ReportTabInfo._tabIndex == 0)
            {
                loadEmployeesReport();
            }
            else if (ReportTabInfo._tabIndex == 1)
            {
                loadSalesReport();
            }
            else if (ReportTabInfo._tabIndex == 2)
            {
                loadInventoryReport();
            }
            else if (ReportTabInfo._tabIndex == 3)
            {
                loadProductReport();
            }
            
        }

        private void loadSalesReport()
        {
            
            try
            {
                // Donnect to the database
                auntRosieDataset = new aunt_rosieDataSet();

                // Set table adapters
                dailySalesReportTableAdapter = new aunt_rosieDataSetTableAdapters.dailySalesReportTableAdapter();

                // Set Sales Report & load it
                dailySalesReportTableAdapter.Fill(auntRosieDataset.dailySalesReport);
                aSalesReport.SetDataSource(auntRosieDataset);
                rptSales.ViewerCore.ReportSource = aSalesReport;                // Load the Report


            }
            catch (Exception dataException)
            {
                MessageBox.Show("A data error encountered: " + dataException.Message);
            }
        }

        private void loadEmployeesReport()
        {
            try
            {
                // Donnect to the database
                auntRosieDataset = new aunt_rosieDataSet();
                // Set table adapters
                employeeReportTableAdapter = new aunt_rosieDataSetTableAdapters.BiWeeklyEmployeePayReportTableAdapter();

                // Set employee Report & load it
                employeeReportTableAdapter.Fill(auntRosieDataset.BiWeeklyEmployeePayReport);
                anEmployeeReport.SetDataSource(auntRosieDataset);
                rptEmployees.ViewerCore.ReportSource = anEmployeeReport;        // Load the report


            }
            catch (Exception dataException)
            {
                MessageBox.Show("A data error encountered: " + dataException.Message);
            }
        }

        private void loadProductReport()
        {
            

            try
            {
                // Donnect to the database
                auntRosieDataset = new aunt_rosieDataSet();
                // Set table adapters
                productReportTableAdapter = new aunt_rosieDataSetTableAdapters.productQuantityReportTableAdapter();

                // Set employee Report & load it
                productReportTableAdapter.Fill(auntRosieDataset.productQuantityReport);
                aProductReport.SetDataSource(auntRosieDataset);
                rptProducts.ViewerCore.ReportSource = aProductReport;        // Load the report


            }
            catch (Exception dataException)
            {
                MessageBox.Show("A data error encountered: " + dataException.Message);
            }
        }

        private void loadInventoryReport()
        {
            

            try
            {
                // Donnect to the database
                auntRosieDataset = new aunt_rosieDataSet();
                // Set table adapters
                inventoryReportTableAdapter = new aunt_rosieDataSetTableAdapters.inventoryQuantityReportTableAdapter();

                // Set employee Report & load it
                inventoryReportTableAdapter.Fill(auntRosieDataset.inventoryQuantityReport);
                anInventoryReport.SetDataSource(auntRosieDataset);
                rptInventory.ViewerCore.ReportSource = anInventoryReport;        // Load the report


            }
            catch (Exception dataException)
            {
                MessageBox.Show("A data error encountered: " + dataException.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            if (ReportTabInfo._tabIndex != tabReports.SelectedIndex)
            {
                ReportTabInfo._tabIndex = tabReports.SelectedIndex;

                // Close report depending on previous index
                if (tabEmployeeReport.IsSelected)
                {
                    //if (!rptEmployees.HasContent)
                    loadEmployeesReport();
                }
                else if (tabSales.IsSelected)
                {
                    //if (!rptSales.HasContent)
                    loadSalesReport();
                }
                else if (tabInventory.IsSelected)
                {
                    // if (!rptInventory.HasContent)
                    loadInventoryReport();
                }
                else if (tabProducts.IsSelected)
                {
                    // if (!rptProducts.HasContent)
                    loadProductReport();

                }
            }
        }

    }
}
