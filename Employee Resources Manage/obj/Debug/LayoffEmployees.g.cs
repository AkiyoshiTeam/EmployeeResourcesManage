﻿#pragma checksum "..\..\LayoffEmployees.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A009D8A629458A960E8EE73AECF9CD50"
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
    /// LayoffEmployees
    /// </summary>
    public partial class LayoffEmployees : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\LayoffEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogHostWarning;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\LayoffEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSelectedNV;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\LayoffEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnLayoff;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\LayoffEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLayoff;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\LayoffEmployees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefreshData;
        
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
            System.Uri resourceLocater = new System.Uri("/Employee Resources Manage;component/layoffemployees.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LayoffEmployees.xaml"
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
            this.dialogHostWarning = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            
            #line 26 "..\..\LayoffEmployees.xaml"
            this.dialogHostWarning.DialogClosing += new MaterialDesignThemes.Wpf.DialogClosingEventHandler(this.dialogHost_DialogClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridSelectedNV = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnUnLayoff = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\LayoffEmployees.xaml"
            this.btnUnLayoff.Click += new System.Windows.RoutedEventHandler(this.btnUnLayoff_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLayoff = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\LayoffEmployees.xaml"
            this.btnLayoff.Click += new System.Windows.RoutedEventHandler(this.btnLayoff_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRefreshData = ((System.Windows.Controls.Button)(target));
            
            #line 160 "..\..\LayoffEmployees.xaml"
            this.btnRefreshData.Click += new System.Windows.RoutedEventHandler(this.btnRefreshData_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

