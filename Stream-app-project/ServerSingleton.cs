using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Stream_app_project
{
    public class ServerSingleton
    {
        private static ServerSingleton _instance;
        public static ServerSingleton Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new ServerSingleton();
                }
                return _instance;
            }
        }
        public string StreamerName { get; set; }
        public string StreamTitle { get; set; }
        public string ServerIP {  get; private set; }
        public int ControlPort { get; set; } = 8000;
        public int ImagePort { get; set; } = 9000;
        public int AudioPort { get; set; } = 9001;

        public void SetLocalIPAddress()
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    var ipProperties = networkInterface.GetIPProperties();
                    foreach (var unicastAddress in ipProperties.UnicastAddresses)
                    {
                        if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ServerIP = unicastAddress.Address.ToString(); // Gán giá trị vào thuộc tính
                            return; // Thoát khỏi hàm sau khi tìm thấy địa chỉ IP
                        }
                    }
                }
            }

            throw new Exception("Wi-Fi IPv4 not found!");
        }
    }
}
