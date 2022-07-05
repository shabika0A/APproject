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
    /// Interaction logic for a_book.xaml
    /// </summary>
    public partial class a_book : Window
    {
        Book ThisBook;
        public a_book(Book book)
        {
            DataContext = book;
            InitializeComponent();
            ThisBook = book;
        }

        private void back_Click_1(object sender, RoutedEventArgs e)
        {
            if (Collections.managerSignedIn)
            {
                Manager_Dashboard m = new Manager_Dashboard();
                m.Show();
                this.Close();
            }
            else
            {
                user_dashboard m = new user_dashboard();
                m.Show();
                this.Close();
            }
        }

        private void read_sample_Click(object sender, RoutedEventArgs e)
        {
            PDF p = new PDF(ThisBook);
            p.Show();
            this.Close();
        }
    }
}
