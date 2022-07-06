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
            Collections.books.Add(new Book("GreatExpectations", "me", 10, "ofogh", "two diary", "GreatExpectations", "jpg", "Great Expectations sample"));
            Collections.users.Add(new User("shakiba", "anaraki", "09123456789", "a@b.com", "something"));
            Collections.managers.Add(new Manager("shakiba", "anaraki", "09123456789", "s@a.com", "something"));
            //Collections.currentUser.isVIP = true;
            Collections.currentManager = Collections.managers[0];
            Collections.managerSignedIn = true;
            Collections.users[0].books.Add(Collections.books[0]);
           Collections.users[0].Wallet=100;
            
            Manager_Dashboard m = new Manager_Dashboard();
            m.Show();
            //these are needed please do not remove
            foreach(User u in Collections.users)
            {
                if (u.isVIP && DateTime.Compare(DateTime.Now, u.VIPendDate) > 0)
                {
                    u.isVIP = false;
                }
            }
            InitializeComponent();
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
