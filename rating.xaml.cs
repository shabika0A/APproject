using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for rating.xaml
    /// </summary>
    public partial class rating : Window
    {
        Book cb;
        public rating( Book b)
        {
            cb = b;
            InitializeComponent();
        }

        private void submitRate_Click(object sender, RoutedEventArgs e)
        {
            cb.rate = (cb.rate * (cb.rateCount) + rateBar.Value) / (cb.rateCount + 1);
            cb.rateCount++;
            this.Close();
        }
    }
}
