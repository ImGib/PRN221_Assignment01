﻿#pragma checksum "..\..\..\ModifyOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0201BB434A7157B71622BEE2F15586BD8163F47E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalesWPFApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SalesWPFApp {
    
    
    /// <summary>
    /// ModifyOrder
    /// </summary>
    public partial class ModifyOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderId;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMemberId;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderDate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRequiredDate;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtShippedDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFreight;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccept;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\ModifyOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SalesWPFApp;component/modifyorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ModifyOrder.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtOrderId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtMemberId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtOrderDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtRequiredDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtShippedDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtFreight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnAccept = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\ModifyOrder.xaml"
            this.btnAccept.Click += new System.Windows.RoutedEventHandler(this.btnAccept_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnNo = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\ModifyOrder.xaml"
            this.btnNo.Click += new System.Windows.RoutedEventHandler(this.btnNo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

