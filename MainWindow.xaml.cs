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

namespace AppForPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TrarifsButton_Click(object sender, RoutedEventArgs e)
        {
            new TarifsWindow().Show();
            Hide();
        }

        private void KlientsButton_Click(object sender, RoutedEventArgs e)
        {
            new KlientsInfoWindow().Show();
            Hide();
        }
    }
}
