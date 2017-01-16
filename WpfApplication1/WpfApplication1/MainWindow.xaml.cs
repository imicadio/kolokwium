using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hotel hotel = new Hotel();

        public MainWindow()
        {
            InitializeComponent();
            GridGoscia.Visibility = Visibility.Hidden;
            GridDaty.Visibility = Visibility.Hidden;
        }

        private void Wyczysc_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
        }

        private void DataRezerwacji_Click(object sender, RoutedEventArgs e)
        {
            GridDaty.Visibility = Visibility.Visible;
            GridGoscia.Visibility = Visibility.Hidden;

        }

        private void DodajRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            GridGoscia.Visibility = Visibility.Visible;
            GridDaty.Visibility = Visibility.Hidden;
        }

        private void DodajGoscie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pokoj;
                pokoj = Convert.ToInt32(NrPokoju);
                if (pokoj <= 0)
                    throw new ArgumentOutOfRangeException();
                double cena;
                cena = Convert.ToDouble(CenaZaDobe);
                if (cena <= 0)
                    throw new ArgumentOutOfRangeException();

                hotel.DodajRezerwacje(ImieGoscia.Text, NazwiskoGoscia.Text, pokoj, cena);
                TextBox.Text = hotel.ToString();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void DodajData_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void UsunRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            hotel.OdwolajRezerwacje();
            TextBox.Text = hotel.ToString();
        }


    }
}
