﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "37F15D3837A7B09A41181639067F85DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AuntRosiesBookkeeping;
using AuntRosiesBookkeeping.ViewModels;
using AuntRosiesBookkeeping.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AuntRosiesBookkeeping {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 90 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuHome;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuQuit;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuProcessTransactions;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuManageIngredients;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuManageProducts;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuManageEmployees;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRptIngredientsInv;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRptProductsInv;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRptSales;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuRptEmployees;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnuAbout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AuntRosiesBookkeeping;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\MainWindow.xaml"
            ((AuntRosiesBookkeeping.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MainWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mnuHome = ((System.Windows.Controls.MenuItem)(target));
            
            #line 90 "..\..\MainWindow.xaml"
            this.mnuHome.Click += new System.Windows.RoutedEventHandler(this.mnuHome_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.mnuQuit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 92 "..\..\MainWindow.xaml"
            this.mnuQuit.Click += new System.Windows.RoutedEventHandler(this.mnuQuit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mnuProcessTransactions = ((System.Windows.Controls.MenuItem)(target));
            
            #line 95 "..\..\MainWindow.xaml"
            this.mnuProcessTransactions.Click += new System.Windows.RoutedEventHandler(this.mnuProcessTransactions_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mnuManageIngredients = ((System.Windows.Controls.MenuItem)(target));
            
            #line 96 "..\..\MainWindow.xaml"
            this.mnuManageIngredients.Click += new System.Windows.RoutedEventHandler(this.mnuManageIngredients_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.mnuManageProducts = ((System.Windows.Controls.MenuItem)(target));
            
            #line 97 "..\..\MainWindow.xaml"
            this.mnuManageProducts.Click += new System.Windows.RoutedEventHandler(this.mnuManageProducts_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.mnuManageEmployees = ((System.Windows.Controls.MenuItem)(target));
            
            #line 98 "..\..\MainWindow.xaml"
            this.mnuManageEmployees.Click += new System.Windows.RoutedEventHandler(this.mnuManageEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.mnuRptIngredientsInv = ((System.Windows.Controls.MenuItem)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.mnuRptIngredientsInv.Click += new System.Windows.RoutedEventHandler(this.mnuRptIngredientsInv_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.mnuRptProductsInv = ((System.Windows.Controls.MenuItem)(target));
            
            #line 102 "..\..\MainWindow.xaml"
            this.mnuRptProductsInv.Click += new System.Windows.RoutedEventHandler(this.mnuRptProductsInv_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.mnuRptSales = ((System.Windows.Controls.MenuItem)(target));
            
            #line 103 "..\..\MainWindow.xaml"
            this.mnuRptSales.Click += new System.Windows.RoutedEventHandler(this.mnuRptSales_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.mnuRptEmployees = ((System.Windows.Controls.MenuItem)(target));
            
            #line 104 "..\..\MainWindow.xaml"
            this.mnuRptEmployees.Click += new System.Windows.RoutedEventHandler(this.mnuRptEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.mnuAbout = ((System.Windows.Controls.MenuItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 45 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnTransactions_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 50 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnReports_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 55 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnProductInventory_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 60 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnIngredientInventory_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

