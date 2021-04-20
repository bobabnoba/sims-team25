using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using System;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for pregledPacijenata.xaml
    /// </summary>
    public partial class pregledPacijenata : Window
    {
        private PacijentService pacijentServis = new PacijentService();
        private ObservableCollection<Pacijent> pacijenti = new ObservableCollection<Pacijent>();
        private ObservableCollection<Pacijent> pacijentiPrikaz = new ObservableCollection<Pacijent>();
        private TerminService terminServis = new TerminService();
        private ObservableCollection<Termin> termini = new ObservableCollection<Termin>();
        public pregledPacijenata()
        {
            InitializeComponent();
            termini = new ObservableCollection<Termin>(terminServis.PregledSvihTermina());
            pacijenti = new ObservableCollection<Pacijent>(pacijentServis.PregledSvihPacijenata());
            try
            {
                foreach (Termin t in termini)
                {
                    if (t.zdravstveniKarton!=null)
                    {
                        foreach (Pacijent p in pacijenti)
                            if (t.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                            {
                                if (!pacijentiPrikaz.Contains(p))
                                    pacijentiPrikaz.Add(p);
                            }
                    }
                }
                dgUsers.ItemsSource = pacijentiPrikaz;
                this.DataContext = this;
            }
            catch (NullReferenceException) 
            {
                return;
            }

        }
        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            lekarStart ls = new lekarStart();
            ls.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void prikazKartona(object sender, RoutedEventArgs e)
        {
            zdravstveniKartonPrikaz zk = null;
            if (dgUsers.SelectedItem != null)
            {
                zk = new zdravstveniKartonPrikaz((Pacijent)dgUsers.SelectedItem);
                zk.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }
    }
}
