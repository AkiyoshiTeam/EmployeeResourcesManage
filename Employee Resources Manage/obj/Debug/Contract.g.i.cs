﻿#pragma checksum "..\..\Contract.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A65022310BF933200D29BDBD57FC47B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Employee_Resources_Manage;
using Employee_Resources_Manage.Domain;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Employee_Resources_Manage {
    
    
    /// <summary>
    /// Contract
    /// </summary>
    public partial class Contract : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHostWarning;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridContract;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMaHD;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMaNV;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbHoTen;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbMaLoaiHD;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpNgayKyHD;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpNgayHetHan;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Contract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewContact;
        
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
            System.Uri resourceLocater = new System.Uri("/Employee Resources Manage;component/contract.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Contract.xaml"
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
            
            #line 12 "..\..\Contract.xaml"
            ((Employee_Resources_Manage.Contract)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dialogHostWarning = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            
            #line 13 "..\..\Contract.xaml"
            this.dialogHostWarning.DialogClosing += new MaterialDesignThemes.Wpf.DialogClosingEventHandler(this.dialogHost_DialogClosing);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dataGridContract = ((System.Windows.Controls.DataGrid)(target));
            
            #line 46 "..\..\Contract.xaml"
            this.dataGridContract.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridContract_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbMaHD = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbMaNV = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbHoTen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cbMaLoaiHD = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.dpNgayKyHD = ((System.Windows.Controls.DatePicker)(target));
            
            #line 55 "..\..\Contract.xaml"
            this.dpNgayKyHD.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.DatePicker_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dpNgayHetHan = ((System.Windows.Controls.DatePicker)(target));
            
            #line 56 "..\..\Contract.xaml"
            this.dpNgayHetHan.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.DatePicker_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnNewContact = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\Contract.xaml"
            this.btnNewContact.Click += new System.Windows.RoutedEventHandler(this.btnNewContact_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

