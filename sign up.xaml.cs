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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for sign_up.xaml
    /// </summary>
    public partial class sign_up : Window
    {
        bool checkPhoneNumber(string s)
        {
            //Regex r = new Regex();
            if (!Regex.IsMatch(s, "^[0-9]+$") || s[0] != '0' || s[1] != '9'||s.Length!=11)
            {
                return false;
            }
            return true;
        }
        bool checkName(string s)
        {

            if (!Regex.IsMatch(s, "^[a-zA-Z]*$") || s.Length < 3 || s.Length > 32)
            {
                return false;
            }
            return true;
        }
        bool checkEmail(string s)
        {
           
            if (!Regex.IsMatch(s, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") || s.Length < 3 || s.Length > 32)
            {
                return false;
            }
            return true;
        }
        bool checkPassword(string s)
        {
            
            if (Regex.IsMatch(s, "[a-z]") && Regex.IsMatch(s, "[A-Z]") && s.Length > 7 && s.Length < 41)
            {
                return true;
            }
            return false;
        }
        public sign_up()
        {
            InitializeComponent();
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
        bool isManagerBool = false;
        private void IsManager_Checked(object sender, RoutedEventArgs e)
        {
            
            isManagerBool = true;
        }

        private void sign_up_in_page_Click(object sender, RoutedEventArgs e)
        {
            if (!checkName(name.Text))
            {
                MessageBox.Show("wrong name format!");

            }
            else if (!checkName(lastName.Text))
            {
                MessageBox.Show("wrong last name format!");

            }
            else if (!checkPhoneNumber(phoneNumber.Text))
            {
                MessageBox.Show("wrong phone number format");

            }
            else if (!checkEmail(Email.Text))
            {
                MessageBox.Show("wrong email format");

            }
            else if (!checkPassword(password.Text))
            {
                MessageBox.Show("wrong password format");

            }
            else if (password.Text!=ConfirmPassword.Text)
            {
                MessageBox.Show("password and confirm password are not similar");

            }
            else if (isManagerBool)
            {
                Manager u = new Manager();
                Collections.managers.Add(u);
                
            }
            else
            {
                User u = new User();

               Collections.users.Add(u);
                
            }
        }
    }
}
