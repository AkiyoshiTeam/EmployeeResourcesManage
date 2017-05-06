﻿#pragma checksum "..\..\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "85D4FEAB0D661E5BB9FA4D1AE8352AB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dragablz;
using Dragablz.Dockablz;
using Employee_Resources_Manage;
using Employee_Resources_Manage.Domain;
using MahApps.Metro.Controls;
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
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridSumary;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl avatarContentControl;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.Transitioner transitionerField;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spnTaiKhoan;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaiKhoan;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spnMatKhau;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtMatKhau;
        
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
            System.Uri resourceLocater = new System.Uri("/Employee Resources Manage;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 20 "..\..\Login.xaml"
            ((Employee_Resources_Manage.Login)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridSumary = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.avatarContentControl = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 4:
            this.transitionerField = ((MaterialDesignThemes.Wpf.Transitions.Transitioner)(target));
            return;
            case 5:
            this.spnTaiKhoan = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.txtTaiKhoan = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\Login.xaml"
            this.txtTaiKhoan.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtDangNhap_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.spnMatKhau = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.txtMatKhau = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 71 "..\..\Login.xaml"
            this.txtMatKhau.PasswordChanged += new System.Windows.RoutedEventHandler(this.txtMatKhau_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 71 "..\..\Login.xaml"
            this.txtMatKhau.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtDangNhap_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 84 "..\..\Login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DangNhap_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 85 "..\..\Login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Thoat_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

