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
using System.IO.Ports;
using System.Threading;
using SerialMonitorTest03.ControllerFolder;

namespace SerialMonitorTest03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SimpleController _controller;

        public MainWindow()
        {
            // initializing build in components 
            InitializeComponent(); 
            _controller = new SimpleController(this);
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            _controller.refreshComports();
        }

        private void btnConnect_Clicked(object sender, RoutedEventArgs e)
        {
            _controller.connect();   
        }






        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _controller.stop();
        }

        private void menuAuthor_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Elliot Lee");
        }

        private void btnStartPWM_Click(object sender, RoutedEventArgs e)
        {
            _controller.start();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            _controller.sendMsg(this.txtSend.Text);
        }

        private void comboPorts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtBaudRate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void OnKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                _controller.sendMsg(this.txtSend.Text);
            }
        }

        private void txtSend_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
  


    }
}
        