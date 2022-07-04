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
        bool isManagerBool = false;
        bool signedIn = false;
        private void back_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void IsManager_Checked(object sender, RoutedEventArgs e)
        {
            isManagerBool = true;
            
        }

        

        private void sign_in1_Click(object sender, RoutedEventArgs e)
        {
            if (isManagerBool)
            {
                if (Manager.emailsList.IndexOf(Email.Text) != -1)
                {
                    Collections.currentManager = Collections.managers[Manager.emailsList.IndexOf(Email.Text)];
                    if (Collections.currentManager.checkPassword(password.Text))
                    {
                        signedIn = true;
                    }
                    else
                    {
                        MessageBox.Show("wrong password !");
                    }
                }
                else
                {
                    MessageBox.Show("this email does not exist !");
                }
            }
            else
            {
                if (User.emailsList.IndexOf(Email.Text)!=-1)
                {
                    Collections.currentUser = Collections.users[User.emailsList.IndexOf(Email.Text)];
                    if (Collections.currentUser.checkPassword(password.Text))
                    {
                        signedIn = true;
                    }
                    else
                    {
                        MessageBox.Show("wrong password !");
                    }
                }
                else
                {
                    MessageBox.Show("this email does not exist !");
                }
            }
            if (signedIn)
            {
                ///close and show next window
                if (isManagerBool)
                {
                    Manager_Dashboard MD = new Manager_Dashboard();
                    MD.Show();
                }
                else
                {
                    user_dashboard UD = new user_dashboard();
                    UD.Show();
                }
                this.Close();
            }
        }
    }
}
