using System;
using System.Collections.Generic;
using System.IO;
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
            //Thêm kiểm tra để đảm bảo phương thức thực thi chính xác
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Checking network interfaces...");

            foreach (var networkInterface in networkInterfaces)
            {
                Console.WriteLine($"Checking interface: {networkInterface.Name}");

                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    Console.WriteLine($"Found active wireless interface: {networkInterface.Name}");

                    var ipProperties = networkInterface.GetIPProperties();
                    foreach (var unicastAddress in ipProperties.UnicastAddresses)
                    {
                        // Kiểm tra xem địa chỉ này có phải là IPv4 không
                        if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ServerIP = unicastAddress.Address.ToString();
                            Console.WriteLine($"Server IP found: {ServerIP}");
                            return; // Thoát ra sau khi tìm được IP
                        }
                    }
                }
            }

            // Nếu không tìm thấy địa chỉ IP phù hợp
            Console.WriteLine("No suitable IP address found.");
            throw new Exception("Wi-Fi IPv4 not found!");

        }

        public void SaveServerIP(string filePath = "server_ip.txt")
        {
            try
            {
                if (string.IsNullOrEmpty(ServerIP))
                {
                    throw new Exception("Server IP is not set.");
                }

                File.WriteAllText(filePath, ServerIP);
                Console.WriteLine($"Server IP saved to file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving server IP: {ex.Message}");
            }
        }

        public void LoadServerIP(string filePath = "server_ip.txt")
        {
            try
            {
                if (File.Exists(filePath))
                {
                    ServerIP = File.ReadAllText(filePath).Trim();
                    Console.WriteLine($"Server IP loaded from file: {ServerIP}");
                }
                else
                {
                    throw new FileNotFoundException($"Server IP file not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading server IP: {ex.Message}");
            }
        }

        public void StartUdpServers()
        {
            SetLocalIPAddress();  // Gọi phương thức SetLocalIPAddress
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
                StartPingResponder(ControlPort);
                StartPingResponderForImageAndAudio();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting UDP servers: {ex.Message}");
                throw;
            }
        }

        public void StartServer()
        {
            try
            {
                // Thiết lập địa chỉ IP của server
                SetLocalIPAddress();

                // Lưu địa chỉ IP vào file để viewer có thể đọc
                SaveServerIP();

                // Khởi động các server UDP
                StartUdpServers();

                Console.WriteLine("Server started successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
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
                IPEndPoint remoteEndPoint = null;
                while (true)
                {
                    try
                    {
                        byte[] receivedData = controlServer.Receive(ref remoteEndPoint);
                        string receivedMessage = Encoding.UTF8.GetString(receivedData);

                        if (receivedMessage == "ping")
                        {
                            byte[] response = Encoding.UTF8.GetBytes("pong");
                            controlServer.Send(response, response.Length, remoteEndPoint);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ping responder error: {ex.Message}");
                    }
                }
            });
        }
        private void StartPingResponderForImageAndAudio()
        {
            Task.Run(() =>
            {
                StartResponder(imageServer, ImagePort);
            });

            Task.Run(() =>
            {
                StartResponder(audioServer, AudioPort);
            });
        }
        private void StartResponder(UdpClient server, int port)
        {
            IPEndPoint remoteEndPoint = null;
            while (true)
            {
                try
                {
                    byte[] receivedData = server.Receive(ref remoteEndPoint);
                    string receivedMessage = Encoding.UTF8.GetString(receivedData);

                    if (receivedMessage == "ping")
                    {
                        byte[] response = Encoding.UTF8.GetBytes("pong");
                        server.Send(response, response.Length, remoteEndPoint);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error on port {port}: {ex.Message}");
                }
            }
        }
    }
}
