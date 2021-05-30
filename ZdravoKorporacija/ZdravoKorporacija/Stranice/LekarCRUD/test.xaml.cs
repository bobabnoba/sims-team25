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
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Stranice.LekoviCRUD;
using ZdravoKorporacija.Stranice.Logovanje;
using ZdravoKorporacija.Stranice.Uput;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>

    public partial class test : Window
    {

        public static Frame prozor = new Frame();
        public test()
        {
            InitializeComponent();
            Main.Content = new lekarStart(new LekarDTO(lekarLogin.lekar));
            prozor = Main;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new lekarStart();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new pregledPacijenata();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Uputi();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new LekarZahteviZaDodavanjeLekaStart();
        }
    }
}
