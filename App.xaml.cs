﻿using System.Collections.Generic;
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
        public string name { set; get; }
        public string author { set; get; }
        public float price { set; get; }
        public string publisher { set; get; }
        public string summery { set; get; }
        public float discount { set; get; }
        public int discountDuration { set; get; }
        //book cover picture
        public float? rate { set; get; }
        public int sellingCount { set; get; }
        public float sellingOutcome { set; get; }
        //pdf file
        //preview pdf file
        public Book(string n,string a,float p,string pub,string s)
        {
            name = n;
            author = a;
            price = p;
            publisher = pub;
            summery = s;
            discount = 0;
            discountDuration = 0;
            rate = null;
            sellingCount = 0;
            sellingOutcome = 0;
        }
    }
    public class User
    {
        string name;
        string lastName;
        string phoneNumber;
        public string email;
        string password;
        float wallet;
        public  ObservableCollection<Book> books;
        public  ObservableCollection <Book> favorites;
        public  ObservableCollection<Book> cart;
        public static  ObservableCollection<string> emailsList = new  ObservableCollection<string>();
        ///vip and start and end time and books
        bool isVIP;
        int VIPdays;
        public User(string n, string ln, string pn,string e,string p)
        {
            name = n;
            lastName = ln;
            phoneNumber = pn;
            email = e;
            emailsList.Add(e);
            password = p;
            wallet = 0;
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
        float pricePerMounth;
         ObservableCollection<Book> books;
    }
    
    public class Collections
    {
        public static ObservableCollection<User> users = new ObservableCollection<User>();
        public static ObservableCollection<Manager> managers = new ObservableCollection<Manager>();
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        public static VIP vip = new VIP();
        
    }
    public class Current
    {
        public static User user;
        public static Manager manager;
        //public Collections collections;
    }
    public class Methods
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
