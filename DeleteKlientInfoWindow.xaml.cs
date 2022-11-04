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
    /// Логика взаимодействия для DeleteKlientInfoWindow.xaml
    /// </summary>
    public partial class DeleteKlientInfoWindow : Window
    {
        KlientsInfo KlientsInfo;
        public DeleteKlientInfoWindow(KlientsInfo klientsInfo)
        {
            InitializeComponent();
            KlientsInfo = klientsInfo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new KlientsInfoWindow().Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Functions().DeleteKlientInfo(KlientsInfo.KlientId);
            new KlientsInfoWindow().Show();
            Hide();
        }
    }
}
