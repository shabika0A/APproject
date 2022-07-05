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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Collections.books.Add(new Book("TheLittlePrince", "me", 10, "ofogh", "one diary", "TheLittlePrince", "jpg", "Little+Prince sample"));
            Collections.books.Add(new Book("Great Expectations", "me", 10, "ofogh", "two diary", "GreatExpectations", "jpg", "Great Expectations sample"));
            Collections.currentUser = new User("shakiba", "anaraki", "09123456789", "a@b.com", "something");
            Collections.currentUser.isVIP = true;
            Collections.currentUser.books.Add(Collections.books[0]);
            InitializeComponent();
            user_dashboard u = new user_dashboard();
            u.Show();
            Manager_Dashboard M = new Manager_Dashboard();
            M.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Window1 exit = new Window1();
            this.Close();
            exit.Show();
            
            
        }

        private void sign_in_Click(object sender, RoutedEventArgs e)
        {
            sign_in firstSignIn = new sign_in();
            this.Close();
            firstSignIn.Show();
            
        }

        private void sign_up_Click(object sender, RoutedEventArgs e)
        {
            sign_up firstSignUp = new sign_up();
            this.Close();
            firstSignUp.Show();
        }

        private void Preview_Books_Click(object sender, RoutedEventArgs e)
        {
            preview PreviewBooks = new preview();
            //Preview_books PreviewBooks = new Preview_books();
            this.Close();
            PreviewBooks.Show();
        }
    }
}
