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

namespace AppForPractice
{
    /// <summary>
    /// Логика взаимодействия для DeleteTarifWindow.xaml
    /// </summary>
    public partial class DeleteTarifWindow : Window
    {
        InternetPrice _internetPrice;
        practica_5Entities db = new practica_5Entities();
        public DeleteTarifWindow(InternetPrice internetPrice)
        {
            InitializeComponent();
            _internetPrice = internetPrice;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TarifsWindow().Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            new Functions().DeleteTarif(_internetPrice.InternetPricesId);
            new TarifsWindow().Show();
        }
    }
}
