﻿using System;
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
<<<<<<< HEAD
using System.Collections.ObjectModel;
=======
>>>>>>> 5e7b12f8c1d4c7e19535eb576bdda5e8d63a371d

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Preview_books.xaml
    /// </summary>
    public partial class Preview_books : Window
    {
        public Preview_books()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
