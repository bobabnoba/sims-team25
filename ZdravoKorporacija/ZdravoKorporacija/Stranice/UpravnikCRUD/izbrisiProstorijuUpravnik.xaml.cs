﻿using Controller;
using Model;
using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.UpravnikCRUD
{
    /// <summary>
    /// Interaction logic for izbrisiProstorijuUpravnik.xaml
    /// </summary>
    public partial class izbrisiProstorijuUpravnik : Window
    {
        private ProstorijaController prostorijaKontroler = new ProstorijaController();
        private ObservableCollection<ProstorijaDTO> prostorije;
        private ProstorijaDTO prostorijaZaBrisanje;
        public izbrisiProstorijuUpravnik(ObservableCollection<ProstorijaDTO> pr, ProstorijaDTO p)
        {
            InitializeComponent();
            this.prostorije = pr;
            this.prostorijaZaBrisanje = p;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            prostorijaKontroler.ObrisiProstoriju(this.prostorijaZaBrisanje);
            prostorije.Remove(this.prostorijaZaBrisanje);
            this.Close();
        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
