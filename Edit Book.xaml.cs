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
    /// Interaction logic for Edit_Book.xaml
    /// </summary>
    public partial class Edit_Book : Window
    {
        Book Book_Edit;
        public Edit_Book(Book BookToEdit)
        {
            DataContext = BookToEdit;
            InitializeComponent();
            if (BookToEdit.IsVIP)
            {
                IsVIP.IsChecked = true;
            }
            Book_Edit = BookToEdit;        
        }

        private void Edit_Book_btn_Click(object sender, RoutedEventArgs e)
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
                    //Book NewBook = new Book(NameOfTheBook.Text, AuthorOfTheBook.Text, float.Parse(Price.Text), Publication.Text, AboutTheBook.Text, BookCover.Text, BookCoverFileType.Text, BookPDF.Text, (bool)IsVIP.IsChecked);
                    //Collections.books.Add(NewBook);
                    if (Book_Edit.name != NameOfTheBook.Text)
                    {
                        Book_Edit.name = NameOfTheBook.Text;
                    }

                    if (Book_Edit.author != AuthorOfTheBook.Text)
                    {
                        Book_Edit.author = AuthorOfTheBook.Text;
                    }

                    if (Book_Edit.publisher != Publication.Text)
                    {
                        Book_Edit.publisher = Publication.Text;
                    }

                    if (Book_Edit.summery != AboutTheBook.Text)
                    {
                        Book_Edit.summery = AboutTheBook.Text;
                    }

                    if (Book_Edit.price != float.Parse(Price.Text))
                    {
                        Book_Edit.price = float.Parse(Price.Text);
                    }

                    if (Book_Edit.CoverPictureName != BookCover.Text)
                    {
                        Book_Edit.CoverPictureName = BookCover.Text;
                    }

                    if (Book_Edit.CoverPictureType != BookCoverFileType.Text)
                    {
                        Book_Edit.CoverPictureType = BookCoverFileType.Text;
                    }

                    if (Book_Edit.PDFName != BookPDF.Text)
                    {
                        Book_Edit.PDFName = BookPDF.Text;
                    }

                    if (Book_Edit.IsVIP != IsVIP.IsChecked)
                    {
                        Book_Edit.IsVIP = (bool)IsVIP.IsChecked;
                    }

                }
                catch
                {
                    MessageBox.Show("There is a problem! Book was not added!");
                }
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
