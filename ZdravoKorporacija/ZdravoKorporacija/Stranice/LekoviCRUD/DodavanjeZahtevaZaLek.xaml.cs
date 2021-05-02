﻿using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for DodavanjeZahtevaZaLek.xaml
    /// </summary>
    public partial class DodavanjeZahtevaZaLek : Window
    {
        LekServis lekServis = new LekServis();
        DodavanjeAlternativnihLekova dodavanjeAlternativnih;
        public ObservableCollection<Lek> lekici;

        public DodavanjeZahtevaZaLek()
        {
            InitializeComponent();
            lekici = new ObservableCollection<Lek>();
            List<int> potvrda = new List<int>();
            for(int i =1; i<= 10; i++)
            {
                potvrda.Add(i);
            }
            comboBoxBrojPotvrda.ItemsSource = potvrda;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ObservableCollection<Lek> alterantivni = dodavanjeAlternativnih.alternativniLekovi;

          
            LekDTO lek = new LekDTO(0,textBoxProizvodjac.Text,textBoxSastojci.Text,textBoxPojave.Text,textBoxNazivLeka.Text);

            int neophodno = (int) comboBoxBrojPotvrda.SelectedItem;

            List<LekDTO> alekoviDTO = new List<LekDTO>();

            foreach (Lek lekD in alterantivni)
            {
                LekDTO le = new LekDTO(lekD.Id, lekD.Proizvodjac, lekD.Sastojci, lekD.NusPojave, lekD.NazivLeka);
                alekoviDTO.Add(le);
                Debug.WriteLine(le.NazivLeka);
            }


            //.alternativniLekovi = alekoviDTO;

            ZahtevLekDTO zahtevLekDTO = new ZahtevLekDTO(lek,neophodno,0);
            zahtevLekDTO.Lek.SetalternativniLekovi(alekoviDTO);
            IDRepozitorijum datoteka = new IDRepozitorijum("iDMapZahtevZaLek");
            Dictionary<int, int> ids = datoteka.dobaviSve();

            int id = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 0)
                {
                    id = i;
                    ids[i] = 1;
                    break;
                }
            }

            int zahtevId = id;

            zahtevLekDTO.Id = zahtevId;

            lekServis.DodajZahtevLeka(zahtevLekDTO, ids);
          

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LekarZahteviZaDodavanjeLekaStart lk = new LekarZahteviZaDodavanjeLekaStart();
            lk.Show();
            this.Close();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
           
            dodavanjeAlternativnih = new DodavanjeAlternativnihLekova(lekici);
            dodavanjeAlternativnih.Show();
           
        }

        private void comboBoxBrojPotvrda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IzborLekaraZaPotvrdu izborLekara = new IzborLekaraZaPotvrdu();
            izborLekara.Show();
        }
    }
}
