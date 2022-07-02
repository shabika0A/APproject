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
    /// Interaction logic for user_dashboard.xaml
    /// </summary>
    public partial class user_dashboard : Window
    {
        public user_dashboard()
        {
            DataContext = Collections.books;
            InitializeComponent();

        }
        
    }
}
