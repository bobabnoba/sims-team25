using System;
using System.Windows;
using System.Windows.Controls;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for BeleskeStranica.xaml
    /// </summary>
    public partial class BeleskeStranica : Page
    {
        private BeleskaDTO beleskaDTO;
        private PacijentDTO pacijentDTO;
        private BeleskaController beleskaKontroler = new BeleskaController();
        private PacijentController pacijentKontroler = new PacijentController();
        public BeleskeStranica(PacijentDTO pacijentDTO)
        {
            InitializeComponent();
            datum.Visibility = Visibility.Hidden;
            vrijeme.Visibility = Visibility.Hidden;

            beleskaDTO = new BeleskaDTO();
            this.pacijentDTO = pacijentDTO;


        }

        private void CbPodsetiMe_OnChecked(object sender, RoutedEventArgs e)
        {
            datum.Visibility = Visibility.Visible;
            vrijeme.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            beleskaDTO.Sadrzaj = tbBeleska.Text;
            if (datum.SelectedDate != null && vrijeme.Text != null)
            {
                beleskaDTO.Datum = DateTime.Parse(datum.Text + " " + vrijeme.Text);
            }
            else
            {
                beleskaDTO.Datum = DateTime.Now.AddDays(-1);
            }
            beleskaKontroler.sacuvajBelesku(beleskaDTO);
        }
    }
}
