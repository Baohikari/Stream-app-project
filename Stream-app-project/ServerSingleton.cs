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

        private UdpClient controlServer;
        private UdpClient imageServer;
        private UdpClient audioServer;

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

        public void StartUdpServers()
        {
            // Kiểm tra port trước khi khởi chạy
            if (!IsPortAvailable(ControlPort))
                throw new Exception($"Port {ControlPort} is already in use.");
            if (!IsPortAvailable(ImagePort))
                throw new Exception($"Port {ImagePort} is already in use.");
            if (!IsPortAvailable(AudioPort))
                throw new Exception($"Port {AudioPort} is already in use.");

            try
            {
                // Khởi động các server UDP
                controlServer = new UdpClient(ControlPort);
                Console.WriteLine($"Control server started on port {ControlPort}");

                imageServer = new UdpClient(ImagePort);
                Console.WriteLine($"Image server started on port {ImagePort}");

                audioServer = new UdpClient(AudioPort);
                Console.WriteLine($"Audio server started on port {AudioPort}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting UDP servers: {ex.Message}");
                throw;
            }
        }

        private bool IsPortAvailable(int port)
        {
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var udpListeners = ipGlobalProperties.GetActiveUdpListeners();

            return !udpListeners.Any(listener => listener.Port == port);
        }

        private void StartPingResponder(int controlPort)
        {
            Task.Run(() =>
            {
                using (UdpClient udpServer = new UdpClient(controlPort))
                {
                    IPEndPoint remoteEndPoint = null;
                    while (true)
                    {
                        try
                        {
                            byte[] receivedData = udpServer.Receive(ref remoteEndPoint);
                            string receivedMessage = Encoding.UTF8.GetString(receivedData);

                            if (receivedMessage == "ping")
                            {
                                byte[] response = Encoding.UTF8.GetBytes("pong");
                                udpServer.Send(response, response.Length, remoteEndPoint);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ping responder error: {ex.Message}");
                        }
                    }
                }
            });
        }
    }
}
