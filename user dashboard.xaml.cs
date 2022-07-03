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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for user_dashboard.xaml
    /// </summary>
    public partial class user_dashboard : Window
    {
        public user_dashboard()
        {
            //DataContext = Collections.books;
            InitializeComponent();
        }
        private void ScrollViewer_Initialized(object sender, EventArgs e)
        {
            
        }
        private void Home_Initialized(object sender, EventArgs e)
        {
            //DataContext = Collections.books;
        }
        
        private void user_Search_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            foreach (Book b in Collections.books)
            {
                if (b.name.ToLower().Contains(User_Search_Books.Text.ToLower()) || b.author.ToLower().Contains(User_Search_Books.Text.ToLower()))
                {
                    result.Add(b);
                }
            }
            DataContext = result;
        }

        

        private void add_to_cart_Click(object sender, RoutedEventArgs e)
        {
            Book bb = (Book)(sender as FrameworkElement).DataContext;
            if (Collections.currentUser.books.Contains(bb))
            {
                MessageBox.Show("you already have this book =)");
            }
            else
            {
            Collections.currentUser.cart.Add(bb);
            MessageBox.Show("book was added to cart successfully.");
            }
                
        }

        private void book_cover_Click(object sender, RoutedEventArgs e)
        {
            Book bb = (Book)(sender as FrameworkElement).DataContext;
            a_book bWindow = new a_book(bb);
            bWindow.Show();
            this.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sign_out.IsSelected)
            {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
            }
            if (Home.IsSelected)
            {
                DataContext = Collections.books;
            }
            else if (my_books.IsSelected)
            {
                DataContext = Collections.currentUser.books;
            }
            else if (cart.IsSelected)
            {
                DataContext = Collections.currentUser.cart;
                Collections.currentUser.CartTotalPrice = Methods.calculateTotalPriceOfCart(Collections.currentUser);
                priceBox.Text= Methods.calculateTotalPriceOfCart(Collections.currentUser).ToString();
            }
            else if (favorites.IsSelected)
            {
                DataContext = Collections.currentUser.favorites;
            }

        }

        private void add_to_wishlist_Click(object sender, RoutedEventArgs e)
        {
            Collections.currentUser.favorites.Add((Book)(sender as FrameworkElement).DataContext);
            MessageBox.Show("book was added to favorites successfully.");
        }

        private void remove_from_cart_Click(object sender, RoutedEventArgs e)
        {
            Collections.currentUser.cart.Remove((Book)(sender as FrameworkElement).DataContext);
            Collections.currentUser.CartTotalPrice = Methods.calculateTotalPriceOfCart(Collections.currentUser);

        }

        private void remove_from_wishlist_Click(object sender, RoutedEventArgs e)
        {
            Collections.currentUser.favorites.Remove((Book)(sender as FrameworkElement).DataContext);

        }

        private void pay_online_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage p = new PaymentPage(Collections.currentUser,Collections.currentUser.CartTotalPrice);
            p.Show();
            this.Close();
        }
    }
}
