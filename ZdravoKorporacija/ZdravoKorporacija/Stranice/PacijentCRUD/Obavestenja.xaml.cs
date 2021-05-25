using Model;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for Obavestenja.xaml
    /// </summary>
    public partial class Obavestenja : Page
    {
        private PacijentDTO pacijent;
        private Boolean prikazi;
        private PacijentController pacijentController = new PacijentController();



        public Obavestenja(PacijentDTO pacijent)
        {
            InitializeComponent();
            this.pacijent = pacijent;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            this.prikazi = false;


            dgObavjestenja.ItemsSource = this.pacijent.notifikacije;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (ReceptDTO r in pacijent.ZdravstveniKarton.recept)
            {
                //System.Diagnostics.Debug.WriteLine("pocetak: " + r.Pocetak + "; sad-3: " + DateTime.Now.AddDays(-3));

                if (r.Pocetak < DateTime.Now.AddDays(-3)) continue;

                DateTime ter = r.Pocetak;

                //System.Diagnostics.Debug.WriteLine("now: " + DateTime.Now + "; ter: " + r.Pocetak);
                //System.Diagnostics.Debug.WriteLine("prikazi should be true at " + ter.AddMinutes(-1));

                // if (DateTime.Now.ToString().Equals(ter.AddMinutes(1).ToString()))
                if (DateTime.Now.ToString().Equals(ter.AddMinutes(-1).ToString())) // upravo otkucalo da je prikažem, >= ispunjeno za sve pa ih sve ispisuje
                {
                   // System.Diagnostics.Debug.WriteLine("'prikazi = true! '");
                    this.prikazi = true;
                }
                int res = DateTime.Compare(DateTime.Now, ter.AddMinutes(-1));
               // System.Diagnostics.Debug.WriteLine("res je " + res);


                if (this.prikazi == true && res >= 0)
                {
                    this.prikazi = false;
                    NotifikacijaDTO n = new NotifikacijaDTO();

                    n.Id = pacijent.notifikacije.Count + 1;
                    n.Datum = ter.AddMinutes(-30);
                    n.Status = "Neprocitano";
                    n.Tip = TipNotifikacije.Podsetnik;
                    n.Sadrzaj = "Popijte lek: " + r.NazivLeka;

                    pacijent.notifikacije.Add(n);
                    pacijentController.dodajNotifikaciju(pacijent);

                }
            }
        }
    }
}
