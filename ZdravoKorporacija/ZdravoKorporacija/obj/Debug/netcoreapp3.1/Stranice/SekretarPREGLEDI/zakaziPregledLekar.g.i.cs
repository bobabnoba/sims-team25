﻿#pragma checksum "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E494A353BE4802AE97B160AB498E19F4D7F03788"
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
    /// zakaziPregledLekar
    /// </summary>
    public partial class zakaziPregledLekar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox time;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPacijent;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Lekari;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProstorija;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTip;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/stranice/sekretarpregledi/zakazipregledlekar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
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
            this.date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.time = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
            this.time.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.time_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.potvrdi);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 53 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.odustani);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbPacijent = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\..\..\..\Stranice\SekretarPREGLEDI\zakaziPregledLekar.xaml"
            this.cbPacijent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Lekari = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbProstorija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbTip = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

