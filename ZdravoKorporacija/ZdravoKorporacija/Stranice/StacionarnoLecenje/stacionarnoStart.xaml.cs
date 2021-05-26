﻿using Controller;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;


namespace ZdravoKorporacija.Stranice.StacionarnoLecenje
{
    /// <summary>
    /// Interaction logic for stacionarnoStart.xaml
    /// </summary>
    public partial class stacionarnoStart : Window
    {
        private TerminController terminController = TerminController.Instance;
        private ProstorijaController prostorijeController = new ProstorijaController();
        private StacionarnoLecenjeController sl = StacionarnoLecenjeController.Instance;
        private List<TerminDTO> termini = new List<TerminDTO>();
        private List<ProstorijaDTO> prostorije = new List<ProstorijaDTO>();
        private StacionarnoLecenjeDTO stacionarnoLecenje = new StacionarnoLecenjeDTO();


        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;
  


        public stacionarnoStart(PacijentDTO pacijent)
        {
            InitializeComponent();

            stacionarnoLecenje.Pacijent = pacijent;


            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


            prostorije = prostorijeController.PregledSvihProstorija2();
            cbProstorija.ItemsSource = prostorije;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            termini = terminController.PregledSvihTermina2();
           
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            stacionarnoLecenje.Trajanje = trajanjeText.Text;
            String d = date.Text;
            String t = null;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1
                || cbProstorija.SelectedIndex == -1)
            {
                MessageBox.Show("Niste popunili sva polja", "Greska");
                return;
            }
            if (cboItem != null)
            {
                t = cboItem.Content.ToString();
                if (d.Equals(today.ToString("dd.M.yyyy.")))
                {
                    if (Int32.Parse(t.Substring(0, 2)) < (now.Substring(9, 8).Equals("po podne") ? popodne : prepodne))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");

                        return;
                    }
                    else if ((Int32.Parse(t.Substring(0, 2)) == prepodne || Int32.Parse(t.Substring(0, 2)) == popodne) && Int32.Parse(t.Substring(3, 2)) < Int32.Parse(now.Substring(3, 2)))
                    {
                        MessageBox.Show("Nevalidno Vreme", "Greska");
                        return;
                    }
                }
            }
            stacionarnoLecenje.Prostorija =(ProstorijaDTO) cbProstorija.SelectedItem;
            try
            {
                stacionarnoLecenje.Pocetak = DateTime.Parse(d + " " + t);
            }
            catch (InvalidCastException)
            { }
            foreach (TerminDTO ter in termini)
            {
                if (ter.Pocetak.Equals(stacionarnoLecenje.Pocetak) && ter.prostorija.Id.Equals(stacionarnoLecenje.Prostorija.Id))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }

            sl.DodajStacionarnoLecenje(stacionarnoLecenje);
            uputiZaStacionarno.uputi.Add(stacionarnoLecenje);

            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}