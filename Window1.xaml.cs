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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            void StartCloseTimer()
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3d);
                timer.Tick += TimerTick;
                timer.Start();
            }
            void TimerTick(object sender, EventArgs e)
            {
                DispatcherTimer timer = (DispatcherTimer)sender;
                timer.Stop();
                timer.Tick -= TimerTick;
                Close();
            }
            StartCloseTimer();
        }
        
    }
}
