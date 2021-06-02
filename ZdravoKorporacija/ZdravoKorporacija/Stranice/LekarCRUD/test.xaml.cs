using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
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
        private string CurrentLanguage { get; set; }
        public test()
        {
            CurrentLanguage = "en-US";
            InitializeComponent();
            Main.Content = new lekarStart(lekarLogin.lekar);
            prozor = Main;
            Trace.WriteLine(CurrentLanguage);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new lekarStart(lekarLogin.lekar);
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

        private void promeniTemu(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if(tema.Header.ToString() == "Tamna tema" || tema.Header.ToString() == "Dark theme")
            {
                app.ChangeTheme(new Uri("Themes/Dark.xaml", UriKind.Relative));
                if (CurrentLanguage.Equals("en-US"))
                {
                    tema.Header = "Light theme";
                }
                else
                {
                    tema.Header = "Svetla tema";
                }
            }
            else 
            {
                app.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative));
                if (CurrentLanguage.Equals("en-US"))
                {
                    tema.Header = "Dark theme";
                }
                else
                {
                    tema.Header = "Tamna tema";
                }
            }
        }

        private void promeniJezik(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            if (CurrentLanguage.Equals("en-US"))
            {
                CurrentLanguage = "sr-LATN";
            }
            else
            {
                CurrentLanguage = "en-US";
            }
            app.ChangeLanguage(CurrentLanguage);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.mw.Show();
        }
          
    }
}
