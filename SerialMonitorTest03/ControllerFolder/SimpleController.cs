using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SerialMonitorTest03.ControllerFolder
{
    class SimpleController 
    {

        private MainWindow _mainWindow;
        private DataModel _data;
        private USB _usb;
        private Boolean isConnected;

        public SimpleController(MainWindow sender)
        {
            this._data = new DataModel();
            this.isConnected = false;
            this._mainWindow = sender;
            this._usb = new USB(this._mainWindow, this._data);
            //this._mainWindow.imgAttitude.Source =  "GraphicsFolder\img.jpg";
            this.refreshComports();
            
            checkConvention();
        }
                
        private void checkConvention()
        {
            this._mainWindow.btnConnect.IsEnabled = true;
            if (this.isConnected)
            {
                this._mainWindow.lblStatus.Content = this._usb.getPortName() + " online";
                this._mainWindow.btnRefresh.IsEnabled = false;
                this._mainWindow.btnConnect.Content = "Disconnect";

            }
            else
            {
                this._mainWindow.lblStatus.Content = "No ports online";
                this._mainWindow.btnRefresh.IsEnabled = true;
                this._mainWindow.btnConnect.Content = "Connect";

            }

        }
        
        public void refreshComports()
        {
            this._mainWindow.comboPorts.Items.Clear();
            Console.WriteLine("Number of Ports Available: " + _usb.getNumberOfPorts());
            String[] ports =  _usb.getPorts();
            for (int i = 0; i < _usb.getNumberOfPorts(); i++)
            {
                this._mainWindow.comboPorts.Items.Insert(i, ports[i]);
            }

            this._mainWindow.txtBaudRate.Text = "115200";
            this._mainWindow.lblStatus.Content = "No ports online.";
        }
        
        public void connect()
        {
            if (this.isConnected)
            {
                this.isConnected = this._usb.disconnect();
                this._data.finishWriting();

                if (!this.isConnected)
                {
                    this._mainWindow.btnConnect.Content = "Connect";                  
                }
            }
            else
            {
                if (this._mainWindow.comboPorts.Text.Length > 0 && (this._mainWindow.txtBaudRate.Text.Equals("115200") || this._mainWindow.txtBaudRate.Text.Equals("9600") || this._mainWindow.txtBaudRate.Text.Equals("230400")))
                {
                    this.isConnected = _usb.connect();
                    this._data.startWriting();
                    if (this.isConnected)
                    {
                        this._mainWindow.btnConnect.Content = "Disconnect";
                    }
                }
                else
                {
                    MessageBox.Show("Check your port or baud rate.");
                }
            }
            checkConvention();
        }
        

        
      

        public void start()
        {
            this._usb.sendData("M11200");
            this._usb.sendData("M21200");
            this._usb.sendData("M31200");
            this._usb.sendData("M41200");
        }

        public void stop()
        {
            this._usb.sendData("M11100");
            this._usb.sendData("M21100");
            this._usb.sendData("M31100");
            this._usb.sendData("M41100");
        }

        public void sendMsg(string x)
        {
            this._usb.sendData(x);
            this._mainWindow.txtSend.Text = "";

        }

    }
}

