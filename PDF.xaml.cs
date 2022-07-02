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
    /// Interaction logic for PDF.xaml
    /// </summary>
    public partial class PDF : Window
    {
        public Book HereBook;
        public PDF(Book ThisBook)
        {
            InitializeComponent();
            HereBook = ThisBook;
            pdfWebViewer.Navigate(new Uri("about:blank"));
            //string filename = @"Little+Prince sample.pdf";
            //string filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length-24) + filename;
            //pdfWebViewer.Navigate(filePath);
            pdfWebViewer.Navigate(ThisBook.PDFAddress);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Book bb = HereBook;
            a_book bWindow = new a_book(bb);
            bWindow.Show();
            this.Close();
        }
    }
}
