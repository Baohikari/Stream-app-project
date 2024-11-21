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
            string viewerName = viewer_name_input.Text;

            string serverIP = ServerSingleton.Instance.ServerIP;
            int imagePort = ServerSingleton.Instance.ImagePort;
            int audioPort = ServerSingleton.Instance.AudioPort;

            if(ConnectToServer(serverIP, imagePort, audioPort))
            {

            }
            else
            {
                MessageBox.Show("Server is not online");
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

                    // Try connecting to the image port first
                    if (SendPing(udpClient, serverIP, imagePort))
                    {
                        // If video port responds, try the audio port
                        if (SendPing(udpClient, serverIP, audioPort))
                        {
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

                // Wait for a response (a small timeout ensures it doesn't hang if server doesn't reply)
                byte[] response = udpClient.Receive(ref endPoint);

                // If we receive a response, the server is online for that port
                return response.Length > 0;
            }
            catch (Exception)
            {
                return false; // No response means the server is not reachable on this port
            }
        }
    }
}
