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
using Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for prikaziKarton.xaml
    /// </summary>
    public partial class prikaziKarton : Window
    {
        public prikaziKarton(Pacijent izabrani)
        {
            InitializeComponent();
            if(izabrani.zdravstveniKarton != null)
            alergije.Text = izabrani.zdravstveniKarton.getAlergije();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
