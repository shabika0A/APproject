using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using Windows.Storage;
using System;



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
        public string name { set; get; }
        public string author { set; get; }
        public float price { set; get; }
        public string publisher { set; get; }
        public string summery { set; get; }
        public float discount { set; get; }
        public int discountDuration { set; get; }
        //book cover picture
        public DateTime discountDeadline { set; get; }
        //book cover picture
        public string PDFAddress { get; set; }
        public string CoverAddress { get; set; }
        public float? rate { set; get; }
        public int? rateCount { set; get; }
        public int sellingCount { set; get; }
        public float sellingOutcome { set; get; }

        //pdf file
        //preview pdf file
        public Book(string n, string a, float p, string pub, string s, string CoverPictureType, string PDFName)
        {
            name = n;
            author = a;
            price = p;
            publisher = pub;
            summery = s;
            discount = 0;
            discountDuration = 0;
            rate = 0;
            rateCount = 0;
            sellingCount = 0;
            sellingOutcome = 0;
            this.CoverAddress = "\\" + name + "." + CoverPictureType;  //CoverAddress;
            string filename = PDFName + ".PDF";
            this.PDFAddress = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 24) + filename;

        }
    }
    public class User
    {
        public string name { set; get; }
        public string lastName { set; get; }
        public string phoneNumber { set; get; }
        public string email { set; get; }
        string password { set; get; }
        public float Wallet { set; get; }
        public float CartTotalPrice { set; get; }
        public  ObservableCollection<Book> books;
        public  ObservableCollection <Book> favorites;
        public  ObservableCollection<Book> cart;
        public static  ObservableCollection<string> emailsList = new  ObservableCollection<string>();
        ///vip and start and end time and books
        public bool isVIP { set; get; }
        int VIPdays { set; get; }
        public User(string n, string ln, string pn,string e,string p)
        {
            name = n;
            lastName = ln;
            phoneNumber = pn;
            email = e;
            emailsList.Add(e);
            password = p;
            Wallet = 0;
            books = new  ObservableCollection<Book>();
            favorites = new  ObservableCollection<Book>();
            cart = new  ObservableCollection<Book>();
            isVIP = false;
            VIPdays = 0;
        }
        public bool checkPassword(string p)
        {
            if (password == p)
            {
                return true;
            }
            return false;
        }
        public void changeName(string n)
        {
            
            name = n;
        }
        public void changeLastName(string n)
        {
            lastName = n;
        }
        public void changePhoneNumber(string n)
        {
            phoneNumber = n;
        }
        public void changePassword(string n)
        {
            password = n;
        }

    }
    public class Manager
    {
        string name;
        string lastName;
        string phoneNumber;
        public string email;
        public static  ObservableCollection<string> emailsList = new  ObservableCollection<string>();
        string password;
        float TotalCash;
        public Manager(string n, string ln, string pn, string e, string p)
        {
            name = n;
            lastName = ln;
            phoneNumber = pn;
            email = e;            
            password = p;
            TotalCash = 0;
        }
        public bool checkPassword(string p)
        {
            if (password == p)
            {
                return true;
            }
            return false;
        }
        public void changeName(string n)
        {
            name = n;
        }
        public void changeLastName(string n)
        {
            lastName = n;
        }
        public void changePhoneNumber(string n)
        {
            phoneNumber = n;
        }
        public void changePassword(string n)
        {
            password = n;
        }
    }
    public class VIP
    {
        public float PricePerMonth { get; set; }
        ObservableCollection<Book> books;
    }
    
    public class Collections
    {
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        public static ObservableCollection<Manager> managers = new ObservableCollection<Manager>();
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        public static VIP vip = new VIP();
        public static int findBookIndexByName(string n)
        {
            for(int i = 0; i < books.Count; i++)
            {
                if (books[i].name == n)
                {
                    return i;
                }
            }
            return -1;
        }
        public static User currentUser;
        public static Manager currentManager;

    }
    //public class Current
    //{
        
    //    //public Collections collections;
    //}
    public class Methods
    {
        public static float calculateTotalPriceOfCart(User u)
        {
            float FinalPrice = 0;

            foreach (Book b in u.cart)
            {
                DateTime ThisTime = DateTime.Now;
                if (DateTime.Compare(ThisTime, b.discountDeadline) <= 0)
                {
                    FinalPrice += (b.price * b.discount);
                }
                else
                {
                    FinalPrice += b.price;
                }
            }
            return FinalPrice;
        }
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
