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
using System.Text.RegularExpressions;

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
            else if (Collections.currentUser.cart.Contains(bb))
            {
                MessageBox.Show("you already have this book in your cart =)");
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
            if (Collections.currentUser.books.Contains(bb))
            {
                PDF P = new PDF(bb, false);
                P.Show();
            }
            else
            {
                a_book bWindow = new a_book(bb);
                bWindow.Show();
            }
            //Book bb = (Book)(sender as FrameworkElement).DataContext;
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
                //DataContext = Collections.currentUser.books;
                ObservableCollection<Book> allBooks = Collections.currentUser.books;
                if (Collections.currentUser.isVIP)
                {
                    foreach (Book b in Collections.books)
                    {
                        if (b.IsVIP)
                        {
                            allBooks.Add(b);
                        }
                    }
                }
                DataContext = allBooks;
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
            else if (Wallet.IsSelected)
            {
                //DataContext = price;////must be changed! after having banking account
                DataContext = Collections.currentUser;
            }
            else if (edit_profile.IsSelected)
            {
                DataContext = Collections.currentUser;
                showName.Text = Collections.currentUser.name;
                showLastName.Text = Collections.currentUser.lastName;
                if (!Collections.currentUser.isVIP)
                {
                    //hide vip image
                    isVIP.Visibility = Visibility.Hidden;
                }
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
            //this.Close();
        }

        private void Charge_your_wallet_Click(object sender, RoutedEventArgs e)
        {
            Charge_Wallet ChW = new Charge_Wallet(Collections.currentUser);
            ChW.Show();
        }

        private void BuyVIP_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage P = new PaymentPage(Collections.currentUser, Collections.vip.PricePerMonth);
            P.Show();
        }

        private void rate_Click(object sender, RoutedEventArgs e)
        {
            rating r = new rating((Book)(sender as FrameworkElement).DataContext);
            r.Show();
        }
        bool checkPhoneNumber(string s)
        {
            //Regex r = new Regex();
            if (!Regex.IsMatch(s, "^[0-9]+$") || s[0] != '0' || s[1] != '9' || s.Length != 11)
            {
                return false;
            }
            return true;
        }
        bool checkName(string s)
        {

            if (!Regex.IsMatch(s, "^[a-zA-Z]*$") || s.Length < 3 || s.Length > 32)
            {
                return false;
            }
            return true;
        }
        bool checkEmail(string s)
        {

            if (!Regex.IsMatch(s, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || s.Length < 3 || s.Length > 32)
            {
                return false;
            }
            return true;
        }
        bool checkPassword(string s)
        {

            if (Regex.IsMatch(s, "[a-z]") && Regex.IsMatch(s, "[A-Z]") && s.Length > 7 && s.Length < 41)
            {
                return true;
            }
            return false;
        }

        private void save_changes_Click(object sender, RoutedEventArgs e)
        {
            if (!checkName(name.Text))
            {
                MessageBox.Show("wrong name format!");

            }
            else if (!checkName(lastName.Text))
            {
                MessageBox.Show("wrong last name format!");

            }
            else if (!checkPhoneNumber(phoneNumber.Text))
            {
                MessageBox.Show("wrong phone number format");

            }
            else
            {
                Collections.currentUser.changeName(name.Text);
                Collections.currentUser.changeLastName(lastName.Text);
                Collections.currentUser.changePhoneNumber(phoneNumber.Text);
            }
        }

        

        private void save_password_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Collections.currentUser.checkPassword(CPass.Text))
            {
                MessageBox.Show("wrong Password! please enter again.");
            }else if (!checkPassword(NPass.Text))
            {
                MessageBox.Show("new password has wrong format");

            }else if (NPass.Text != CNPass.Text)
            {
                MessageBox.Show("new password is not confirmed well.");
            }
            else
            {
                Collections.currentUser.changePassword(NPass.Text);
            }
        }

        private void pay_by_wallet_Click(object sender, RoutedEventArgs e)
        {
            if (Collections.currentUser.Wallet >= Methods.calculateTotalPriceOfCart(Collections.currentUser))
            {
                Collections.currentUser.Wallet -= Methods.calculateTotalPriceOfCart(Collections.currentUser);
                Methods.AddBooksToUserFromCart(Collections.currentUser);
                Collections.TotalCash += Methods.calculateTotalPriceOfCart(Collections.currentUser);
            }
            else
            {
                MessageBox.Show("You do not have enough money in your wallet!");
            }
        }
    }
}
