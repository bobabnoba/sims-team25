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
using DTO;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.Stranice.SekretarLekari
{
    /// <summary>
    /// Interaction logic for slobodniDani.xaml
    /// </summary>
    public partial class slobodniDani : Window
    {
        private RadniDaniController controller = new RadniDaniController();
        private DateTime Od;
        private DateTime Do;
        private double id;
        public slobodniDani(LekarDTO lekar)
        {
            InitializeComponent();
            id = lekar.Jmbg;
            
        }

      

        private void dodaj(object sender, RoutedEventArgs e)
        {
            Od = DateTime.Parse(odDP.Text);
            Do = DateTime.Parse(doDP.Text);
            
            controller.DodajSlobodneDane(Od, Do, id);
            this.Close();
        }
    }
}
