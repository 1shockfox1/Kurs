using KursProjectISP31.Model;
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
using System.Windows.Shapes;

namespace KursProjectISP31.View
{
    /// <summary>
    /// Логика взаимодействия для KomponentWindow.xaml
    /// </summary>
    public partial class KomponentWindow : Window
    {

        public Komponent Komponent { get; set; }
        public KomponentWindow( Komponent komponent)
        {
            InitializeComponent();
            Komponent = komponent;
            DataContext = Komponent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
