﻿#pragma checksum "..\..\..\FoundingSupplier.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AF55065ADCF0BE507915F5ED124B501B03C91AD2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ElC;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace ElC {
    
    
    /// <summary>
    /// FoundingSupplier
    /// </summary>
    public partial class FoundingSupplier : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SupplierName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SupplierPhone;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalPrice;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PartPay;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PayedMoney;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Reminder;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pay;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\FoundingSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CartPaymentGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ElC;component/foundingsupplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FoundingSupplier.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SupplierName = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\FoundingSupplier.xaml"
            this.SupplierName.KeyDown += new System.Windows.Input.KeyEventHandler(this.SupplierName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SupplierPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\FoundingSupplier.xaml"
            this.SupplierPhone.KeyDown += new System.Windows.Input.KeyEventHandler(this.SupplierPhone_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TotalPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PartPay = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.PayedMoney = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Reminder = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Pay = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\FoundingSupplier.xaml"
            this.Pay.Click += new System.Windows.RoutedEventHandler(this.Pay_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CartPaymentGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

