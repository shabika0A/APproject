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
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.IO;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Collections.books.Add(new Book("TheLittlePrince", "me", 10, "ofogh", "one diary", "TheLittlePrince", "jpg", "Little Prince"));
            Collections.books.Add(new Book("GreatExpectations", "me", 10, "ofogh", "two diary", "GreatExpectations", "jpg", "GREAT EXPECTATIONS"));
            Collections.users.Add(new User("shakiba", "anaraki", "09123456789", "a@b.com", "something"));
            Collections.managers.Add(new Manager("shakiba", "anaraki", "09123456789", "s@a.com", "something"));
            //Collections.currentUser.isVIP = true;
            Collections.currentManager = Collections.managers[0];
            Collections.managerSignedIn = true;
            Collections.users[0].books.Add(Collections.books[0]);
           Collections.users[0].Wallet=100;
            
            //Manager_Dashboard m = new Manager_Dashboard();
            //m.Show();
            //these are needed please do not remove
            
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\uni\ap\project =)\WpfApp1\database.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command = "select * from users";
            DataTable userdata = new DataTable();
            SqlDataAdapter a = new SqlDataAdapter(command, c);
            a.Fill(userdata);
            for (int i = 0; i < userdata.Rows.Count; i++)
            {
                User u = new User(userdata.Rows[i][1].ToString(), userdata.Rows[i][2].ToString(), userdata.Rows[i][3].ToString(), userdata.Rows[i][0].ToString(), userdata.Rows[i][4].ToString());
                u.Wallet = float.Parse(userdata.Rows[i][5].ToString());
                u.isVIP = bool.Parse(userdata.Rows[i][6].ToString());
                if (u.isVIP)
                {
                    u.VIPendDate = DateTime.Parse(userdata.Rows[i][7].ToString());
                }
                Collections.users.Add(u);
            }
            command= "select * from manager";
            DataTable managerdata = new DataTable();
            a= new SqlDataAdapter(command, c);
            a.Fill(managerdata);
            for (int i = 0; i < managerdata.Rows.Count; i++)
            {
                Manager cm = new Manager(managerdata.Rows[i][1].ToString(), managerdata.Rows[i][2].ToString(), managerdata.Rows[i][3].ToString(), managerdata.Rows[i][0].ToString(), managerdata.Rows[i][4].ToString());
                
                Collections.managers.Add(cm);
            }
            command = "select * from book";
            DataTable bookdata = new DataTable();
            a = new SqlDataAdapter(command, c);
            a.Fill(bookdata);
            for (int i = 0; i < bookdata.Rows.Count; i++)
            {
                Book b = new Book(bookdata.Rows[i][1].ToString(), bookdata.Rows[i][2].ToString(), float.Parse(bookdata.Rows[i][3].ToString()), bookdata.Rows[i][4].ToString(), bookdata.Rows[i][5].ToString(), bookdata.Rows[i][10].ToString(), bookdata.Rows[i][11].ToString(), bookdata.Rows[i][8].ToString(),bool.Parse(bookdata.Rows[i][17].ToString()));
                b.discount = float.Parse(bookdata.Rows[i][6].ToString());
                if (b.discount != 0)
                {
                    b.discountDeadline = DateTime.Parse(bookdata.Rows[i][7].ToString());
                }
                
                b.rate = float.Parse( bookdata.Rows[i][13].ToString());
                b.rateCount = int.Parse(bookdata.Rows[i][14].ToString());
                b.sellingCount = int.Parse(bookdata.Rows[i][15].ToString());
                b.sellingCount = int.Parse(bookdata.Rows[i][16].ToString());
                b.sellingOutcome = float.Parse(bookdata.Rows[i][17].ToString()) ;
                b.CoverAddress = bookdata.Rows[i][12].ToString();         
                b.PDFAddress= bookdata.Rows[i][9].ToString();
                Collections.books.Add(b);
            }

            c.Close();

            foreach (User u in Collections.users)
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
