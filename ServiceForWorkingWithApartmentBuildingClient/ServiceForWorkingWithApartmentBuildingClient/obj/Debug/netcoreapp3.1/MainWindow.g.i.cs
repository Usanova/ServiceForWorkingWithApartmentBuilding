﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "477994628BC46F91E236EAB227CED9D217241163"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ServiceForWorkingWithApartmentBuildingClient;
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


namespace ServiceForWorkingWithApartmentBuildingClient {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbOpenManagementCompanyWindow;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tblogin;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSurname;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox psbPass;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblErrorAuthentification;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAuthentification;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblOpenRegistration;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ServiceForWorkingWithApartmentBuildingClient;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbOpenManagementCompanyWindow = ((System.Windows.Controls.TextBlock)(target));
            
            #line 12 "..\..\..\MainWindow.xaml"
            this.tbOpenManagementCompanyWindow.MouseEnter += new System.Windows.Input.MouseEventHandler(this.tbOpenManagementCompanyWindow_MouseEnter);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\MainWindow.xaml"
            this.tbOpenManagementCompanyWindow.MouseLeave += new System.Windows.Input.MouseEventHandler(this.tbOpenManagementCompanyWindow_MouseLeave);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\MainWindow.xaml"
            this.tbOpenManagementCompanyWindow.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.tbOpenManagementCompanyWindow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tblogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.tblogin.KeyDown += new System.Windows.Input.KeyEventHandler(this.Tblogin_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\MainWindow.xaml"
            this.tbSurname.KeyDown += new System.Windows.Input.KeyEventHandler(this.Tblogin_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.psbPass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 24 "..\..\..\MainWindow.xaml"
            this.psbPass.KeyDown += new System.Windows.Input.KeyEventHandler(this.PsbPass_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblErrorAuthentification = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnAuthentification = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\MainWindow.xaml"
            this.btnAuthentification.Click += new System.Windows.RoutedEventHandler(this.btnAuthentification_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblOpenRegistration = ((System.Windows.Controls.Label)(target));
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.lblOpenRegistration.MouseEnter += new System.Windows.Input.MouseEventHandler(this.lblOpenRegistration_MouseEnter);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.lblOpenRegistration.MouseLeave += new System.Windows.Input.MouseEventHandler(this.lblOpenRegistration_MouseLeave);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.lblOpenRegistration.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.lblOpenRegistration_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

