<<<<<<< HEAD
﻿#pragma checksum "..\..\..\Views\RecipeView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B488AEF07A4A4F49B1D570D02968473"
=======
﻿#pragma checksum "..\..\..\Views\RecipeView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DAA82164D75EB7CDB74C5F862BB44DE5DA7CEC5C"
>>>>>>> 8663c685fac279743bf091fbb6148df1baef7448
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
    /// RecipeView
    /// </summary>
    public partial class RecipeView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIngredients;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblIngredientTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstRecipe;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstIngredients;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQty;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddIngredient;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveIngredient;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveAllIngredients;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\RecipeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuant;
        
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
            System.Uri resourceLocater = new System.Uri("/AuntRosiesBookkeeping;component/views/recipeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\RecipeView.xaml"
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
            this.lblIngredients = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lblIngredientTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lstRecipe = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.lstIngredients = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.lblQty = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnAddIngredient = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnRemoveIngredient = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnRemoveAllIngredients = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.txtQuant = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\Views\RecipeView.xaml"
            this.txtQuant.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtQuant_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

