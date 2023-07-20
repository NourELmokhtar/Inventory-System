﻿#pragma checksum "..\..\..\Bill.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E87130CFA8B3581F668DE58AC0F5992D885103BD"
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
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
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
    /// Bill
    /// </summary>
    public partial class Bill : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CashierName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerPhone;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox WayOfPay;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Total_Price;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PartPay;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PayedMony;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Reminder;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReminderMony;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateBill;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Bill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CartPayment;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ElC;component/bill.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Bill.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CashierName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.CustomerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.CustomerPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.WayOfPay = ((System.Windows.Controls.CheckBox)(target));
            
            #line 79 "..\..\..\Bill.xaml"
            this.WayOfPay.Checked += new System.Windows.RoutedEventHandler(this.WayOfPay_Checked);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Bill.xaml"
            this.WayOfPay.Unchecked += new System.Windows.RoutedEventHandler(this.WayOfPay_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Total_Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PartPay = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.PayedMony = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Reminder = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.ReminderMony = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.CreateBill = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\Bill.xaml"
            this.CreateBill.Click += new System.Windows.RoutedEventHandler(this.CreateBill_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.CartPayment = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
