using Prism.Services.Dialogs;
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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.StacionarnoLecenje
{
    /// <summary>
    /// Interaction logic for uputiZaStacionarno.xaml
    /// </summary>
    public partial class uputiZaStacionarno : Window
    {
        StacionarnoLecenjeController sl = StacionarnoLecenjeController.Instance;
        public static ObservableCollection<StacionarnoLecenjeDTO> uputi = new ObservableCollection<StacionarnoLecenjeDTO>();
        PacijentDTO pac;

        public uputiZaStacionarno(PacijentDTO pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            pac = pacijent;
            foreach (StacionarnoLecenjeDTO s in sl.PregledSvihStacionarnih())
            {
                if (s.Pacijent.Jmbg.Equals(pacijent.Jmbg) && uputi.Count==0)
                {
                    uputi.Add(s); 
                }
                else if(s.Pacijent.Jmbg.Equals(pacijent.Jmbg) && uputi.Count != 0)
                {
                    foreach (StacionarnoLecenjeDTO stac in uputi)
                    {
                        Trace.WriteLine(s.Id);
                        if (!stac.Id.Equals(s.Id))
                        {
                            uputi.Add(s);
                            break;
                        }
                    }
                }
                         
            }
            dgUsers.ItemsSource = uputi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stacionarnoStart ss = new stacionarnoStart(pac);
            ss.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StacionarnoLecenjeDTO stac = null;
            if (dgUsers.SelectedItem != null)
            {
                stac = (StacionarnoLecenjeDTO)dgUsers.SelectedItem;
                izmeniUputStacionarno iu = new izmeniUputStacionarno(pac,stac);
                iu.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StacionarnoLecenjeDTO stac = null;
            if (dgUsers.SelectedItem != null)
            {
                stac = (StacionarnoLecenjeDTO)dgUsers.SelectedItem;
                sl.ObrisiStacionarnoLecenje(stac);
                //uputi.Remove(stac);
            }
            else
            {
                MessageBox.Show("Niste selektovali red", "Greska");
            }
  
        }

    }
}
