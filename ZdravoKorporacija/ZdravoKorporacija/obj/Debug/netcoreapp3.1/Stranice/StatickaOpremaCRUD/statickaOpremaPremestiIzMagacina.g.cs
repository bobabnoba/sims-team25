﻿#pragma checksum "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80DCFAE454826F3774D058BBAB9B72054D90515D"
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
using ZdravoKorporacija.Stranice.StatickaOpremaCRUD;


namespace ZdravoKorporacija.Stranice.StatickaOpremaCRUD {
    
    
    /// <summary>
    /// statickaOpremaPremestiIzMagacina
    /// </summary>
    public partial class statickaOpremaPremestiIzMagacina : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProstorija;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbMagacin;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker timePicker;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sati;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/stranice/statickaopremacrud/statickaopremapremestiiz" +
                    "magacina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
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
            
            #line 10 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbProstorija = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            this.cbProstorija.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbProstorija_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbMagacin = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            this.cbMagacin.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbMagacin_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.timePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 44 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            this.timePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.date_changed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.sati = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\..\..\Stranice\StatickaOpremaCRUD\statickaOpremaPremestiIzMagacina.xaml"
            this.sati.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.sati_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

