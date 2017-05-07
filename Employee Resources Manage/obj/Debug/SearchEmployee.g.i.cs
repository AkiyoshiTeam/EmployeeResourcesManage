﻿#pragma checksum "..\..\SearchEmployee.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "33DA1837C596E0FD182CD1D1A3585C8A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DTO;
using Employee_Resources_Manage;
using Employee_Resources_Manage.Domain;
using MaterialDesignColors;
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
    /// SearchEmployee
    /// </summary>
    public partial class SearchEmployee : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHost;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeView;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition rowDataGridView;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stFilter;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridCustom;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportExcel;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImportExcel;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectNew;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\SearchEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectImport;
        
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
            System.Uri resourceLocater = new System.Uri("/Employee Resources Manage;component/searchemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SearchEmployee.xaml"
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
            this.dialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            
            #line 21 "..\..\SearchEmployee.xaml"
            this.dialogHost.DialogClosing += new MaterialDesignThemes.Wpf.DialogClosingEventHandler(this.dialogHost_DialogClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.treeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 3:
            this.rowDataGridView = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.stFilter = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.dataGridCustom = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\SearchEmployee.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnExportExcel = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\SearchEmployee.xaml"
            this.btnExportExcel.Click += new System.Windows.RoutedEventHandler(this.btnExportExcel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnImportExcel = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\SearchEmployee.xaml"
            this.btnImportExcel.Click += new System.Windows.RoutedEventHandler(this.btnImportExcel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnSelectNew = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\SearchEmployee.xaml"
            this.btnSelectNew.Click += new System.Windows.RoutedEventHandler(this.btnSelect_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSelectImport = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\SearchEmployee.xaml"
            this.btnSelectImport.Click += new System.Windows.RoutedEventHandler(this.btnSelect_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

