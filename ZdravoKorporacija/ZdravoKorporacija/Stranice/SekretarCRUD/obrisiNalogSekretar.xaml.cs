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
    /// Interaction logic for obrisiNalogSekretar.xaml
    /// </summary>
    public partial class obrisiNalogSekretar : Window
    {
        public obrisiNalogSekretar()
        {
            InitializeComponent();
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
