﻿#pragma checksum "..\..\..\Views\ManageInventoryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91EA84321AC853C86BC36890C6618E16FF1B457F"
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
    /// ManageInventoryView
    /// </summary>
    public partial class ManageInventoryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInventoryList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstInventoryList;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInventoryName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtInventoryName;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblType;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbType;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQuantity;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbMeasurementScale;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQty;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveChanges;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProduct;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\ManageInventoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/AuntRosiesBookkeeping;component/views/manageinventoryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ManageInventoryView.xaml"
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
            this.lblInventoryList = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lstInventoryList = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.lblInventoryName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtInventoryName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lblType = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.cmbType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.lblQuantity = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.cmbMeasurementScale = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.txtQty = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\Views\ManageInventoryView.xaml"
            this.txtQty.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtQty_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSaveChanges = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnAddProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.btnRemoveProduct = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

