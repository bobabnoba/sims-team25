﻿#pragma checksum "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29E86FFDBA653FFCF443979425B1E23E95DD5D52"
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
using ZdravoKorporacija.Stranice.UpravnikCRUD;


namespace ZdravoKorporacija.Stranice.UpravnikCRUD {
    
    
    /// <summary>
    /// izmeniProstorijuUpravnik
    /// </summary>
    public partial class izmeniProstorijuUpravnik : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxIzmenaNaziv;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxIzmenaTip;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxIzmenaSprat;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxIzmenaId;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBoxIzmenaZauzeta;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/stranice/upravnikcrud/izmeniprostorijuupravnik.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
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
            this.textBoxIzmenaNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.comboBoxIzmenaTip = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
            this.comboBoxIzmenaTip.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxIzmenaSprat = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
            this.comboBoxIzmenaSprat.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 25 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.potvrdi);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\..\..\..\Stranice\UpravnikCRUD\izmeniProstorijuUpravnik.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.odustani);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBoxIzmenaId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.checkBoxIzmenaZauzeta = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

