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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for sign_in.xaml
    /// </summary>
    public partial class sign_in : Window
    {
        public sign_in()
        {
            InitializeComponent();
        }

        

        private void back_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void IsManager_Checked(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            //user NewUser = new user();
            //NewUser.IsManager = true;
            
=======
            user NewUser = new user();
            NewUser.IsManager = true;
>>>>>>> 5e7b12f8c1d4c7e19535eb576bdda5e8d63a371d
        }
    }
}
