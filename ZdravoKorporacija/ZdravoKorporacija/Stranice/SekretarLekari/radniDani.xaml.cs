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
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for radniDani.xaml
    /// </summary>
    public partial class radniDani : Window
    {
        private RadniDaniController controller = new RadniDaniController();
        public radniDani(LekarDTO izabrani)
        {
            InitializeComponent();
            controller.InicijalizujRadneDane();
            dgDani.ItemsSource = controller.PregledSvihRadnihDana2DTO(controller.NadjiSveDaneZaLekara(izabrani.Jmbg));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
