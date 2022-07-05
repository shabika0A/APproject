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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for addDiscount.xaml
    /// </summary>
    public partial class addDiscount : Window
    {
        Book thisBook;
        bool set = false;
        public addDiscount(Book b)
        {
            InitializeComponent();
            thisBook = b;
        }

        private void discountBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if(Regex.IsMatch(discountBox.Text, "\\d"))
            {
                thisBook.discount = float.Parse(discountBox.Text);
                set = true;
            }
            else
            {

                MessageBox.Show("please enter number");
            }
            if (set)
            {
                this.Close();
            }
        }
    }
}
