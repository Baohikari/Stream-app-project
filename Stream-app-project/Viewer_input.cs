using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stream_app_project
{
    public partial class Viewer_input : Form
    {
        public Viewer_input()
        {
            InitializeComponent();
        }

        private void watching_request_Click(object sender, EventArgs e)
        {
            ServerSingleton.Instance.LoadServerIP();
            string viewerName = viewer_name_input.Text;
            string serverIP = ServerSingleton.Instance.ServerIP;
            int imagePort = ServerSingleton.Instance.ImagePort;
            int audioPort = ServerSingleton.Instance.AudioPort;

            Console.WriteLine("Server IP: " + serverIP);
            if (ConnectToServer(serverIP, imagePort, audioPort))
            {
                MessageBox.Show("Kết nối thành công đến server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Viewer_watching viewerStreaming = new Viewer_watching(viewerName, serverIP, imagePort, audioPort);
                viewerStreaming.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không thể kết nối đến server. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ConnectToServer(string serverIP, int imagePort, int audioPort)
        {
            try
            {
                // Use UDP to send a ping message for both video and audio ports
                using (UdpClient udpClient = new UdpClient())
                {
                    udpClient.Client.ReceiveTimeout = 3000;  // Set timeout to 3 seconds

                    Console.WriteLine($"Trying to connect to {serverIP} on ImagePort: {imagePort}");
                    // Try connecting to the image port first
                    if (SendPing(udpClient, serverIP, imagePort))
                    {
                        // If video port responds, try the audio port
                        if (SendPing(udpClient, serverIP, audioPort))
                        {
                            Console.WriteLine("Audio port ping successful.");
                            return true; // Server is reachable on both ports
                        }
                    }
                }

                return false; // Either video or audio port was not reachable
            }
            catch (Exception)
            {
                return false; // If anything goes wrong, assume server is offline
            }
        }

        private bool SendPing(UdpClient udpClient, string serverIP, int port)
        {
            try
            {
                byte[] message = Encoding.UTF8.GetBytes("ping");
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIP), port);

                // Send the ping message to the server
                udpClient.Send(message, message.Length, endPoint);

                // Wait for a response
                IPEndPoint responseEndPoint = null;
                byte[] response = udpClient.Receive(ref responseEndPoint);

                // Check if response is "pong"
                string responseMessage = Encoding.UTF8.GetString(response);
                return responseMessage == "pong";
            }
            catch (Exception)
            {
                return false; // No response means the server is not reachable on this port
            }
        }
    }
}
