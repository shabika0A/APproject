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
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Window
    {
        User ThisUser;
        float ThisPrice = 0;
        public PaymentPage(User U, float price)
        {
            //Price can be cart price or VIP price; This page is used for both payments
            //DataContext = price;////must be changed! after having banking account
            ThisUser = U;
            InitializeComponent();
            priceBox.Text = price.ToString();
            this.ThisPrice = price;
        }

        

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            bool ThereIsAProblem = false;
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

            int[] ASCIICVV2 = new int[CVV2.Text.Length];
            for (int i = 0; i < ASCIICVV2.Length; i++)
            {
                ASCIICVV2[i] = (int)CVV2.Text.ToCharArray()[i];
            }
            if (CVV2.Text.Length != 3 && CVV2.Text.Length != 4)
            {
                MessageBox.Show("CVV2 length must be 3 or 4!");
                ThereIsAProblem = true;
            }
            foreach (int i in ASCIICVV2)
            {
                if (i < 48 || i > 57)
                {
                    MessageBox.Show("CVV2 must be 3 or 4 numbers!");
                    ThereIsAProblem = true;
                    break;
                }
            }


            int[] ASCIIExpireDate1 = new int[ExpireDate1.Text.Length];
            int[] ASCIIExpireDate2 = new int[ExpireDate2.Text.Length];
            for (int i = 0; i < ASCIIExpireDate1.Length; i++)
            {
                ASCIIExpireDate1[i] = (int)ExpireDate1.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIIExpireDate2.Length; i++)
            {
                ASCIIExpireDate2[i] = (int)ExpireDate2.Text.ToCharArray()[i];
            }
            if (ExpireDate1.Text.Length != 4 || ExpireDate2.Text.Length != 2)
            {
                MessageBox.Show("Year's length is 4 and month's length is 2!");
                ThereIsAProblem = true;
            }
            NotNumberErrorShown = false;
            foreach (int i in ASCIIExpireDate1)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Year includes 4 numbers!");
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }

            foreach (int i in ASCIIExpireDate2)
            {
                if (i < 48 || i > 57)
                {
                    if (NotNumberErrorShown == false)
                    {
                        MessageBox.Show("Month includes 2 numbers!");
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    }
                    break;
                }
            }

            if (ExpireDate2.Text.Length == 2 && ASCIIExpireDate2[0] >= 48 && ASCIIExpireDate2[0] <= 57 && ASCIIExpireDate2[1] >= 48 && ASCIIExpireDate2[1] <= 57)
            {
                if (int.Parse(ExpireDate2.Text) < 1 || int.Parse(ExpireDate2.Text) > 12)
                {
                    MessageBox.Show("Month is a number between 01 to 12!");
                    ThereIsAProblem = true;
                }
                else
                {
                    DateTime Expire = new DateTime(int.Parse(ExpireDate1.Text), int.Parse(ExpireDate2.Text), 30);
                    DateTime NowTime = DateTime.Now;
                    if (DateTime.Compare(Expire, NowTime) < 0)
                    {
                        MessageBox.Show("This card has expired!");
                        ThereIsAProblem = true;
                    }
                }
            }


            int[] ASCIIPassword = new int[Password.Text.Length];
            for (int i = 0; i < ASCIIPassword.Length; i++)
            {
                ASCIIPassword[i] = (int)Password.Text.ToCharArray()[i];
            }
            if (Password.Text.Length != 6)
            {
                MessageBox.Show("Password length must be 6!");
                ThereIsAProblem = true;
            }
            foreach (int i in ASCIIPassword)
            {
                if (i < 48 || i > 57)
                {
                    MessageBox.Show("Password must be 6 numbers!");
                    ThereIsAProblem = true;
                    break;
                }
            }
            if (ThereIsAProblem == false)
            {
                //Check card info -> if OK...
                MessageBox.Show("Paid Successfully!");
                Methods.AddBooksToUserFromCart(ThisUser);
                Collections.TotalCash += ThisPrice;
                //add books to user's books list
                this.Close();
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            //user_dashboard u = new user_dashboard();
            //u.Show();
            this.Close();
        }
    }
}
