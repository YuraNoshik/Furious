﻿#pragma checksum "..\..\..\Views\Tools.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "281381BC429AC384E0478592FCCF4FC60393B45B4849314F8897DA9E7F413FE2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Forsaj.Views;
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


namespace Forsaj.Views {
    
    
    /// <summary>
    /// Tools
    /// </summary>
    public partial class Tools : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToolsCheck;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToolsChangePassword;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Views\Tools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnToolsAddUser;
        
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
            System.Uri resourceLocater = new System.Uri("/Forsaj;component/views/tools.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Tools.xaml"
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
            this.btnToolsCheck = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Views\Tools.xaml"
            this.btnToolsCheck.Click += new System.Windows.RoutedEventHandler(this.btnToolsCheck_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnToolsChangePassword = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Views\Tools.xaml"
            this.btnToolsChangePassword.Click += new System.Windows.RoutedEventHandler(this.btnToolsChangePassword_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnToolsAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\Views\Tools.xaml"
            this.btnToolsAddUser.Click += new System.Windows.RoutedEventHandler(this.btnToolsAddUser_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

