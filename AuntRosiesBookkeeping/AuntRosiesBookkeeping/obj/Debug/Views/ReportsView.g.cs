﻿#pragma checksum "..\..\..\Views\ReportsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A96857B3C8C8EFAEF5BEAB22DDC24B97568E7085"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AuntRosiesBookkeeping.Views;
using RootLibrary.WPF.Localization;
using SAPBusinessObjects.WPF.Viewer;
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


namespace AuntRosiesBookkeeping.Views {
    
    
    /// <summary>
    /// ReportsView
    /// </summary>
    public partial class ReportsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabReports;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabEmployeeReport;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer rptEmployees;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabSales;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer rptSales;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabInventory;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer rptInventory;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabProducts;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer rptProducts;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabRecipe;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\ReportsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer rptRecipes;
        
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
            System.Uri resourceLocater = new System.Uri("/AuntRosiesBookkeeping;component/views/reportsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ReportsView.xaml"
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
            this.tabReports = ((System.Windows.Controls.TabControl)(target));
            
            #line 15 "..\..\..\Views\ReportsView.xaml"
            this.tabReports.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tabReports_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Views\ReportsView.xaml"
            this.tabReports.Loaded += new System.Windows.RoutedEventHandler(this.tabReports_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tabEmployeeReport = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.rptEmployees = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            case 4:
            this.tabSales = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.rptSales = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            case 6:
            this.tabInventory = ((System.Windows.Controls.TabItem)(target));
            return;
            case 7:
            this.rptInventory = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            case 8:
            this.tabProducts = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.rptProducts = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            case 10:
            this.tabRecipe = ((System.Windows.Controls.TabItem)(target));
            return;
            case 11:
            this.rptRecipes = ((SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

