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
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PDF.xaml
    /// </summary>
    public partial class PDF : Window
    {
        public Book HereBook;
        bool IsPreview;
        public PDF(Book ThisBook, bool IsPreview)
        {
            InitializeComponent();
            //HereBook = ThisBook;
            //pdfWebViewer.Navigate(new Uri("about:blank"));
            ////string filename = @"Little+Prince sample.pdf";
            ////string filePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length-24) + filename;
            ////pdfWebViewer.Navigate(filePath);
            //pdfWebViewer.Navigate(ThisBook.PDFAddress);
            HereBook = ThisBook;
            this.IsPreview = IsPreview;
            /*
            string sFilename = ThisBook.PDFAddress;
            PdfReader pdf_Reader = new PdfReader(sFilename);
            string sText = "";
            //ScrollV.Height = pdf_Reader.NumberOfPages * 50;
            //lblPDF_Output.Height = pdf_Reader.NumberOfPages * 100;
            //var LineCount = File.ReadLines(ThisBook.PDFAddress).Count();
            int LineCount = File.ReadAllLines(ThisBook.PDFAddress).Length;
            lblPDF_Output.Height = LineCount * 0.6;
            for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
            {
                sText += PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
            }
            lblPDF_Output.Text = sText;
            */
            if (IsPreview)
            {
                string sFilename = ThisBook.PDFAddress;
                PdfReader pdf_Reader = new PdfReader(sFilename);
                string sText = "";
                //ScrollV.Height = pdf_Reader.NumberOfPages * 50;
                //lblPDF_Output.Height = pdf_Reader.NumberOfPages * 100;
                //var LineCount = File.ReadLines(ThisBook.PDFAddress).Count();
                int LineCount = File.ReadAllLines(ThisBook.PDFAddress).Length;
                lblPDF_Output.Height = LineCount * 0.3;
                for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
                {
                    sText += PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
                }
                lblPDF_Output.Text = sText;
            }
            else
            {
                string sFilename = ThisBook.PDFAddress;
                PdfReader pdf_Reader = new PdfReader(sFilename);
                string sText = "";
                //ScrollV.Height = pdf_Reader.NumberOfPages * 50;
                //lblPDF_Output.Height = pdf_Reader.NumberOfPages * 100;
                //var LineCount = File.ReadLines(ThisBook.PDFAddress).Count();
                int LineCount = File.ReadAllLines(ThisBook.PDFAddress).Length;
                lblPDF_Output.Height = LineCount * 0.6;
                for (int i = 1; i <= pdf_Reader.NumberOfPages; i++)
                {
                    sText += PdfTextExtractor.GetTextFromPage(pdf_Reader, i);
                }
                lblPDF_Output.Text = sText;
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (IsPreview)
            {
                Book bb = HereBook;
                a_book bWindow = new a_book(bb);
                bWindow.Show();
            }
            else
            {
                if (Collections.managerSignedIn)
                {
                    Manager_Dashboard m = new Manager_Dashboard();
                    m.Show();
                    this.Close();
                }
                else
                {
                    user_dashboard m = new user_dashboard();
                    m.Show();
                    this.Close();
                }
            }
            this.Close();
        }
    }
}
