﻿#pragma checksum "..\..\..\Pages\EditPeoplePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6526B4AFC3AD4877B95834565ED3726A57B642F1ABC837C5D12D513C46BA3CD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HumanResourcesDesktop.Pages;
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


namespace HumanResourcesDesktop.Pages {
    
    
    /// <summary>
    /// EditPeoplePage
    /// </summary>
    public partial class EditPeoplePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Patronymic;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Sex;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Military;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\EditPeoplePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Role;
        
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
            System.Uri resourceLocater = new System.Uri("/HumanResourcesDesktop;component/pages/editpeoplepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EditPeoplePage.xaml"
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
            this.LastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Patronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.Sex = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\..\Pages\EditPeoplePage.xaml"
            this.Sex.Checked += new System.Windows.RoutedEventHandler(this.Sex_Checked);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Pages\EditPeoplePage.xaml"
            this.Sex.Unchecked += new System.Windows.RoutedEventHandler(this.Sex_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Military = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\..\Pages\EditPeoplePage.xaml"
            this.Military.Checked += new System.Windows.RoutedEventHandler(this.Military_Checked);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\Pages\EditPeoplePage.xaml"
            this.Military.Unchecked += new System.Windows.RoutedEventHandler(this.Military_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Role = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 30 "..\..\..\Pages\EditPeoplePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

