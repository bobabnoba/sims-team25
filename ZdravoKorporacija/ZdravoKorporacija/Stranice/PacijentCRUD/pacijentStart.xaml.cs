using Model;

using Service;
using System;

using Repository;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice.PacijentCRUD;
using System.Windows.Threading;
using ZdravoKorporacija.Service;

namespace ZdravoKorporacija.Stranice
{
    /// <summary>
    /// Interaction logic for pacijentStart.xaml
    /// </summary>
    public partial class pacijentStart : Window
    {
        private TerminService storage = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        private PacijentService storagePacijent = new PacijentService();
        private Pacijent pac = new Pacijent();
        private Pacijent mnm = new Pacijent();
        private Dictionary<int, int> ids = new Dictionary<int, int>();
        private Boolean prikazi;
        private ObavestenjaService os = new ObavestenjaService();

        public pacijentStart()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            this.prikazi = false;
            os.generisiObavestenja();
            IDRepozitorijum datotekaID = new IDRepozitorijum("iDMapTermin");
            ids = datotekaID.dobaviSve();

            termini = new ObservableCollection<Termin>(storage.PregledSvihTermina());
            dgUsers.ItemsSource = termini;
            this.DataContext = this;
            mnm = (storagePacijent.PregledSvihPacijenata())[3]; // za ovog pacijenta prikazujemo obavjestenja
            dgObavjestenja.ItemsSource = mnm.notifikacije;

            //Pacijent p1 = new Pacijent("Dusan", "Lekic");
            //Pacijent p2 = new Pacijent("Aleksa", "Papovic");
            //pacijenti.Add(p1);
            // pacijenti.Add(p2);
        }

        
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (Recept r in mnm.ZdravstveniKarton.recept)
            {
                DateTime ter = r.Pocetak;

                Debug.WriteLine("termin: " + ter.ToString() + ", sad je: " + DateTime.Now.ToString()); //*

                //if (DateTime.Compare(DateTime.Now, ter.AddMinutes(-1)) == 0) // ovo i za jednake vraca 1, nikad 0 ....
                //{
                //    this.prikazi = true;
                //}
                //Debug.WriteLine("prikazi " + this.prikazi); //*

                if (DateTime.Now.ToString().Equals(ter.AddMinutes(1).ToString()))
                {
                    this.prikazi = true;
                }


                int res = DateTime.Compare(DateTime.Now, ter.AddMinutes(1));

                Debug.WriteLine("res je " + res); //*

                if (this.prikazi == true && res >= 0)
                {
                    this.prikazi = false;
                    Notifikacija n = new Notifikacija();

                    n.Id = mnm.notifikacije.Count + 1;
                    n.Datum = ter.AddMinutes(-30);
                    n.Status = "Neprocitano";
                    n.Tip = TipNotifikacije.Podsetnik;
                    n.Sadrzaj = "Popijte lek: " + r.NazivLeka;

                    mnm.notifikacije.Add(n);
                    storagePacijent.AzurirajPacijenta(mnm);

                }
            }
        }

        private void izmeniPregled(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da izmenite.", "Greška");
            else
            {
                Termin t = (Termin)dgUsers.SelectedItem;
                Debug.WriteLine("Danas je " + DateTime.Today.ToString());
                if(t.Pocetak.Date <= DateTime.Today.AddDays(1).Date) {
                    MessageBox.Show("Nije moguće izmeniti pregled koji je zakazan u predstojećih 24h", "Greška");
                }
                else
                {
                    izmeniPregled ip = new izmeniPregled((Termin)dgUsers.SelectedItem, termini);
                    ip.Show();
                }
            }
        }



        private void zakaziPregled(object sender, RoutedEventArgs e)
        {
            zakaziPregled zp = new zakaziPregled(termini, ids);
            zp.Show();
        }

        private void otkaziPregled(object sender, RoutedEventArgs e)
        {
            /*  if (dgUsers.SelectedItem == null)
                  MessageBox.Show("Niste selektovali red", "Greska");
              else
              {
                  if (dgUsers.SelectedItem != null)
                  {
                      MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da otkažete ovaj termin?", "Potvrda brisanja", MessageBoxButton.YesNo);
                      if (result == MessageBoxResult.Yes)
                      {
                          pac.RemoveTermin((Termin)dgUsers.SelectedItem);
                          storagePacijent.AzurirajPacijenta(pac);
                          storage.OtkaziTermin((Termin)dgUsers.SelectedItem);
                          termini.Remove((Termin)dgUsers.SelectedItem);
                      }
                  }
              }*/

            if (dgUsers.SelectedItem == null)
                MessageBox.Show("Pregled nije izabran. Molimo označite pregled koji želite da otkažete.", "Greška");
            else
            {
                otkaziPregled op = new otkaziPregled(termini, (Termin)dgUsers.SelectedItem, ids);
                op.Show();
            }

            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

  
    }
}
