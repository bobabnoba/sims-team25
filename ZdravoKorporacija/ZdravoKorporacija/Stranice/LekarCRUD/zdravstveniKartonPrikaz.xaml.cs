using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zdravstveniKartonPrikaz.xaml
    /// </summary>
    public partial class zdravstveniKartonPrikaz : Window
    {
        private TerminService terminServis = new TerminService();
        private ObservableCollection<TerminDTO> termini = new ObservableCollection<TerminDTO>();
        private PacijentService pacijentServis = PacijentService.Instance;
        private ReceptServis receptServis = ReceptServis.Instance;
        private IzvestajService izvestajService = IzvestajService.Instance;
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ZdravstveniKartonDTO zk = new ZdravstveniKartonDTO();
        private ZdravstveniKartonDTO zkt = new ZdravstveniKartonDTO();
        ObservableCollection<ReceptDTO> recepti = new ObservableCollection<ReceptDTO>();
        ObservableCollection<IzvestajDTO> izvestaji = new ObservableCollection<IzvestajDTO>();


        IDRepozitorijum datotekaID;
        IDRepozitorijum iz_datotekaID;

        Dictionary<int, int> ids = new Dictionary<int, int>();
        Dictionary<int, int> iz_ids = new Dictionary<int, int>();
        PacijentDTO pac;
       TerminDTO sel = new TerminDTO();

        public static int tab = 0;

        public zdravstveniKartonPrikaz(PacijentDTO selektovani)
        {
            InitializeComponent();
            
            this.DataContext = this;
            pacijenti = pacijentServis.PregledSvihPacijenata2();
            pac = selektovani;
            zk = selektovani.ZdravstveniKarton;
            tab = 1;
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            iz_datotekaID = new IDRepozitorijum("iDMapIzvestaj");
            iz_ids = iz_datotekaID.dobaviSve();
            
            foreach(IzvestajDTO iz in izvestajService.PregledSvihIzvestaja())
            {
                foreach(TerminDTO ter in pac.termin)
                {
                    if(ter.izvestaj.Id.Equals(iz.Id))
                    {
                        izvestaji.Add(iz);
                        break;
                    }
                }
            }
            izvestajGrid.ItemsSource = izvestaji;
            dodajAnamnezu.Visibility = Visibility.Hidden;
            
            if (zk.Alergije != null)
                AlergijeListBox.ItemsSource = zk.Alergije.Split(",");
            
            foreach(ReceptDTO r in receptServis.PregledSvihRecepata())
            {
                foreach(ReceptDTO rec in pac.ZdravstveniKarton.recept)
                {
                    if(r.Id.Equals(rec.Id))
                    {
                        recepti.Add(r);
                    }
                }
            }
            terapijaGrid.ItemsSource = recepti;

            this.DataContext = this;

            ImeLabel.Content = selektovani.Ime;
            PrezimeLabel.Content = selektovani.Prezime;
            BrojTelefonaLabel.Content = selektovani.BrojTelefona;
            JMBGLabel.Content = selektovani.Jmbg;
            PolLabel.Content = selektovani.Pol;

            try { KrvnaGrupaLabel.Content = zk.KrvnaGrupa; }
            catch (NullReferenceException)
            { }
        }

        public zdravstveniKartonPrikaz(TerminDTO t)
        {
            InitializeComponent();
            
            pacijenti = pacijentServis.PregledSvihPacijenata2();
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            iz_datotekaID = new IDRepozitorijum("iDMapIzvestaj");
            iz_ids = iz_datotekaID.dobaviSve();
            zkt = t.zdravstveniKarton;
            tab = 2;
            sel = t;
            
            foreach(PacijentDTO pacijent in pacijentServis.PregledSvihPacijenata2())
            {
                if(pacijent.ZdravstveniKarton.Id.Equals(zkt.Id))
                {
                    pac = pacijent;
                }
            }
            foreach (IzvestajDTO iz in izvestajService.PregledSvihIzvestaja())
            {
                foreach (TerminDTO ter in pac.termin)
                {
                    if (ter.izvestaj.Id.Equals(iz.Id))
                    {
                        izvestaji.Add(iz);
                        break;
                    }
                }
            }


            izvestajGrid.ItemsSource = izvestaji;
            try
            {
                if (zkt.Alergije != null)
                    AlergijeListBox.ItemsSource = zkt.Alergije.Split(",");
            }
            catch (NullReferenceException) { }

           

            this.DataContext = this;
            foreach (PacijentDTO p in pacijenti)
            {
                if (p.ZdravstveniKarton.Id == zkt.Id)
                {
                    ImeLabel.Content = p.Ime;
                    PrezimeLabel.Content = p.Prezime;
                    BrojTelefonaLabel.Content = p.BrojTelefona;
                    JMBGLabel.Content = p.Jmbg;
                    PolLabel.Content = p.Pol;
                    recepti = p.ZdravstveniKarton.recept;
                    terapijaGrid.ItemsSource = p.ZdravstveniKarton.recept;

                    try { KrvnaGrupaLabel.Content = p.ZdravstveniKarton.KrvnaGrupa; }
                    catch (NullReferenceException)
                    { }
                }
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            izdajRecept izdaj = null;
            if (tab == 1)
            {
                izdaj = new izdajRecept(pac);
                
            }
            else if (tab == 2)
            {
                izdaj = new izdajRecept(sel);
            }
            izdaj.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReceptDTO r = (ReceptDTO)terapijaGrid.SelectedItem;
                
            int id = r.Id;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 1)
                {
                    id = i;
                    ids[i] = 0;
                    break;
                }
            }
           
            pacijentServis.ObrisiRecept(pac, r,ids);
            recepti.Remove(r);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dodajAnamnezu anamneza = new dodajAnamnezu(sel,iz_ids);
            anamneza.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IzvestajDTO iz = (IzvestajDTO)izvestajGrid.SelectedItem;

            int id = iz.Id;
            for (int i = 0; i < 1000; i++)
            {
                if (iz_ids[i] == 1)
                {
                    id = i;
                    iz_ids[i] = 0;
                    break;
                }
            }

            if (tab == 1)
            {
                foreach (TerminDTO t in termini)
                {
                    if (t.izvestaj != null)
                        if (t.izvestaj.Id.Equals(iz.Id))
                        {
                            sel = t;
                        }
                }
            }
            else if (tab == 2)
            {
                foreach (PacijentDTO p in pacijenti)
                {
                    if (sel.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                        pac = p;
                }
            }
            
            terminServis.ObrisiAnamnezu(iz,sel,iz_ids);
            //izvestaji.Remove(iz);
        }
    }
}
