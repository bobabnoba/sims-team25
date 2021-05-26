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
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for AnamnezaProzor.xaml
    /// </summary>
    public partial class AnamnezaProzor : Window
    {
        private PacijentDTO pacijentDTO;
        public AnamnezaProzor(TerminDTO selektovaniTermin, PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            this.pacijentDTO = pacijentDTO;
            tbSimptomi.DataContext = selektovaniTermin.Izvestaj;
            tbOpis.DataContext = selektovaniTermin.Izvestaj;
            labelaTip.DataContext = selektovaniTermin;
            labelaDatum.DataContext = selektovaniTermin;
            labelaLekar.DataContext = selektovaniTermin;
        }

        private void dodajBeleskuBtn_Click(object sender, RoutedEventArgs e)
        {
            dodajBeleskuBtn.Visibility = Visibility.Hidden;
            Beleske.Content = new BeleskeStranica(pacijentDTO);
        }

        private void nazadBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
