using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Konverteri;

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
  

            beleskaDTO = new BeleskaDTO();
            this.pacijentDTO = pacijentDTO;

            this.DataContext = this;
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
