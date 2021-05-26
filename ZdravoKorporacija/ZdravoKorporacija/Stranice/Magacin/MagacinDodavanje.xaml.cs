using Model;
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
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinDodavanje.xaml
    /// </summary>
    public partial class MagacinDodavanje : Window
    {
        UpravnikController upravnikKontroler = new UpravnikController();
        ObservableCollection<InventarDTO> opremaUMagacinu = new ObservableCollection<InventarDTO>(); 
        public MagacinDodavanje(ObservableCollection<InventarDTO> magacinOprema)
        {
            InitializeComponent();
            opremaUMagacinu = magacinOprema;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string naziv = textboxNaziv.Text;
            int kolicina = 0;
            try
            {
               kolicina = int.Parse(textboxKolicina.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ne mozemo da pronadjemo uneti broj, molimo vas unesite ponovo", "Greska");
                return;
            }
            string proizvodjac = textboxProizvodjac.Text;

            InventarDTO opremaDTO = new InventarDTO(0, naziv, kolicina, proizvodjac, new DateTime());

            if(upravnikKontroler.DodajUMagacin(opremaDTO)){
                opremaUMagacinu.Add(opremaDTO);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
