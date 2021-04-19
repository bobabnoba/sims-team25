using Model;
using Service;
using System;
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
        private PacijentService pacijentServis = new PacijentService();
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();

        public zdravstveniKartonPrikaz(Pacijent selektovani)
        {
            InitializeComponent();
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());

            foreach (IstorijaBolesti i in selektovani.ZdravstveniKarton.GetIstorijaBolesti())
                dgUsers.ItemsSource = i.GetDijagnoza();




            istorijaBolestiGrid.ItemsSource = selektovani.ZdravstveniKarton.GetIstorijaBolesti();
            alergijeGrid.ItemsSource = selektovani.ZdravstveniKarton.Alergije;

            terapijaGrid.ItemsSource = selektovani.ZdravstveniKarton.GetRecept();

            this.DataContext = this;

            ImeLabel.Content = selektovani.Ime;
            PrezimeLabel.Content = selektovani.Prezime;
            BrojTelefonaLabel.Content = selektovani.BrojTelefona;
            JMBGLabel.Content = selektovani.Jmbg;
            PolLabel.Content = selektovani.Pol;

            try { KrvnaGrupaLabel.Content = selektovani.ZdravstveniKarton.KrvnaGrupa; }
            catch(NullReferenceException ex)
            { }
        }

        public zdravstveniKartonPrikaz(Termin t)
        {
            InitializeComponent();
            dijagnoze = new ObservableCollection<Dijagnoza>(dijagnozaServis.PregledSvihDijagnoza());

            foreach (IstorijaBolesti i in t.zdravstveniKarton.GetIstorijaBolesti())
                dgUsers.ItemsSource = i.GetDijagnoza();

            


            istorijaBolestiGrid.ItemsSource = t.zdravstveniKarton.GetIstorijaBolesti();
            
            alergijeGrid.ItemsSource = t.zdravstveniKarton.Alergije;

            terapijaGrid.ItemsSource = t.zdravstveniKarton.GetRecept();

            this.DataContext = this;
            foreach (Pacijent p in pacijenti)
            {
                if(p.ZdravstveniKarton.Id==t.zdravstveniKarton.Id)
                ImeLabel.Content = p.Ime;
                PrezimeLabel.Content = p.Prezime;
                BrojTelefonaLabel.Content = p.BrojTelefona;
                JMBGLabel.Content = p.Jmbg;
                PolLabel.Content = p.Pol;

                try { KrvnaGrupaLabel.Content = p.ZdravstveniKarton.KrvnaGrupa; }
                catch (NullReferenceException ex)
                { }
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KrvnaGrupaLabel_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
