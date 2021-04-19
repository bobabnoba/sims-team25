﻿using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for lekarStart.xaml
    /// </summary>
    public partial class lekarStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService pacijentServis = new PacijentService();
        public lekarStart()
        {
            InitializeComponent();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                izmeniPregledLekar ip = new izmeniPregledLekar((Termin)dgUsers.SelectedItem, termini);
                ip.Show();
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregledLekar zp = new zakaziPregledLekar(termini);
            zp.Show();
        }

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
            zdravstveniKartonPrikaz zk = new zdravstveniKartonPrikaz((Termin)dgUsers.SelectedItem);
            zk.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        { 
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                oktaziPregledLekar op = new oktaziPregledLekar(termini, (Termin)dgUsers.SelectedItem);
                op.Show();
            }
            
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
            this.Close();
            pp.Show();
        }
    }
}
