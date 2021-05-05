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
        public static ObservableCollection<Recept> recepti = new ObservableCollection<Recept>();
        public static ObservableCollection<Izvestaj> izvestaji = new ObservableCollection<Izvestaj>();
        IDRepozitorijum datotekaID;
        private bool ne;

        Dictionary<int, int> ids = new Dictionary<int, int>();
        Pacijent pac;
        IstorijaBolesti i = new IstorijaBolesti();
        Termin ter = new Termin();
        Termin sel = new Termin();

        public static int tab = 0;

        public zdravstveniKartonPrikaz(Pacijent selektovani)
        {
            InitializeComponent();
            this.DataContext = this;
            ne = false;
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());
            termini = new ObservableCollection<Termin>(terminServis.PregledSvihTermina());
            pacijenti = new ObservableCollection<Pacijent>(pacijentServis.PregledSvihPacijenata());
            pac = selektovani;
            zk = selektovani.ZdravstveniKarton;
            tab = 1;
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            foreach (Termin ter in pac.termin)
            {
                ne = false;
                if (ter.izvestaj != null)
                {
                    foreach (Izvestaj iz in izvestaji)
                    {
                        if (iz != null)
                        {
                            if (iz.Id.Equals(ter.izvestaj.Id))
                            {
                                ne = true;
                                break;
                            }
                            if (!ne)
                                izvestaji.Add(ter.izvestaj);
                        }
                    }
                }
                    
            }
            izvestajGrid.ItemsSource = izvestaji;
            dodajAnamnezu.Visibility = Visibility.Hidden;
            /*
            foreach (IstorijaBolesti i in zk.GetIstorijaBolesti())
                dgUsers.ItemsSource = i.GetDijagnoza();

            */


            //istorijaBolestiGrid.ItemsSource = zk.GetIstorijaBolesti();
            //istorijaPorodicnihBolesti.ItemsSource = zk.GetIstorijaBolesti();
            if (zk.Alergije != null)
                AlergijeListBox.ItemsSource = zk.Alergije.Split(",");
            recepti = zk.recept;
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

        public zdravstveniKartonPrikaz(Termin t)
        {
            InitializeComponent();
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());
            termini = new ObservableCollection<Termin>(terminServis.PregledSvihTermina());
            pacijenti = new ObservableCollection<Pacijent>(pacijentServis.PregledSvihPacijenata());
            datotekaID = new IDRepozitorijum("iDMapRecept");
            ids = datotekaID.dobaviSve();
            zkt = t.zdravstveniKarton;
            tab = 2;
            sel = t;
            //foreach (IstorijaBolesti i in zkt.GetIstorijaBolesti())
            //    dgUsers.ItemsSource = i.GetDijagnoza();
            /*foreach(Termin tt in termini)
            {
                if(t.Id.Equals(tt.Id))
                {
                    pac = t.GetZdravstveniKarton().patient;
                }
            }*/


            //istorijaBolestiGrid.ItemsSource = zkt.GetIstorijaBolesti();
            //istorijaPorodicnihBolesti.ItemsSource = zkt.GetIstorijaBolesti();
            foreach (Pacijent p in pacijenti)
            {
                if (p.ZdravstveniKarton.Id.Equals(zkt.Id))
                {
                    foreach (Termin ter in p.termin)
                    {
                        foreach (Termin termin in termini)
                        {
                            ne = false;
                            if (ter.Id.Equals(termin.Id))
                            {
                                if (termin.izvestaj != null)
                                {
                                    foreach (Izvestaj iz in izvestaji)
                                    {
                                        if (iz != null)
                                            if (iz.Id.Equals(ter.izvestaj.Id))
                                            {
                                                ne = true;
                                                break;
                                            }
                                        if (!ne)
                                            izvestaji.Add(ter.izvestaj);
                                    }
                                }
                            }
                        }
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
            foreach (Pacijent p in pacijenti)
            {
                //Trace.WriteLine(p.ZdravstveniKarton.Id + zkt.Id);
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
            Recept r = (Recept)terapijaGrid.SelectedItem;
            if (tab == 2)
            {
                foreach (Pacijent p in pacijenti)
                {
                    if (p.ZdravstveniKarton.Id.Equals(sel.zdravstveniKarton.Id))
                    {
                        p.ZdravstveniKarton.recept.Remove(r);
                        pac = p;
                        break;
                    }
                }
            }
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
            recepti.Remove(r);
            pacijentServis.AzurirajPacijenta(pac);
            datotekaID.sacuvaj(ids);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dodajAnamnezu anamneza = null;
            if (tab == 1)
                anamneza = new dodajAnamnezu(pac);
            else if (tab == 2)
                anamneza = new dodajAnamnezu(sel);
            anamneza.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Izvestaj iz = (Izvestaj)izvestajGrid.SelectedItem;

            int id = iz.Id;
            //for (int i = 0; i < 1000; i++)
            //{
            //    if (ids[i] == 1)
            //    {
            //        id = i;
            //        ids[i] = 0;
            //        break;
            //    }
            //}
            if (tab == 1)
            {
                foreach (Termin t in pac.termin)
                {
                    if (t.izvestaj != null)
                        if (t.izvestaj.Id.Equals(iz.Id))
                        {
                            t.izvestaj = null;
                            break;
                        }
                }
                foreach (Termin t in termini)
                {
                    if (t.izvestaj != null)
                        if (t.izvestaj.Id.Equals(iz.Id))
                        {
                            t.izvestaj = null;
                            ter = t;
                        }
                }
            }
            else if (tab == 2)
            {
                sel.izvestaj = null;
                foreach (Pacijent p in pacijenti)
                {
                    if (sel.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                        pac = p;
                }
                foreach (Termin t in pac.termin)
                {
                    if (t.izvestaj != null)
                    {
                        if (t.izvestaj.Id.Equals(iz.Id))
                        {
                            t.izvestaj = null;
                            ter = t;
                        }
                    }
                }
            }
            izvestaji.Remove(iz);
            terminServis.AzurirajTermin(ter);
            pacijentServis.AzurirajPacijenta(pac);
            datotekaID.sacuvaj(ids);
        }
    }
}
