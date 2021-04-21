using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Repository;
using Service;


namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for prikaziKarton.xaml
    /// </summary>
    public partial class prikaziKarton : Window
    {
        private ZdravstveniKartonServis kr = new ZdravstveniKartonServis();
        private ObservableCollection<ZdravstveniKarton> kartoni = new ObservableCollection<ZdravstveniKarton>();
        private ZdravstveniKarton karton = new ZdravstveniKarton();
        private Pacijent pacijent = new Pacijent();
        public prikaziKarton(Pacijent izabrani)
        {
            InitializeComponent();
            pacijent = izabrani;
            karton = kr.findById(izabrani.GetJmbg());
            kartoni.Add(karton);
            
            if (karton == null)
            {
                dgKarton.ItemsSource = null ;
                nemaText.Visibility = Visibility.Visible;
                nemaButt.Visibility = Visibility.Visible;

            } else
            {
                dgKarton.ItemsSource = kartoni;

            }

            // alergije.Text = izabrani.zdravstveniKarton.getAlergije();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nemaButt_Click(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton zk = new ZdravstveniKarton(pacijent, pacijent.GetJmbg(), StanjePacijentaEnum.None, "", KrvnaGrupaEnum.None, "");
            kr.KreirajZdravstveniKartonJMBG(zk);
            this.Close();
            
        }
    }
}
