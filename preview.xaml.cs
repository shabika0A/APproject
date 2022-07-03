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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for preview.xaml
    /// </summary>
    public partial class preview : Window
    {
        public preview()
        {
           
            //Collections.books.Add(new Book("five", "me", 10, "ofogh", "my diary"));
            //Collections.books.Add(new Book("ten", "me", 10, "ofogh", "my diary"));
            //Collections.books.Add(new Book("youuu", "me", 10, "ofogh", "my diary"));
            //Collections.books.Add(new Book("6")); Collections.books.Add(new Book("7")); Collections.books.Add(new Book("8"));
            DataContext = Collections.books;
            InitializeComponent();
        }

        private void back_Click_1(object sender, RoutedEventArgs e)
        {
           
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Search_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            foreach(Book  b in Collections.books)
            {
                if(b.name.Contains(Search_Books.Text)|| b.author.Contains(Search_Books.Text))
                {
                    result.Add(b);
                }
            }
            DataContext = result;
        }

        private void b_is_clicked(object sender, RoutedEventArgs e)
        {
            Book bb= (Book)(sender as FrameworkElement).DataContext;
            a_book bWindow = new a_book(bb);
            bWindow.Show();
            this.Close();
        }
    }
    
    
}
