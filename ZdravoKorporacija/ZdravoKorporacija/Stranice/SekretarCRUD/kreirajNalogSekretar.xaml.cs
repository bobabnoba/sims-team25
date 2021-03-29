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
    /// Interaction logic for kreirajNalogSekretar.xaml
    /// </summary>
    public partial class kreirajNalogSekretar : Window
    {
        public kreirajNalogSekretar()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
