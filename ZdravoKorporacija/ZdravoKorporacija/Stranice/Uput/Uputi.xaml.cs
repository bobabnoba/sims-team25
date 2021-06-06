﻿using Model;
using Repository;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for Uputi.xaml
    /// </summary>
    public partial class Uputi : Page
    {
        private Dictionary<int, int> ids = new Dictionary<int, int>();
      

        public Uputi()
        {
            InitializeComponent();

            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();
            dgUsers.ItemsSource = lekarStart.uputi;
            this.DataContext = this;
        }

        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var filtered = lekarStart.uputi.Where(termin => termin.Pocetak.ToString().StartsWith(searchBar.Text));
            dgUsers.ItemsSource = filtered;
        }
        private void izmeniUput(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                test.prozor.Content = new izmeniUput((TerminDTO)dgUsers.SelectedItem, lekarStart.uputi);
            }
        }

        private void izdajUput(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new izdajUput(lekarStart.uputi, ids);
        }

        private void prikaziKarton(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zdravstveniKartonPrikaz((TerminDTO)dgUsers.SelectedItem);
        }

        private void otkaziUput(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Niste selektovali red", "Greska");
            else
            {
                otkaziUput ou = new otkaziUput(lekarStart.uputi, (TerminDTO)dgUsers.SelectedItem, ids);
                ou.Show();
            }
        }

       

        private void zakaziHitno(object sender, RoutedEventArgs e)
        {
           
            test.prozor.Content = new zakaziHitniLekar(lekarStart.uputi, ids);
        }

    }
}


