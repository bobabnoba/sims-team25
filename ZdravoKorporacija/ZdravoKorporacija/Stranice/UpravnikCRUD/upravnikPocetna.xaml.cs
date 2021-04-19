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
using ZdravoKorporacija.Stranice.DinamickaOprema;
using ZdravoKorporacija.Stranice.Magacin;
using ZdravoKorporacija.Stranice.StatickaOprema;

namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for upravnikPocetna.xaml
    /// </summary>
    public partial class upravnikPocetna : Window
    {
        public upravnikPocetna()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            upravnikStart s = new upravnikStart();
            s.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            statickaOpremaStart s = new statickaOpremaStart();
            s.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MagacinStart s = new MagacinStart();
            s.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dinamickaOpremaStart s = new dinamickaOpremaStart();
            s.Show();
        }
    }
}
