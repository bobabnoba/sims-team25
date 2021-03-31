using System.Windows;

namespace ZdravoKorporacija.Stranice.PacijentCRUD
{
    /// <summary>
    /// Interaction logic for otkaziPregled.xaml
    /// </summary>
    public partial class otkaziPregled : Window
    {
        public otkaziPregled()
        {
            InitializeComponent();
        }

        private void da(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
