﻿#pragma checksum "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AA10710B1F51A401CC30EE90ED465EECF9E64A19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ZdravoKorporacija.Stranice.LekarCRUD;


namespace ZdravoKorporacija.Stranice.LekarCRUD {
    
    
    /// <summary>
    /// pregledPacijenata
    /// </summary>
    public partial class pregledPacijenata : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUsers;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu Menu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/stranice/lekarcrud/pregledpacijenata.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.prikazKartona);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgUsers = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
            this.dgUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 4:
            
            #line 46 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 47 "..\..\..\..\..\Stranice\LekarCRUD\pregledPacijenata.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

