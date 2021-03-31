using System.Windows;

namespace ZdravoKorporacija.Stranice.LekarCRUD
{
    /// <summary>
    /// Interaction logic for oktaziPregledLekar.xaml
    /// </summary>
    public partial class oktaziPregledLekar : Window
    {
        public oktaziPregledLekar()
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
