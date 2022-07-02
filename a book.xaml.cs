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
            this.ThisBook = book;
            InitializeComponent();
        }

        private void back_Click_1(object sender, RoutedEventArgs e)
        {
            preview p = new preview();
            p.Show();
            this.Close();
        }

        private void read_sample_Click(object sender, RoutedEventArgs e)
        {
            PDF P = new PDF(ThisBook);
            P.Show();
            this.Close();
        }
    }
}
