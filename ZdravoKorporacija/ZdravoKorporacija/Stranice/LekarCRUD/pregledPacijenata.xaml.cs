using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Model;
using System;
using Service;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.Uput;
using ZdravoKorporacija.Stranice.LekoviCRUD;

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
        
        public pregledPacijenata()
        {
            InitializeComponent();
            
            pacijenti = new ObservableCollection<Pacijent>(pacijentServis.PregledSvihPacijenata());
            try
            {
                foreach (Termin t in lekarStart.termini)
                {
                    if (t.zdravstveniKarton!=null)
                    {
                        foreach (Pacijent p in pacijenti)
                        {
                            if (t.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                            {
                                if (!pacijentiPrikaz.Contains(p))
                                    pacijentiPrikaz.Add(p);
                            }
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
            Uputi u = new Uputi();
            u.Show();
            this.Close();
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
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            LekarZahteviZaDodavanjeLekaStart l = new LekarZahteviZaDodavanjeLekaStart();
            this.Close();
            l.Show();
        }
    }
}
