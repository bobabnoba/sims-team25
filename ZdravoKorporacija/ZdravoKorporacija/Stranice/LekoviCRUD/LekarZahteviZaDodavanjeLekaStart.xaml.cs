using Model;
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
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repository;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.Uput;

namespace ZdravoKorporacija.Stranice.LekoviCRUD
{
    /// <summary>
    /// Interaction logic for LekarZahteviZaDodavanjeLekaStart.xaml
    /// </summary>
    public partial class LekarZahteviZaDodavanjeLekaStart : Window
    {
        LekServis lekServis = new LekServis();
        public ObservableCollection<Lek> lekici;
        public ObservableCollection<Lekar> lekari;
        public ObservableCollection<ZahtevLek> zahteviPrikaz = new ObservableCollection<ZahtevLek>();

        public LekarZahteviZaDodavanjeLekaStart()
        {
            InitializeComponent();
            lekici = new ObservableCollection<Lek>();
            lekari = new ObservableCollection<Lekar>();
            foreach(ZahtevLek z in lekServis.PregledSvihZahtevaLek())
            {
                foreach(Lekar l in z.lekari)
                {
                    if(l.Jmbg.Equals(lekarLogin.lekar.Jmbg))
                    {
                        zahteviPrikaz.Add(z);
                    }
                }
            }
            dgZahtevi.ItemsSource = zahteviPrikaz;
        }

        private void dgZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            if (dgZahtevi.SelectedItem != null) {
                IDRepozitorijum datoteka = new IDRepozitorijum("iDMapLekova");
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


                ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
                Lek l = new Lek(id,zahtev.Lek.Proizvodjac,zahtev.Lek.Sastojci,zahtev.Lek.NusPojave,zahtev.Lek.NazivLeka);
                l.alternativniLekovi = zahtev.Lek.alternativniLekovi;
                lekServis.DodajLek(l,ids);
                IDRepozitorijum datotekaZahtev = new IDRepozitorijum("iDMapZahtevZaLek");
                Dictionary<int, int> idsZahtev = datotekaZahtev.dobaviSve();
                Debug.WriteLine(zahtev.Id);
                idsZahtev[zahtev.Id] = 0;

                zahtev.BrojPotvrda++;
                foreach(Lekar lekar in zahtev.lekari.ToArray())
                {
                    if (lekar.Jmbg.Equals(lekarLogin.lekar.Jmbg))
                        zahtev.lekari.Remove(lekar);
                }
                zahteviPrikaz.Remove(zahtev);
                lekServis.AzurirajZahtevLeka(zahtev);
                if (zahtev.BrojPotvrda.Equals(zahtev.NeophodnihPotvrda))
                    lekServis.ObrisiZahtevZaLek(zahtev,idsZahtev);
             }
        }

        private void izmenaAlternativnihLekova(object sender, RoutedEventArgs e)
        {
            ZahtevLek zahtev = (ZahtevLek)dgZahtevi.SelectedItem;
            IzmenaAlternativnihLekovaZahtev izmenaAlternativnih = new IzmenaAlternativnihLekovaZahtev(new ObservableCollection<Lek>(zahtev.Lek.alternativniLekovi),zahtev);
            izmenaAlternativnih.Show();
        }

        private void lekariZaDodavanjeLeka(object sender, RoutedEventArgs e)
        {
            ZahtevLek zahtev = (ZahtevLek) dgZahtevi.SelectedItem;
            lekari = new ObservableCollection<Lekar>(zahtev.lekari);
            IzborLekaraZaPotvrdu izborLekara = new IzborLekaraZaPotvrdu(lekari,zahtev);
            izborLekara.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            izmeniZahtevZaLek iz = new izmeniZahtevZaLek((ZahtevLek)dgZahtevi.SelectedItem);
            iz.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            IDRepozitorijum datoteka = new IDRepozitorijum("iDMapLekova");
            Dictionary<int, int> ids = datoteka.dobaviSve();
            obrisiZahtevZaLek oz = new obrisiZahtevZaLek(zahteviPrikaz, (ZahtevLek)dgZahtevi.SelectedItem, ids);
            oz.Show();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lekarStart ls = new lekarStart(lekarLogin.lekar);
            ls.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uputi u = new Uputi();
            u.Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            pregledPacijenata pp = new pregledPacijenata();
            this.Close();
            pp.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
