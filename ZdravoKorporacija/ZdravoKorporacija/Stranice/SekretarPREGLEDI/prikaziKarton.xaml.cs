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
using ZdravoKorporacija.Repository;

namespace ZdravoKorporacija.Stranice.SekretarPREGLEDI
{
    /// <summary>
    /// Interaction logic for prikaziKarton.xaml
    /// </summary>
    public partial class prikaziKarton : Window
    {
        private KartonRepozitorijum kr = new KartonRepozitorijum();
        private ObservableCollection<ZdravstveniKarton> kartoni = new ObservableCollection<ZdravstveniKarton>();
        private ZdravstveniKarton karton = new ZdravstveniKarton();
        public prikaziKarton(Pacijent izabrani)
        {
            InitializeComponent();
            karton = kr.findById(izabrani.GetJmbg());
            kartoni.Add(karton);
            
            if (karton == null)
            {
                dgKarton.ItemsSource = null;

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
    }
}
