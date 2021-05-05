﻿using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class otkaziUput : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini;
        private PacijentService pacijentServis = new PacijentService();
        Termin termin;
        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public otkaziUput(ObservableCollection<Termin> ts, Termin t, Dictionary<int, int> ids)
        {
            InitializeComponent();
            termini = ts;
            termin = t;
            this.ids = ids;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.ids[this.termin.Id] = 0;
            storage.OtkaziTermin(termin, ids);
            pacijentServis.ObrisiTerminPacijentu(termin);
            termini.Remove(termin);
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}

