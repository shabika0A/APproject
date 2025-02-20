﻿using System.Collections.Generic;
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
        public DateTime discountDeadline { get; set; }
        //public int discountDuration { set; get; }
        //book cover picture
        public string PDFName { get; set; }
        public string PDFAddress { get; set; }
        public string CoverPictureName { get; set; }
        public string CoverPictureType { get; set; }
        public string CoverAddress { get; set; }
        public float rate { set; get; }
        public int rateCount { set; get; }
        public int sellingCount { set; get; }
        public float sellingOutcome { set; get; }
        public bool IsVIP { get; set; }
        

        //pdf file
        //preview pdf file
        public Book(string n, string a, float p, string pub, string s, string CoverPictureName, string CoverPictureType, string PDFName, bool IsVIP = false)
        {
            name = n;
            author = a;
            price = p;
            publisher = pub;
            summery = s;
            discount = 0;
            //discountDuration = 0;
            rate = 0;
            rateCount = 0;
            sellingCount = 0;
            sellingOutcome = 0;
            this.CoverPictureName = CoverPictureName;
            this.CoverPictureType = CoverPictureType;
            this.CoverAddress = "\\" + this.CoverPictureName + "." + this.CoverPictureType;  //CoverAddress;
            this.PDFName = PDFName;
            string filename = this.PDFName + ".PDF";
            this.PDFAddress = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 24) + filename;
            this.IsVIP = IsVIP;
        }
    }
    public class User
    {
        public string name { set; get; }
        public string lastName { set; get; }
        public string phoneNumber { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public float Wallet { set; get; }
        public float CartTotalPrice { set; get; }
        public ObservableCollection<Book> books;
        public ObservableCollection<Book> favorites;
        public ObservableCollection<Book> cart;
        public static ObservableCollection<string> emailsList = new ObservableCollection<string>();
        ///vip and start and end time and books
        public bool isVIP { set; get; }
        public DateTime VIPendDate { set; get; }
        public User(string n, string ln, string pn, string e, string p)
        {
            name = n;
            lastName = ln;
            phoneNumber = pn;
            email = e;
            password = p;
            Wallet = 0;
            books = new ObservableCollection<Book>();
            favorites = new ObservableCollection<Book>();
            cart = new ObservableCollection<Book>();
            isVIP = false;
            CartTotalPrice = 0;
            emailsList.Add(e);
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
        public string name { set; get; }
        public string lastName { set; get; }
        public string phoneNumber { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public static ObservableCollection<string> emailsList = new ObservableCollection<string>();

        //public float TotalCash { get; set; }
        public Manager(string n, string ln, string pn, string e, string p)
        {
            name = n;
            lastName = ln;
            phoneNumber = pn;
            email = e;
            password = p;
            //TotalCash = 0;
            emailsList.Add(e);
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
        public VIP()
        {
            PricePerMonth = 100;
        }
    }

    public class Collections
    {
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        public static ObservableCollection<Manager> managers = new ObservableCollection<Manager>();
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        public static VIP vip = new VIP();
        public static bool userSignedIn = false;
        public static bool managerSignedIn = false;
        public static int findBookIndexByName(string n)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].name == n)
                {
                    return i;
                }
            }
            return -1;
        }
        public static User findUserByEmail(string n)
        {
            return users[User.emailsList.IndexOf(n)];
        }
        public static User currentUser;
        public static Manager currentManager;
        public static float TotalCash;

    }

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
                    FinalPrice += (b.price * (1 - b.discount));
                }
                else
                {
                    FinalPrice += b.price;
                }
            }
            u.CartTotalPrice = FinalPrice;
            return FinalPrice;
        }

        //public float TotalCashSum ()
        //{
        //    float sum = 0;
        //    foreach (Manager m in Collections.managers)
        //    {
        //        sum += m.TotalCash;
        //    }
        //    return sum;
        //}
        
        public static void AddBooksToUserFromCart (User u)
        {
            foreach (Book b in u.cart)
            {
                u.books.Add(b);
                b.sellingCount++;
                float BookPrice = 0;
                DateTime ThisTime = DateTime.Now;
                if (DateTime.Compare(ThisTime, b.discountDeadline) <= 0)
                {
                    BookPrice = (b.price * (1 - b.discount));
                }
                else
                {
                    BookPrice = b.price;
                }
                b.sellingOutcome += BookPrice;
                //u.cart.Remove(b);
            }
            u.cart.Clear();
            //Collections.currentUser.cart.Remove((Book)(sender as FrameworkElement).DataContext);
            //Collections.currentUser.CartTotalPrice = Methods.calculateTotalPriceOfCart(Collections.currentUser);
            //foreach (Book b in u.cart)
            //{
            //    u.cart.Remove(b);
            //}
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