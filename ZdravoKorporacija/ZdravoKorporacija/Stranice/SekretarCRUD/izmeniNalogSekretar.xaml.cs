using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for izmeniNalogSekretar.xaml
    /// </summary>
    public partial class izmeniNalogSekretar : Window
    {
        public izmeniNalogSekretar()
        {
            InitializeComponent();
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
