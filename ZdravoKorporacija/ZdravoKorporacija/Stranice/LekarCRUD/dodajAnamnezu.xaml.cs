using Controller;
using Model;
using Repository;
using Service;
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
using System.Windows.Shapes;
using ZdravoKorporacija.Controller;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for dodajAnamnezu.xaml
    /// </summary>
    public partial class dodajAnamnezu : Page
    {
        private TerminController terminController = TerminController.Instance;
        private IzvestajDTO izvestaj = new IzvestajDTO();

        TerminDTO termin = new TerminDTO();

       
        public dodajAnamnezu(TerminDTO selektovani)
        {
            InitializeComponent();
            termin = selektovani;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            izvestaj.Simptomi = simptomiText.Text;
            TextRange textRange = new TextRange(opisText.Document.ContentStart, opisText.Document.ContentEnd);
            izvestaj.Opis = textRange.Text;
            

            terminController.IzdajAnamnezu(izvestaj, termin);
            zdravstveniKartonPrikaz.izvestaji.Add(izvestaj);
            test.prozor.Content = new zdravstveniKartonPrikaz(termin);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.prozor.Content = new zdravstveniKartonPrikaz(termin);
        }
    }
}
