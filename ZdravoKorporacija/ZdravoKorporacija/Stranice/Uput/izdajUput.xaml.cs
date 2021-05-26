﻿using Controller;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.Logovanje;

namespace ZdravoKorporacija.Stranice.Uput
{
    /// <summary>
    /// Interaction logic for zakaziPregledLekar.xaml
    /// </summary>
    public partial class izdajUput : Window
    {
        private TerminController terminController = TerminController.Instance;
        private LekarRepozitorijum lekariDat = new LekarRepozitorijum();
        private ProstorijaController prostorijeController = new ProstorijaController();
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private PacijentController pacijentiController =  PacijentController.Instance;
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private List<Lekar> lekari = new List<Lekar>();
        private List<TerminDTO> termini = new List<TerminDTO>();
        private List<ProstorijaDTO> prostorije = new List<ProstorijaDTO>();
        private List<Lekar> lekariZaPrikaz = new List<Lekar>();

        private TerminDTO p;
        private ObservableCollection<TerminDTO> pregledi;
        String now = DateTime.Now.ToString("hh:mm:ss tt");
        DateTime today = DateTime.Today;

        private Dictionary<int, int> ids = new Dictionary<int, int>();

        public izdajUput(ObservableCollection<TerminDTO> termini, Dictionary<int, int> ids)
        {
            InitializeComponent();

            p = new TerminDTO();
            pacijenti = pacijentiController.PregledSvihPacijenata2();
            cbPacijent.ItemsSource = pacijenti;
            pregledi = termini;

            this.ids = ids;


            CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            date.BlackoutDates.Add(cdr);


            lekari = lekariDat.dobaviSve();
            lekariZaPrikaz = lekari;
            lekariZaPrikaz.Remove(lekarLogin.lekar);
            Lekari.ItemsSource = lekariZaPrikaz;

            prostorije = prostorijeController.PregledSvihProstorija2();
            cbProstorija.ItemsSource = prostorije;
            p.Trajanje = 0.5;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            termini = terminController.PregledSvihTermina2();
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
            p.Id = id;
            PacijentDTO pac = (PacijentDTO)cbPacijent.SelectedItem;
            ComboBoxItem cboItem = time.SelectedItem as ComboBoxItem;
            

            String d = date.Text;
            String t = null;
            int prepodne = Int32.Parse(now.Substring(0, 2));
            int popodne = prepodne + 12;
            if (!date.SelectedDate.HasValue || time.SelectedIndex == -1 || cbTip.SelectedIndex == -1
                || cbProstorija.SelectedIndex == -1 || cbPacijent.SelectedIndex == -1 || Lekari.SelectedIndex == -1)
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

            try
            {
                p.Pocetak = DateTime.Parse(d + " " + t);
            }
            catch (InvalidCastException)
            { }
            foreach (TerminDTO ter in termini)
            {
                if (ter.Pocetak.Equals(p.Pocetak) && ter.prostorija.Equals(p.prostorija))
                {
                    MessageBox.Show("Postoji termin u izabranom vremenu", "Greska");
                    return;
                }
            }
            if (cbTip.SelectedIndex == 0)
            {
                p.Tip = TipTerminaEnum.Pregled;
            }
            else if (cbTip.SelectedIndex == 1)
            {
                p.Tip = TipTerminaEnum.Operacija;
            }



            ZdravstveniKartonDTO zk = new ZdravstveniKartonDTO(null, pac.Jmbg, StanjePacijentaEnum.None, null, KrvnaGrupaEnum.None, null);

            p.prostorija = (ProstorijaDTO)cbProstorija.SelectedItem;
            p.Lekar = (LekarDTO)Lekari.SelectedItem;
            if (pac.ZdravstveniKarton != null)
                p.zdravstveniKarton = pac.ZdravstveniKarton;
            else
            {
                p.zdravstveniKarton = zk;
                pac.ZdravstveniKarton = zk;
                zdravstveniKartonServis.KreirajZdravstveniKarton(new ZdravstveniKarton(pac.ZdravstveniKarton), ids);
            }

            this.pregledi.Add(p);
            //if (terminController.ZakaziTermin(p, ids))
            //{

            //    lekariDat.sacuvaj(lekari);
            //}
            //pac.AddTermin(p);
            //pacijentiController.AzurirajPacijenta(pac);
            terminController.izdajUput(pac, p);
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
