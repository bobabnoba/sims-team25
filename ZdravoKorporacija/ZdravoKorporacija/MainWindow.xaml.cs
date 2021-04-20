using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Stranice;
using ZdravoKorporacija.Stranice.LekarCRUD;
using ZdravoKorporacija.Stranice.SekretarCRUD;
using ZdravoKorporacija.Stranice.UpravnikCRUD;

namespace ZdravoKorporacija
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ContentControl cc = new ContentControl();
        public MainWindow() 
        { 
            InitializeComponent();
            cc.Content = this.Content;
        }

       


        private void AutoColumns_Click(object sender, RoutedEventArgs e)
        {
            LekarRepozitorijum LekarJSON = new LekarRepozitorijum();
            List<Lekar> lekari = new List<Lekar>();
            Lekar dr1 = new Lekar("Veljko", "Vukovic", 2334567890213, 066393345, "vuksivuk@gmail.com", "Beograd", PolEnum.Muski, "veksi", "vukovic", UlogaEnum.Lekar);
            Pacijent p1 = new Pacijent("Dusan", "Markovic", 1234567890123, 069000333, "dusanmarkovic@gmail.com", "Smederevska tvrdjava", PolEnum.Muski, "dukikidu", "markovic99", UlogaEnum.Lekar);
            ZdravstveniKarton zd1 = new ZdravstveniKarton(p1, 1, StanjePacijentaEnum.Kriticno, "pcele", KrvnaGrupaEnum.APozitivna, "nevekcinisan");
            Prostorija pr1 = new Prostorija(1, "soba za pregled", TipProstorijeEnum.Soba, true, 2);
            dr1.AddTermin(new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 5, 1, 8, 30, 52), 90));
            Lekar dr2 = new Lekar("Milos", "Zivic", 2234567890113, 069393334, "zivko99@gmail.com", "Becej", PolEnum.Muski, "milos", "zivic", UlogaEnum.Lekar);
            lekari.Add(dr1);
            lekari.Add(dr2);

            LekarJSON.sacuvaj(lekari);
        }

        private void ManualColumns_Click(object sender, RoutedEventArgs e)
        {
            PacijentRepozitorijum pacijentJSON = new PacijentRepozitorijum();
            List<Pacijent> pacijenti = new List<Pacijent>();
            Prostorija pr1 = new Prostorija(1, "soba za pregled", TipProstorijeEnum.Soba, true, 2);
            Prostorija pr2 = new Prostorija(2, "soba za operaciju", TipProstorijeEnum.OperacionaSala, true, 1);
            Pacijent p1 = new Pacijent("Dusan", "Markovic", 1234567890123, 069000333, "dusanmarkovic@gmail.com", "Smederevska tvrdjava", PolEnum.Muski, "dukikidu", "markovic99", UlogaEnum.Pacijent);
            Pacijent p2 = new Pacijent("Dusan", "Lekic", 3214567890122, 066333999, "dusanlekic@gmail.com", "Rokijev potok", PolEnum.Muski, "leka", "leka99", UlogaEnum.Pacijent);
            Pacijent p3 = new Pacijent("Aleksa", "Papovic", 2134567890213, 066393654, "aleksapapovic@gmail.com", "Grbavica", PolEnum.Muski, "pape", "pape99", UlogaEnum.Pacijent);
            Lekar dr1 = new Lekar("Veljko", "Vukovic", 2334567890213, 066393345, "vuksivuk@gmail.com", "Beograd", PolEnum.Muski, "veksi", "vukovic", UlogaEnum.Lekar);
            ZdravstveniKarton zd1 = new ZdravstveniKarton(p1, 1, StanjePacijentaEnum.Kriticno, "pcele", KrvnaGrupaEnum.APozitivna, "nevekcinisan");
            ZdravstveniKarton zd2 = new ZdravstveniKarton(p2, 2, StanjePacijentaEnum.Stabilno, "nema", KrvnaGrupaEnum.ABNegativna, "sinovac");
            Termin tr1 = new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 5, 1, 8, 30, 52), 90);
            Termin tr2 = new Termin(zd1, pr1, dr1, TipTerminaEnum.Pregled, new DateTime(2020, 6, 6, 6, 30, 52), 90);
            TerminRepozitorijum terminiJSON = new TerminRepozitorijum();
            List<Termin> termini = new List<Termin>();
            ProstorijaRepozitorijum prostorijeJSON = new ProstorijaRepozitorijum();
            List<Prostorija> prostorije = new List<Prostorija>();
            termini.Add(tr1);
            termini.Add(tr2);
            p1.AddTermin(tr1);
            pacijenti.Add(p1);
            pacijenti.Add(p2);
            pacijenti.Add(p3);
            prostorije.Add(pr1);
            prostorije.Add(pr2);
            pacijentJSON.sacuvaj(pacijenti);
            terminiJSON.sacuvaj(termini);
            prostorijeJSON.sacuvaj(prostorije);
        }

        private void Binding_Click(object sender, RoutedEventArgs e)
        {
            SekretarRepozitorijum sekretarJSON = new SekretarRepozitorijum();
            List<Sekretar> sekretari = new List<Sekretar>();
            Sekretar s1 = new Sekretar("Stefan", "Mitrovic", 4444567890123, 0621100333, "mitrovic@gmail.com", "Kragujevac", PolEnum.Muski, "mitros", "mitrovic99", UlogaEnum.Sekretar);
            Sekretar s2 = new Sekretar("Aleksandra", "Petrovic", 5554567890123, 063123333, "saska@gmail.com", "Sombor", PolEnum.Zenski, "saska", "petrovic99", UlogaEnum.Sekretar);
            sekretari.Add(s1);
            sekretari.Add(s2);
            sekretarJSON.sacuvaj(sekretari);
        }





        private void openUpravnikFrame(object sender, RoutedEventArgs e)
        {
            upravnikPocetna s = new upravnikPocetna();
            s.Show();
        }
        private void openLekarFrame(object sender, RoutedEventArgs e)
        {
            lekarStart s = new lekarStart();
            s.Show();
        }
        private void openSekretarFrame(object sender, RoutedEventArgs e)
        {
            sekretarStart s = new sekretarStart();
            s.Show();
        }
        private void openPacijentFrame(object sender, RoutedEventArgs e)
        {
            pacijentStart s = new pacijentStart();
            s.Show();
        }
    }
}
