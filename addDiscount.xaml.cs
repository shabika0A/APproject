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

            bool ThereIsAProblem = false;
            //if (Regex.IsMatch(discountBox.Text, "\\d"))
            //{
            //    //thisBook.discount = float.Parse(discountBox.Text) / 100;

            //    set = true;
            //}
            //else
            //{
            //    MessageBox.Show("please enter number");
            //    ThereIsAProblem = true;
            //}
            //if (set)
            //{
            //    thisBook.discount = float.Parse(discountBox.Text) / 100;
            //    //DateTime DisDead = new DateTime(int.Parse(Discount_Year.Text), int.Parse(Discount_Month.Text), int.Parse(Discount_Day.Text));

            //    //thisBook.discountDeadline = DisDead;
            //    this.Close();
            //}

            if (discountBox.Text == "")
            {
                MessageBox.Show("Please enter a number between 0 to 100!");
                ThereIsAProblem = true;
            }
            //else if (float.Parse(discountBox.Text) < 0 || float.Parse(discountBox.Text) > 100)
            //{
            //    MessageBox.Show("Please enter a number between 0 to 100!");
            //    ThereIsAProblem = true;
            //}
            else
            {
                bool DiscountAmountOnlyHasNumbers = true;
                int[] ASCIIAmount = new int[discountBox.Text.Length];
                for (int i = 0; i < ASCIIAmount.Length; i++)
                {
                    ASCIIAmount[i] = (int)discountBox.Text.ToCharArray()[i];
                }
                foreach (int i in ASCIIAmount)
                {
                    if (i < 48 || i > 57)
                    {
                        MessageBox.Show("Discount amount only includes numbers!");
                        DiscountAmountOnlyHasNumbers = false;
                        ThereIsAProblem = true;
                        break;
                    }
                }
                if (DiscountAmountOnlyHasNumbers)
                {
                    if (float.Parse(discountBox.Text) < 0 || float.Parse(discountBox.Text) > 100)
                    {
                        MessageBox.Show("Please enter a number between 0 to 100!");
                        ThereIsAProblem = true;
                    }
                }
            }
            

            int[] ASCIIYear = new int[Discount_Year.Text.Length];
            int[] ASCIIMonth = new int[Discount_Month.Text.Length];
            int[] ASCIIDay = new int[Discount_Day.Text.Length];
            for (int i = 0; i < ASCIIYear.Length; i++)
            {
                ASCIIYear[i] = (int)Discount_Year.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIIMonth.Length; i++)
            {
                ASCIIMonth[i] = (int)Discount_Month.Text.ToCharArray()[i];
            }
            for (int i = 0; i < ASCIIDay.Length; i++)
            {
                ASCIIDay[i] = (int)Discount_Day.Text.ToCharArray()[i];
            }
            if (Discount_Year.Text.Length != 4 || Discount_Month.Text.Length != 2 || Discount_Day.Text.Length != 2)
            {
                MessageBox.Show("Year's length is 4, month's length is 2, and day's length is 2!");
                ThereIsAProblem = true;
            }
            bool NotNumberErrorShown = false;
            foreach (int i in ASCIIYear)
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

            foreach (int i in ASCIIMonth)
            {
                if (i < 48 || i > 57)
                {
                    //if (NotNumberErrorShown == false)
                    //{
                        MessageBox.Show("Month includes 2 numbers!");
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    //}
                    break;
                }
            }

            foreach (int i in ASCIIDay)
            {
                if (i < 48 || i > 57)
                {
                    //if (NotNumberErrorShown == false)
                    //{
                        MessageBox.Show("Day includes 2 numbers!");
                        ThereIsAProblem = true;
                        NotNumberErrorShown = true;
                    //}
                    break;
                }
            }

            bool DateHasWrongFormat = false;
            if (Discount_Month.Text.Length == 2 && ASCIIMonth[0] >= 48 && ASCIIMonth[0] <= 57 && ASCIIMonth[1] >= 48 && ASCIIMonth[1] <= 57 && Discount_Day.Text.Length == 2 && ASCIIDay[0] >= 48 && ASCIIDay[0] <= 57 && ASCIIDay[1] >= 48 && ASCIIDay[1] <= 57)
            {
                try
                {
                    if (int.Parse(Discount_Month.Text) < 1 || int.Parse(Discount_Month.Text) > 12)
                    {
                        MessageBox.Show("Month is a number between 01 to 12!");
                        ThereIsAProblem = true;
                        DateHasWrongFormat = true;
                    }
                    else
                    {
                        if (int.Parse(Discount_Month.Text) == 1)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in January is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 2)
                        {
                            if (DateTime.IsLeapYear(int.Parse(Discount_Year.Text)))
                            {
                                if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 29)
                                {
                                    MessageBox.Show("Day in February in a leap year is a number between 01 to 29!");
                                    ThereIsAProblem = true;
                                    DateHasWrongFormat = true;
                                }
                            }
                            else
                            {
                                if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 28)
                                {
                                    MessageBox.Show("Day in February is a number between 01 to 28!");
                                    ThereIsAProblem = true;
                                    DateHasWrongFormat = true;
                                }
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 3)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in March is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 4)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 30)
                            {
                                MessageBox.Show("Day in April is a number between 01 to 30!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 5)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in May is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 6)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 30)
                            {
                                MessageBox.Show("Day in June is a number between 01 to 30!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 7)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in July is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 8)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in August is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 9)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 30)
                            {
                                MessageBox.Show("Day in September is a number between 01 to 30!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 10)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in October is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 11)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 30)
                            {
                                MessageBox.Show("Day in November is a number between 01 to 30!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }

                        else if (int.Parse(Discount_Month.Text) == 12)
                        {
                            if (int.Parse(Discount_Day.Text) < 1 || int.Parse(Discount_Day.Text) > 31)
                            {
                                MessageBox.Show("Day in December is a number between 01 to 31!");
                                ThereIsAProblem = true;
                                DateHasWrongFormat = true;
                            }
                        }   
                    }
                }
                catch
                {
                    MessageBox.Show("Date is in a wrong format!");
                }
                if (!DateHasWrongFormat)
                {
                    DateTime Expire = new DateTime(int.Parse(Discount_Year.Text), int.Parse(Discount_Month.Text), int.Parse(Discount_Day.Text));
                    DateTime NowTime = DateTime.Now;
                    if (DateTime.Compare(Expire, NowTime) <= 0)
                    {
                        MessageBox.Show("Cannot set a day which is earlier than/is today!");
                        ThereIsAProblem = true;
                    }
                }
            }
            if (!ThereIsAProblem)
            {
                thisBook.discount = float.Parse(discountBox.Text) / 100;
                DateTime Expire = new DateTime(int.Parse(Discount_Year.Text), int.Parse(Discount_Month.Text), int.Parse(Discount_Day.Text));
                thisBook.discountDeadline = Expire;
                this.Close();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
