﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.SekretarCRUD
{
    /// <summary>
    /// Interaction logic for sekretarStart.xaml
    /// </summary>
    public partial class sekretarStart : Page
    {
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        public sekretarStart()
        {
            InitializeComponent();
            DatotekaPacijentJSON dat = new DatotekaPacijentJSON();
            pacijenti = new ObservableCollection<Pacijent>(dat.CitanjeIzFajla());
            dgUsers.ItemsSource = pacijenti;
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            kreirajNalogSekretar kn = new kreirajNalogSekretar(pacijenti);
            kn.Show();
        }
        private void izmeni(object sender, RoutedEventArgs e)
        {
            izmeniNalogSekretar izn = new izmeniNalogSekretar((Pacijent)dgUsers.SelectedItem, pacijenti);
            izn.Show();
        }
        private void izbrisi(object sender, RoutedEventArgs e)
        {
            obrisiNalogSekretar on = new obrisiNalogSekretar((Pacijent)dgUsers.SelectedItem, pacijenti);
            on.Show();
        }
    }
}
