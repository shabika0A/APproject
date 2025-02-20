﻿using System;
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
