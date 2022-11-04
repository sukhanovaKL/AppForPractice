using System;
using System.Windows;
using System.Net;


namespace AppForPractice
{
    /// <summary>
    /// Логика взаимодействия для AddKlientsInfoWindow.xaml
    /// </summary>
    public partial class AddKlientsInfoWindow : Window
    {
        public AddKlientsInfoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new KlientsInfoWindow().Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ipAddress = IPAddress.Text.Replace(',', '.').Replace("_", string.Empty);
            if (ComputerNumber.Text == "" || IPAddress.Text == "" || DateStart.Text == "" || DateEnd.Text == "")
                MessageBox.Show("Введены не все значения!");
            else if(!System.Net.IPAddress.TryParse(ipAddress, out IPAddress s))
                MessageBox.Show("Введен неккоректный IP адрес!");
            else
            {
                new Functions().CreateKlientInfo(ComputerNumber.Text, IPAddress.Text, DateTime.Parse(DateStart.Text), DateTime.Parse(DateEnd.Text));
                new KlientsInfoWindow().Show();
                Hide();
            }
        }
    }
}
