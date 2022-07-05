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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for userInfo.xaml
    /// </summary>
    public partial class userInfo : Window
    {
        public userInfo(User u)
        {
            InitializeComponent();
            showName.Text = u.name;
            showLastName.Text = u.lastName;
            showEmail.Text = u.email;
            showPhoneNumber.Text = u.phoneNumber;
            if (u.isVIP)
            {
                showVIP.Text = "a VIP user";
            }
            else
            {
                showVIP.Text = "NOT a VIP user";
            }
            DataContext = u.books;

        }
    }
}
