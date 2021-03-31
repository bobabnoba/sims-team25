﻿using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class oktaziPregledLekar : Window
    {
        private TerminFileStorage storage = new TerminFileStorage();
        private ObservableCollection<Termin> termini;
        Termin termin;
        public oktaziPregledLekar(ObservableCollection<Termin> ts, Termin t)
        {
            InitializeComponent();
            termini = ts;
            termin = t;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            storage.OtkaziTermin(termin);
            termini.Remove(termin);
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
