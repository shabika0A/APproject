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
using System.Windows.Threading;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\uni\ap\project =)\WpfApp1\database.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command = "DELETE FROM users; ";
            List<string>[] bookowners = new List<string>[Collections.books.Count];
            List<string>[] favs = new List<string>[Collections.books.Count];
            List<string>[] carts = new List<string>[Collections.books.Count];
            for(int i = 0; i < Collections.books.Count; i++)
            {
                bookowners[i] = new List<string>();
                favs[i] = new List<string>();
                carts[i] = new List<string>();
            }
            foreach (User u in Collections.users)
            {
                command += "insert into users values('" + u.email + "','" + u.name + "','" + u.lastName + "','" + u.phoneNumber + "','" + u.password + "','" + u.Wallet + "','" + Convert.ToByte(u.isVIP) + "','" + u.VIPendDate.ToString() + "');";
                foreach (Book b in u.books)
                {
                    bookowners[Collections.books.IndexOf(b)].Add(Collections.users.IndexOf(u).ToString());
                }
                foreach (Book b in u.favorites)
                {
                    favs[Collections.books.IndexOf(b)].Add(Collections.users.IndexOf(u).ToString());
                }
                foreach (Book b in u.cart)
                {
                    carts[Collections.books.IndexOf(b)].Add(Collections.users.IndexOf(u).ToString());
                }
            }
            
            //scom.BeginExecuteNonQuery();
            command += "delete from manager;";
            foreach (Manager u in Collections.managers)
            {
                command += "insert into manager values('" + u.email + "','" + u.name + "','" + u.lastName + "','" + u.phoneNumber + "','" + u.password + "');";

            }
            ////scom.BeginExecuteNonQuery();
            ////command = "";
            command += "delete from book;";
            foreach (Book u in Collections.books)
            {
                string o = "";
                foreach (string e in bookowners[Collections.books.IndexOf(u)])
                {
                    o = o + e + "*";
                }
                o = o.TrimEnd('*');
                string f = "";
                foreach (string e in favs[Collections.books.IndexOf(u)])
                {
                    f = f + e + "*";
                }
                f = f.TrimEnd('*');
                string car = "";
                foreach (string e in carts[Collections.books.IndexOf(u)])
                {
                    car = car + e + "*";
                }
                car = car.TrimEnd('*');
                command += "insert into book values('" + Collections.findBookIndexByName(u.name) + "','" + u.name + "','" + u.author + "','" + u.price + "','" + u.publisher + "','" + u.summery + "','" + u.discount + "','" + u.discountDeadline.ToString() + "','" + u.PDFName + "','" + u.PDFAddress + "','" + u.CoverPictureName + "','" + u.CoverPictureType + "','" + u.CoverAddress + "','" + u.rate + "','" + u.rateCount + "','" + u.sellingCount + "','" + u.sellingOutcome + "','" + Convert.ToByte(u.IsVIP) + "','" + o + "','" + f + "','" + car + "');";
            }
            SqlCommand scom = new SqlCommand(command, c);
            scom.BeginExecuteNonQuery();
            c.Close();
            void StartCloseTimer()
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3d);
                timer.Tick += TimerTick;
                timer.Start();
            }
            void TimerTick(object sender, EventArgs e)
            {
                DispatcherTimer timer = (DispatcherTimer)sender;
                timer.Stop();
                timer.Tick -= TimerTick;
                Close();
            }
            StartCloseTimer();
        }
        
    }
}
