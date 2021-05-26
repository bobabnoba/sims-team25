using Controller;
using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zdravstveniKartonPrikaz.xaml
    /// </summary>
    public partial class zdravstveniKartonPrikaz : Window
    {
        private TerminController terminController = TerminController.Instance;
        private ReceptController receptController = ReceptController.Instance;
        private PacijentController pacijentController = PacijentController.Instance;
        private IzvestajController izvestajController = IzvestajController.Instance;
        private ObservableCollection<TerminDTO> termini = new ObservableCollection<TerminDTO>();
        private List<PacijentDTO> pacijenti = new List<PacijentDTO>();
        private ZdravstveniKartonDTO zk = new ZdravstveniKartonDTO();
        private ZdravstveniKartonDTO zkt = new ZdravstveniKartonDTO();

        public static ObservableCollection<ReceptDTO> recepti = new ObservableCollection<ReceptDTO>();
        public static ObservableCollection<IzvestajDTO> izvestaji = new ObservableCollection<IzvestajDTO>();
        PacijentDTO pac;
        TerminDTO sel = new TerminDTO();

        public static int tab = 0;

        public zdravstveniKartonPrikaz(PacijentDTO selektovani)
        {
            InitializeComponent();
            ObservableCollection<ReceptDTO> recepti = new ObservableCollection<ReceptDTO>();
        ObservableCollection<IzvestajDTO> izvestaji = new ObservableCollection<IzvestajDTO>();
            this.DataContext = this;
            pacijenti = pacijentController.PregledSvihPacijenata2();
            pac = selektovani;
            zk = selektovani.ZdravstveniKarton;
            tab = 1;
           
                foreach (IzvestajDTO iz in izvestajController.PregledSvihIzvestaja())
                {
                    foreach (TerminDTO ter in pac.termin)
                    {
                        if (ter.izvestaj.Id.Equals(iz.Id) && !izvestaji.Contains(iz))
                        {
                            izvestaji.Add(iz);
                            break;
                        }
                    }
                }
            
            izvestajGrid.ItemsSource = izvestaji;
            dodajAnamnezu.Visibility = Visibility.Hidden;

            try
            {
                if (zk.Alergije != null)
                    AlergijeListBox.ItemsSource = zk.Alergije.Split(",");
            }
            catch (NullReferenceException) { }

            terapijaGrid.ItemsSource = pac.ZdravstveniKarton.recept;

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
            ObservableCollection<ReceptDTO> recepti = new ObservableCollection<ReceptDTO>();
             ObservableCollection<IzvestajDTO> izvestaji = new ObservableCollection<IzvestajDTO>();    
             pacijenti = pacijentController.PregledSvihPacijenata2();      
         
            zkt = t.zdravstveniKarton;
            tab = 2;
            sel = t;
            
            foreach(PacijentDTO pacijent in pacijentController.PregledSvihPacijenata2())
            {
                if(pacijent.ZdravstveniKarton.Id.Equals(zkt.Id))
                {
                    pac = pacijent;
                }
            }
            foreach (IzvestajDTO iz in izvestajController.PregledSvihIzvestaja())
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

            pacijentController.ObrisiRecept(pac, r);
            recepti.Remove(r);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dodajAnamnezu anamneza = new dodajAnamnezu(sel);
            anamneza.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IzvestajDTO iz = (IzvestajDTO)izvestajGrid.SelectedItem;

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
            
            terminController.ObrisiAnamnezu(iz,sel);
            izvestaji.Remove(iz);
        }
    }
}
