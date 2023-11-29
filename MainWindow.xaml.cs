using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace dispatcher
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Process[] processes = Process.GetProcesses().OrderBy(process => process.ProcessName).ToArray();
            DataContext = processes;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += refreshDispatcher;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();

        }

        private void Button_Click_Kill(object sender, RoutedEventArgs e)
        {
            Process selected = (Process)list.SelectedItem;
            selected.Kill();
            //MessageBox.Show("xaxnax");
            //selected.WaitForExit();


        }

        public void refreshDispatcher(object sender, EventArgs e)
        {
            list.Items.Refresh();
            //MessageBox.Show("xaxnax");
        }
    }
}
