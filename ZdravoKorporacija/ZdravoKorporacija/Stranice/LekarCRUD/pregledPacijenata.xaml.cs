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
using ZdravoKorporacija.DTO;
using System.Diagnostics;
using ZdravoKorporacija.Stranice.StacionarnoLecenje;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for pregledPacijenata.xaml
    /// </summary>
    public partial class pregledPacijenata : Window
    {
        private PacijentService pacijentServis = PacijentService.Instance;
        private ObservableCollection<PacijentDTO> pacijenti = new ObservableCollection<PacijentDTO>();
        private ObservableCollection<PacijentDTO> pacijentiPrikaz = new ObservableCollection<PacijentDTO>();
        
        public pregledPacijenata()
        {
            InitializeComponent();
            
            try
            {
                foreach (Termin t in lekarStart.termini)
                {
                    if (t.zdravstveniKarton!=null)
                    {
                        foreach (PacijentDTO p in pacijentServis.PregledSvihPacijenata2())
                        {
                            if (t.zdravstveniKarton.Id.Equals(p.ZdravstveniKarton.Id))
                            {
                                if (!pacijentiPrikaz.Contains(p))
                                {
                                    pacijentiPrikaz.Add(p);
                                }
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
                zk = new zdravstveniKartonPrikaz((PacijentDTO)dgUsers.SelectedItem);
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

        private void stacionarnoLecenje(object sender, RoutedEventArgs e)
        {
            stacionarnoStart ss = null;
            if (dgUsers.SelectedItem != null)
            {
                ss = new stacionarnoStart((PacijentDTO)dgUsers.SelectedItem);
                ss.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }
        private void uputiZaStacionarno(object sender, RoutedEventArgs e)
        {
            uputiZaStacionarno ss = null;
            if (dgUsers.SelectedItem != null)
            {
                ss = new uputiZaStacionarno((PacijentDTO)dgUsers.SelectedItem);
                ss.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }
    }
}
