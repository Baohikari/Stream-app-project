using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stream_app_project
{
    public partial class Viewer_watching : Form
    {
        private string viewerName;
        private string serverIP;
        private int imagePort;
        private int audioPort;

        private UdpClient videoClient;
        private UdpClient audioClient;
        private IPEndPoint videoEndPoint;
        private IPEndPoint audioEndPoint;
        private WaveOutEvent waveOut;
        private BufferedWaveProvider waveProvider;
        public Viewer_watching(string viewerName, string serverIP, int imagePort, int audioPort)
        {
            this.viewerName = viewerName;
            this.serverIP = serverIP;
            this.imagePort = imagePort;
            this.audioPort = audioPort;
            Console.WriteLine("Server IP in Viewer_watching: " + serverIP);

            InitializeComponent();
        }
        private void StreamViewer_Load(object sender, EventArgs e)
        {
            try
            {
                // Set up video and audio UDP clients
                videoClient = new UdpClient(imagePort);
                audioClient = new UdpClient(audioPort);

                // Set up endpoints for video and audio
                videoEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), imagePort);
                audioEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), audioPort);

                // Start receiving video and audio in separate tasks
                Task.Run(() => ReceiveVideoStream());
                Task.Run(() => ReceiveAudioStream());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới server: " + ex.Message);
            }
        }

        private void ReceiveVideoStream()
        {
            try
            {
                byte[] buffer = new byte[65507];
                MemoryStream ms = new MemoryStream();

                while (true)
                {
                    //Receive data
                    byte[] data = videoClient.Receive(ref videoEndPoint);
                    ms.Write(data, 0, data.Length);

                    if(ms.Length > 0)
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        Bitmap bitmap = new Bitmap(ms);

                        // Update the UI to show the image
                        Invoke(new Action(() =>
                        {
                            watching_screen.Image = bitmap;
                        }));

                        ms.SetLength(0); // Reset the memory stream for the next frame
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving video: {ex.Message}");
            }
        }

        private void ReceiveAudioStream()
        {
            try
            {
                byte[] buffer = new byte[1024]; // Buffer size for audio data
                waveProvider = new BufferedWaveProvider(new WaveFormat(44100, 1)); // 44.1 kHz, Mono
                waveOut = new WaveOutEvent();
                waveOut.Init(waveProvider);
                waveOut.Play();

                while (true)
                {
                    // Receive audio data from server
                    byte[] data = audioClient.Receive(ref audioEndPoint);

                    // Add the audio data to the wave provider
                    waveProvider.AddSamples(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving audio: {ex.Message}");
            }
        }
        private void watch_now_Click(object sender, EventArgs e)
        {
            ReceiveVideoStream();
            ReceiveAudioStream();
        }
    }
}
