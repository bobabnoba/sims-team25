using Repository;
using Service;
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

namespace ZdravoKorporacija.Stranice.DinamickaOpremaCRUD
{
    /// <summary>
    /// Interaction logic for dinamickaOpremaStart.xaml
    /// </summary>
    public partial class dinamickaOpremaStart : Page
    {

        UpravnikController upravnikKontroler = new UpravnikController();
        ObservableCollection<DinamickaOpremaDTO> dinamickaOpremaDTO;
        public dinamickaOpremaStart()
        {
            InitializeComponent();
            dinamickaOpremaDTO = upravnikKontroler.PregledMagacinaDinamcikeDTO();
            dgDinamickaOprema.ItemsSource = dinamickaOpremaDTO;
            
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dinamickaOpremaPremestanjeIzMagacina dpm = new dinamickaOpremaPremestanjeIzMagacina(dinamickaOpremaDTO);
            dpm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }


        private void dgDinamickaOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
