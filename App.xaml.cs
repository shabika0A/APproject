using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///data must be taken from sql server
    public partial class App : Application
    {
        
    }

    public class Book
    {
        string name;
        string author;
        float price;
        string summery;
        float discount;
        int discountDuration;
        //book cover picture
        float rate;
        int sellingCount;
        float sellingOutcome;
        //pdf file
        //preview pdf file
    }
    public class User
    {
<<<<<<< HEAD
        string name;
        string lastName;
        string phoneNumber;
        string email;
        string password;
        float wallet;
        List<Book> books;
        List<Book> favorites;
        List<Book> cart;
        static List<string> emailsList = new List<string>();
        ///vip and start and end time and books
        bool isVIP;
        int VIPdays;
=======
        public bool IsManager { get; set; }
>>>>>>> 5e7b12f8c1d4c7e19535eb576bdda5e8d63a371d
    }
    public class Manager
    {
<<<<<<< HEAD
        string name;
        string lastName;
        string phoneNumber;
        string email;
        string password;
        float TotalCash;
    }
    public class VIP
    {
        float pricePerMounth;
        List<Book> books;
=======
        
>>>>>>> 5e7b12f8c1d4c7e19535eb576bdda5e8d63a371d
    }
    
    public class Collections
    {
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        public static ObservableCollection<Manager> managers = new ObservableCollection<Manager>();
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        public static VIP vip = new VIP();
    }
    public class methods
    {
        public bool checkCVV(string p)
        {
            if (p.Length == 3 || p.Length == 4)
            {
                return true;
            }
            return false;
        }
        
    }


}
