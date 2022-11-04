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
    /// Логика взаимодействия для KlientsInfoWindow.xaml
    /// </summary>
    public partial class KlientsInfoWindow : Window
    {
        practica_5Entities db = new practica_5Entities();
        public KlientsInfoWindow()
        {
            InitializeComponent();
            data.ItemsSource = db.KlientsInfo.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddKlientsInfoWindow().Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Hide();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var f = (sender as Button).DataContext as KlientsInfo;
            new DeleteKlientInfoWindow(f).Show();
            Hide();
        }
    }
}
