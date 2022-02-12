using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer updateTimer = new System.Windows.Threading.DispatcherTimer();	//Refresh  timer
        public MainWindow()
        {
            InitializeComponent();
        }

        public override void BeginInit()
        {
            updateTimer.Interval = new TimeSpan(160);
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start();
            base.BeginInit();
            Console.Out.WriteLine("HELLO OPENGL");
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!e.Cancel)
            {
                if (null != updateTimer)
                {
                    updateTimer.Stop();
                    updateTimer = null;
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
           
                ogl.Invalidate();
            //windowsFormsHost1.Child.Invalidate();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        
    }
}

