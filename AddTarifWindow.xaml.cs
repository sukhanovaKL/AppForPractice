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
    /// Логика взаимодействия для AddTarifWindow.xaml
    /// </summary>
    public partial class AddTarifWindow : Window
    {
        public AddTarifWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new TarifsWindow().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            if (CostText.Text == "" || PreferentialCost_at20to2_Text.Text == "" || PreferentialCost_at2to6_Text.Text == "" || DateText.Text == "")
                MessageBox.Show("Введены не все данные!");
            else if (!int.TryParse(CostText.Text, out int s) || !int.TryParse(PreferentialCost_at20to2_Text.Text, out int s1) || !int.TryParse(PreferentialCost_at2to6_Text.Text, out int s2))
                MessageBox.Show("Стоимость интернета - целое число!");
            else
            {
                Hide();
                new Functions().CreateTarif(int.Parse(CostText.Text), int.Parse(PreferentialCost_at20to2_Text.Text), int.Parse(PreferentialCost_at2to6_Text.Text), DateTime.Parse(DateText.Text));
                new TarifsWindow().Show();
            }
            
        }
    }
}
