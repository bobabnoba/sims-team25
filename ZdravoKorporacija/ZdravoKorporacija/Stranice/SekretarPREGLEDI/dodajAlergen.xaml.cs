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
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for dodajAlergen.xaml
    /// </summary>
    public partial class dodajAlergen : Window
    {
        private Pacijent p1;
        public dodajAlergen(Pacijent izabrani)
        {
            InitializeComponent();
            p1 = izabrani;
        }

     
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (p1.zdravstveniKarton != null)
            {
                p1.zdravstveniKarton.dodajAlergije(dodaj.Text);
                this.Close();
            }
            
        }
    }
}
