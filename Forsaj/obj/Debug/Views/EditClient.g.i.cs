﻿#pragma checksum "..\..\..\Views\EditClient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A9BA70FDC43D3B1ABED58029FD758BD624EAC2A9687449D3047A2E3D306F0D91"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Forsaj.Classes;
using Forsaj.CustomControls;
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
    /// EditClient
    /// </summary>
    public partial class EditClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditName;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditSurname;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditPatronymic;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheckBack;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditPhoneNumb;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbEditAbonements;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditUID;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Views\EditClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEditCountOfTrainings;
        
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
            System.Uri resourceLocater = new System.Uri("/Forsaj;component/views/editclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\EditClient.xaml"
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
            
            #line 18 "..\..\..\Views\EditClient.xaml"
            ((Forsaj.Views.EditClient)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Views\EditClient.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbEditName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbEditSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbEditPatronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnCheckBack = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\Views\EditClient.xaml"
            this.btnCheckBack.Click += new System.Windows.RoutedEventHandler(this.btnCheckBack_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbEditPhoneNumb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cbEditAbonements = ((System.Windows.Controls.ComboBox)(target));
            
            #line 141 "..\..\..\Views\EditClient.xaml"
            this.cbEditAbonements.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbEditAbonements_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbEditUID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbEditCountOfTrainings = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

