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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Manager_Dashboard.xaml
    /// </summary>
    public partial class Manager_Dashboard : Window
    {

        public Manager_Dashboard()
        {
            //DataContext = Collections.books;
            InitializeComponent();
        }

        private void Sign_out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void ScrollViewer_Initialized(object sender, EventArgs e)
        {

        }
        private void Home_Initialized(object sender, EventArgs e)
        {
            //DataContext = Collections.books;
        }

        private void Edit_Book_Click(object sender, RoutedEventArgs e)
        {
            Edit_Book E = new Edit_Book((Book)(sender as FrameworkElement).DataContext);
            E.Show();
        }

        private void Delete_Book_Click(object sender, RoutedEventArgs e)
        {
            Collections.books.Remove((Book)(sender as FrameworkElement).DataContext);
        }

        private void book_cover_Click(object sender, RoutedEventArgs e)
        {
            Book bb = (Book)(sender as FrameworkElement).DataContext;
            //a_book bWindow = new a_book(bb);
            //bWindow.Show();
            PDF P = new PDF(bb, false);
            P.Show();
            this.Close();
        }

        private void Add_Discount_Click(object sender, RoutedEventArgs e)
        {
            addDiscount a = new addDiscount((Book)(sender as FrameworkElement).DataContext);
            a.Show();
        }

        private void Manager_Search_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            foreach (Book b in Collections.books)
            {
                if (b.name.ToLower().Contains(Manager_Search_Books.Text.ToLower()) || b.author.ToLower().Contains(Manager_Search_Books.Text.ToLower()))
                {
                    result.Add(b);
                }
            }
            DataContext = result;
        }

        private void Manager_Search_button_ListOfBooks_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            foreach (Book b in Collections.books)
            {
                if (b.name.ToLower().Contains(Manager_Search_Books_ListOfBooks.Text.ToLower()) || b.author.ToLower().Contains(Manager_Search_Books_ListOfBooks.Text.ToLower()))
                {
                    result.Add(b);
                }
            }
            DataContext = result;
        }

        private void Manager_Search_Users_button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> result = new ObservableCollection<User>();
            foreach (User u in Collections.users)
            {
                if (u.name.ToLower().Contains(Manager_Search_Users.Text.ToLower()) || u.email.ToLower().Contains(Manager_Search_Users.Text.ToLower()))
                {
                    result.Add(u);
                }
            }
            DataContext = result;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                DataContext = Collections.books;
            }
            else if (Add_Book.IsSelected)
            {

            }
            else if (List_Of_Books.IsSelected)
            {
                //DataContext = Collections.currentUser.cart;
                //Collections.currentUser.CartTotalPrice = Methods.calculateTotalPriceOfCart(Collections.currentUser);
                //priceBox.Text = Methods.calculateTotalPriceOfCart(Collections.currentUser).ToString();
                DataContext = Collections.books;
            }
            else if (List_Of_Users.IsSelected)
            {
                DataContext = Collections.users;
            }
            else if (Edit_Profile.IsSelected)
            {
                DataContext = Collections.currentManager;
                name.Text = Collections.currentManager.name;
            }
            else if (VIP_Setting.IsSelected)
            {
                VIPPrice.Text = Collections.vip.PricePerMonth.ToString();
            }
            if (Cash.IsSelected)
            {
                DataContext = Collections.TotalCash;
                TotalCash.Text = Collections.TotalCash.ToString();
            }
        }


        bool checkPhoneNumber(string s)
        {
            //Regex r = new Regex();
            if (!Regex.IsMatch(s, "^[0-9]+$") || s[0] != '0' || s[1] != '9' || s.Length != 11)
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

        private void save_changes_Click(object sender, RoutedEventArgs e)
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
            else
            {
                Collections.currentManager.changeName(name.Text);
                Collections.currentManager.changeLastName(lastName.Text);
                Collections.currentManager.changePhoneNumber(phoneNumber.Text);
            }
        }

        private void save_password_Click(object sender, RoutedEventArgs e)
        {
            if (!Collections.currentManager.checkPassword(CPass.Text))
            {
                MessageBox.Show("wrong Password! please enter again.");
            }
            else if (!checkPassword(NPass.Text))
            {
                MessageBox.Show("new password has wrong format");
            }
            else if (NPass.Text != CNPass.Text)
            {
                MessageBox.Show("new password is not confirmed well.");
            }
            else
            {
                Collections.currentManager.changePassword(NPass.Text);
            }
        }

        private void Change_VIP_Price_btn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;

            int[] ASCIIVIPPrice = new int[VIPPrice.Text.Length];
            for (int i = 0; i < ASCIIVIPPrice.Length; i++)
            {
                ASCIIVIPPrice[i] = (int)VIPPrice.Text.ToCharArray()[i];
            }
            if (VIPPrice.Text.Length == 0)
            {
                MessageBox.Show("Enter a number please!");
            }
            foreach (int i in ASCIIVIPPrice)
            {
                if (i < 48 || i > 57)
                {
                    MessageBox.Show("Price must be a number!");
                    break;
                }
                isValid = true;
            }
            if (isValid)
            {
                Collections.vip.PricePerMonth = float.Parse(VIPPrice.Text);
            }

        }

        private void Withdraw_btn_Click(object sender, RoutedEventArgs e)
        {
            bool ThereIsAProblem = false;

            int[] ASCIIAmountToWithdraw = new int[AmountOfMoneyToWithdraw.Text.Length];
            for (int i = 0; i < ASCIIAmountToWithdraw.Length; i++)
            {
                ASCIIAmountToWithdraw[i] = (int)AmountOfMoneyToWithdraw.Text.ToCharArray()[i];
            }
            if (AmountOfMoneyToWithdraw.Text.Length == 0)
            {
                ThereIsAProblem = true;
                MessageBox.Show("Enter the amount of money to withdraw please!");
            }
            foreach (int i in ASCIIAmountToWithdraw)
            {
                if (i < 48 || i > 57)
                {
                    ThereIsAProblem = true;
                    MessageBox.Show("Price must be a number!");
                    break;
                }
            }
            if (!ThereIsAProblem) //
            {
                if (float.Parse(AmountOfMoneyToWithdraw.Text) < Collections.TotalCash)
                {
                    MessageBox.Show("You cannot withdraw more money than the total!");
                }
                else if (float.Parse(AmountOfMoneyToWithdraw.Text) < 0)
                {
                    MessageBox.Show("Please enter a positive number to withdraw!");
                }
            }


            //int[] ASCIICardNumber1 = new int[CardNumber1.Text.Length];
            //int[] ASCIICardNumber2 = new int[CardNumber2.Text.Length];
            //int[] ASCIICardNumber3 = new int[CardNumber3.Text.Length];
            //int[] ASCIICardNumber4 = new int[CardNumber4.Text.Length];
            //for (int i = 0; i < ASCIICardNumber1.Length; i++)
            //{
            //    ASCIICardNumber1[i] = (int)CardNumber1.Text.ToCharArray()[i];
            //}
            //for (int i = 0; i < ASCIICardNumber2.Length; i++)
            //{
            //    ASCIICardNumber2[i] = (int)CardNumber2.Text.ToCharArray()[i];
            //}
            //for (int i = 0; i < ASCIICardNumber3.Length; i++)
            //{
            //    ASCIICardNumber3[i] = (int)CardNumber3.Text.ToCharArray()[i];
            //}
            //for (int i = 0; i < ASCIICardNumber4.Length; i++)
            //{
            //    ASCIICardNumber4[i] = (int)CardNumber4.Text.ToCharArray()[i];
            //}
            //if (CardNumber1.Text.Length != 4 || CardNumber2.Text.Length != 4 || CardNumber3.Text.Length != 4 || CardNumber4.Text.Length != 4)
            //{
            //    MessageBox.Show("Each part of the card number's length is 4!");
            //    ThereIsAProblem = true;
            //}
            //bool NotNumberErrorShown = false;
            //foreach (int i in ASCIICardNumber1)
            //{
            //    if (i < 48 || i > 57)
            //    {
            //        if (NotNumberErrorShown == false)
            //        {
            //            MessageBox.Show("Each part of the card number includes 4 numbers!");
            //            ThereIsAProblem = true;
            //            NotNumberErrorShown = true;
            //        }
            //        break;
            //    }
            //}

            //bool ThereIsAProblem = false;
            bool CardNumberHasCorrectFormat = true;
            string CardNumber;
            int[] ASCIICardNumber1 = new int[CardNumber1.Text.Length];
            int[] ASCIICardNumber2 = new int[CardNumber2.Text.Length];
            int[] ASCIICardNumber3 = new int[CardNumber3.Text.Length];
            int[] ASCIICardNumber4 = new int[CardNumber4.Text.Length];
            for (int i = 0; i < ASCIICardNumber1.Length; i++)
            {
                ASCIICardNumber1[i] = (int)CardNumber1.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIICardNumber2.Length; i++)
            {
                ASCIICardNumber2[i] = (int)CardNumber2.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIICardNumber3.Length; i++)
            {
                ASCIICardNumber3[i] = (int)CardNumber3.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIICardNumber4.Length; i++)
            {
                ASCIICardNumber4[i] = (int)CardNumber4.Text.ToCharArray()[i];
            }
            if (CardNumber1.Text.Length != 4 || CardNumber2.Text.Length != 4 || CardNumber3.Text.Length != 4 || CardNumber4.Text.Length != 4)
            {
                MessageBox.Show("Each part of the card number's length is 4!");
                CardNumberHasCorrectFormat = false;
                ThereIsAProblem = true;
            }
            bool NotNumberErrorShown = false;
            foreach (int i in ASCIICardNumber1)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Each part of the card number includes 4 numbers!");
                        CardNumberHasCorrectFormat = false;
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }

            foreach (int i in ASCIICardNumber2)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Each part of the card number includes 4 numbers!");
                        CardNumberHasCorrectFormat = false;
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }
            foreach (int i in ASCIICardNumber3)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Each part of the card number includes 4 numbers!");
                        CardNumberHasCorrectFormat = false;
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }
            foreach (int i in ASCIICardNumber4)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Each part of the card number includes 4 numbers!");
                        CardNumberHasCorrectFormat = false;
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }

            static bool checkLuhn(string cardNumber)
            {
                int nDigits = cardNumber.Length;
                int nSummation = 0;

                bool isSecond = false;
                for (int i = nDigits - 1; i >= 0; i--)
                {

                    int b = cardNumber[i] - '0';
                    if (isSecond == true)
                    {
                        b = b * 2;
                    }
                    nSummation += b / 10;
                    nSummation += b % 10;
                    isSecond = !isSecond;
                }
                return (nSummation % 10 == 0);
            }

            if (CardNumberHasCorrectFormat)
            {
                try
                {
                    CardNumber = CardNumber1.Text + CardNumber2.Text + CardNumber3.Text + CardNumber4.Text;
                    if (!checkLuhn(CardNumber))
                    {
                        MessageBox.Show("Card number is not valid according to Luhn algorithm!");
                        ThereIsAProblem = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Card number is in a wrong format!");
                }
            }

            if (!Collections.currentManager.checkPassword(ManagerPassword.Text))
            {
                MessageBox.Show("Manager's password is wrong!");
                ThereIsAProblem = true;
            }

            if (!ThereIsAProblem)
            {
                Collections.TotalCash -= float.Parse(AmountOfMoneyToWithdraw.Text);
                //Anything to do related to bank
                MessageBox.Show("Money was withdrawn successfully!");

            }
        }

        private void Add_Book_btn_Click(object sender, RoutedEventArgs e)
        {
            bool ThereIsAProblem = false;
            int[] ASCIIPrice = new int[Price.Text.Length];
            for (int i = 0; i < ASCIIPrice.Length; i++)
            {
                ASCIIPrice[i] = (int)Price.Text.ToCharArray()[i];
            }
            foreach (int i in ASCIIPrice)
            {
                if (i < 48 || i > 57)
                {
                    MessageBox.Show("Price can only include numbers!");
                    ThereIsAProblem = true;
                    break;
                }
            }
            if (ThereIsAProblem == false)
            {
                try
                {
                    Book NewBook = new Book(NameOfTheBook.Text, AuthorOfTheBook.Text, float.Parse(Price.Text), Publication.Text, AboutTheBook.Text, BookCover.Text, BookCoverFileType.Text, BookPDF.Text, (bool)IsVIP.IsChecked);
                    Collections.books.Add(NewBook);
                }
                catch
                {
                    MessageBox.Show("There is a problem! Book was not added!");
                }
            }
        }

        private void user_profile_Click(object sender, RoutedEventArgs e)
        {
            userInfo u = new userInfo((User)(sender as FrameworkElement).DataContext);
            u.Show();
        }
    }
}
