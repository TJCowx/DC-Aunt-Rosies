﻿#pragma checksum "..\..\..\Views\TransactionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FD4A31420381D0AEBACD1102916229FDC6F3771"
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
using eisiWare;


namespace AuntRosiesBookkeeping.Views {
    
    
    /// <summary>
    /// TransactionView
    /// </summary>
    public partial class TransactionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCurrentTransactionTitle;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblProductsTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstCurrentTransaction;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstProducts;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSubTotalTitle;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSubTotal;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTaxTitle;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTax;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRoundingTitle;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRounding;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalTitle;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQty;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProduct;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveProduct;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveAllProduct;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCompleteTransaction;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Views\TransactionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQty;
        
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
            System.Uri resourceLocater = new System.Uri("/AuntRosiesBookkeeping;component/views/transactionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\TransactionView.xaml"
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
            this.lblCurrentTransactionTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblProductsTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lstCurrentTransaction = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.lstProducts = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.lblSubTotalTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblSubTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblTaxTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblTax = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblRoundingTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblRounding = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lblTotalTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lblQty = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.btnAddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\Views\TransactionView.xaml"
            this.btnAddProduct.Click += new System.Windows.RoutedEventHandler(this.btnAddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnRemoveProduct = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Views\TransactionView.xaml"
            this.btnRemoveProduct.Click += new System.Windows.RoutedEventHandler(this.btnRemoveProduct_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnRemoveAllProduct = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Views\TransactionView.xaml"
            this.btnRemoveAllProduct.Click += new System.Windows.RoutedEventHandler(this.btnRemoveAllProduct_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.btnCompleteTransaction = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Views\TransactionView.xaml"
            this.btnCompleteTransaction.Click += new System.Windows.RoutedEventHandler(this.btnCompleteTransaction_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.txtQty = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\Views\TransactionView.xaml"
            this.txtQty.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtQuant_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

