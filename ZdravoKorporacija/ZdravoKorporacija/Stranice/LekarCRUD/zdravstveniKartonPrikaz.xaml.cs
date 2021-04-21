using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZdravoKorporacija.Model;


namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for zdravstveniKartonPrikaz.xaml
    /// </summary>
    public partial class zdravstveniKartonPrikaz : Window
    {
        private ZdravstveniKartonServis zdravstveniKartonServis = new ZdravstveniKartonServis();
        private ObservableCollection<ZdravstveniKarton> zdravstveniKartoni = new ObservableCollection<ZdravstveniKarton>();
        private DijagnozaServis dijagnozaServis = new DijagnozaServis();
        private ObservableCollection<Dijagnoza> dijagnoze = new ObservableCollection<Dijagnoza>();
        private TerminService terminServis = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService pacijentServis = new PacijentService();
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        private ZdravstveniKarton zk = new ZdravstveniKarton();
        private ZdravstveniKarton zkt = new ZdravstveniKarton();
        private ObservableCollection<Recept> recepti =new  ObservableCollection<Recept>();
        private ObservableCollection<Izvestaj> izvestaji = new ObservableCollection<Izvestaj>();
        IDRepozitorijum datotekaID;

        Dictionary<int, int> ids = new Dictionary<int, int>();
        Pacijent pac;
        IstorijaBolesti i = new IstorijaBolesti();
        Termin ter = new Termin();

        int tab = 0;

        public zdravstveniKartonPrikaz(Pacijent selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());
            pac = selektovani;
            zk = selektovani.ZdravstveniKarton;
            tab = 1;
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            foreach(Termin t in zk.termin)
            {
                if(t.izvestaj!=null)
                izvestaji.Add(t.izvestaj);
            }
            izvestajGrid.ItemsSource = izvestaji;
            /*
            foreach (IstorijaBolesti i in zk.GetIstorijaBolesti())
                dgUsers.ItemsSource = i.GetDijagnoza();

            */


            //istorijaBolestiGrid.ItemsSource = zk.GetIstorijaBolesti();
            //istorijaPorodicnihBolesti.ItemsSource = zk.GetIstorijaBolesti();
            alergijeGrid.ItemsSource = zk.Alergije;
            recepti = zk.GetRecept();
            terapijaGrid.ItemsSource = recepti;

            this.DataContext = this;

            ImeLabel.Content = selektovani.Ime;
            PrezimeLabel.Content = selektovani.Prezime;
            BrojTelefonaLabel.Content = selektovani.BrojTelefona;
            JMBGLabel.Content = selektovani.Jmbg;
            PolLabel.Content = selektovani.Pol;

            try { KrvnaGrupaLabel.Content = zk.KrvnaGrupa; }
            catch(NullReferenceException)
            { }
        }

        public zdravstveniKartonPrikaz(Termin t)
        {
            InitializeComponent();
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());
            termini = new ObservableCollection<Termin>(terminServis.PregledSvihTermina());
            zkt = t.zdravstveniKarton;
            tab = 2;
            //foreach (IstorijaBolesti i in zkt.GetIstorijaBolesti())
            //    dgUsers.ItemsSource = i.GetDijagnoza();
            foreach(Termin tt in termini)
            {
                if(t.Id.Equals(tt.Id))
                {
                    pac = t.GetZdravstveniKarton().patient;
                }
            }
            

            
            //istorijaBolestiGrid.ItemsSource = zkt.GetIstorijaBolesti();
            //istorijaPorodicnihBolesti.ItemsSource = zkt.GetIstorijaBolesti();

            alergijeGrid.ItemsSource = zkt.Alergije;

            terapijaGrid.ItemsSource = zkt.GetRecept();

            this.DataContext = this;
            foreach (Pacijent p in pacijenti)
            {
                if(p.ZdravstveniKarton.Id== zkt.Id)
                ImeLabel.Content = p.Ime;
                PrezimeLabel.Content = p.Prezime;
                BrojTelefonaLabel.Content = p.BrojTelefona;
                JMBGLabel.Content = p.Jmbg;
                PolLabel.Content = p.Pol;

                try { KrvnaGrupaLabel.Content = p.ZdravstveniKarton.KrvnaGrupa; }
                catch (NullReferenceException)
                { }
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////String istorijaBolesti = istorijaBolestiText.Text;
            //i.IstorijaBolestiPacijenta = istorijaBolesti;
            //if (tab == 1)
            //{
            //    zk.AddIstorijaBolesti(i);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zk);
            //    pacijentServis.AzurirajPacijenta(pac);
            //}
            //else 
            //{
            //    zkt.AddIstorijaBolesti(i);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zkt);

            //}
            
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //String istorijaPorBolesti = istorijaPorBolestiText.Text;
            //i.PorodicnaIstorijaBolesti = istorijaPorBolesti;
            //if (tab == 1)
            //{
            //    zk.AddIstorijaBolesti(i);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zk);
            //    pacijentServis.AzurirajPacijenta(pac);
            //}
            //else
            //{
            //    zkt.AddIstorijaBolesti(i);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zkt);
            //}
            
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //IstorijaBolesti ib =(IstorijaBolesti) istorijaBolestiGrid.SelectedItem;
            //if (tab == 1)
            //{
            //    zk.RemoveIstorijaBolesti(ib);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zk);
            //    pacijentServis.AzurirajPacijenta(pac);
            //}
            //else
            //{
            //    zkt.RemoveIstorijaBolesti(ib);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zkt);
            //}
           
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            //IstorijaBolesti ib = (IstorijaBolesti)istorijaPorodicnihBolesti.SelectedItem;
            //if (tab == 1)
            //{
            //    zk.RemoveIstorijaBolesti(ib);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zk);
            //    pacijentServis.AzurirajPacijenta(pac);
            //}
            //else
            //{
            //    zkt.RemoveIstorijaBolesti(ib);
            //    zdravstveniKartonServis.AzurirajZdravstveniKarton(zkt);
            //}
            
        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            izdajRecept izdaj = new izdajRecept(pac);
            izdaj.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Recept r = (Recept)terapijaGrid.SelectedItem;
            
            int id = r.Id;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] ==1)
                {
                    id = i;
                    ids[i] = 0;
                    break;
                }
            }
            recepti.Remove(r);
            pacijentServis.AzurirajPacijenta(pac);
            datotekaID.sacuvaj(ids);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dodajAnamnezu anamneza = new dodajAnamnezu(pac);
            anamneza.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Izvestaj iz = (Izvestaj)izvestajGrid.SelectedItem;
            foreach (Termin t in termini)
            {
                if (t.GetZdravstveniKarton().Id.Equals(pac.ZdravstveniKarton.Id))
                {
                    ter = t;
                }
            }
            int id = iz.Id;
            for (int i = 0; i < 1000; i++)
            {
                if (ids[i] == 1)
                {
                    id = i;
                    ids[i] = 0;
                    break;
                }
            }
            izvestaji.Remove(iz);
            terminServis.AzurirajTermin(ter);
            pacijentServis.AzurirajPacijenta(pac);
            datotekaID.sacuvaj(ids);
        }
    }
}
