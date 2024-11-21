using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;

namespace Stream_app_project
{
    public partial class Server_Streaming : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WaveInEvent waveIn;
        private UdpClient videoClient;
        private UdpClient audioClient;
        public Server_Streaming()
        {
            InitializeComponent();

            lblName.Text = ServerSingleton.Instance.StreamerName;
            lblTitle.Text = ServerSingleton.Instance.StreamTitle;
        }

        private void StartVideoStreaming()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(videoDevices.Count == 0)
            {
                MessageBox.Show("No camera found");
                return;
            }
            // Sử dụng camera đầu tiên
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(SendVideoFrame);
            videoSource.Start();

            // Khởi tạo UDP client để gửi video
            videoClient = new UdpClient();
            MessageBox.Show("Start transmitting video....");
        }

        private void SendVideoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // Clone ảnh từ camera để tránh việc ảnh bị hỏng
                using (Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    // Hiển thị khung hình lên PictureBox
                    if (streaming_screen.InvokeRequired)
                    {
                        // Nếu đang ở thread khác, dùng Invoke để gọi từ thread chính
                        streaming_screen.Invoke(new Action(() =>
                        {
                            streaming_screen.Image = (Bitmap)bitmap.Clone();
                        }));
                    }
                    else
                    {
                        // Nếu đang ở thread chính, cập nhật trực tiếp
                        streaming_screen.Image = (Bitmap)bitmap.Clone();
                    }

                    // Nén hình ảnh thành JPEG và gửi qua UDP
                    using (var ms = new System.IO.MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] buffer = ms.ToArray();

                        // Split the buffer if it exceeds the UDP packet size limit (65507 bytes)
                        int maxPacketSize = 65507;  // Maximum UDP packet size
                        if (buffer.Length > maxPacketSize)
                        {
                            int packetCount = (int)Math.Ceiling((double)buffer.Length / maxPacketSize);
                            for (int i = 0; i < packetCount; i++)
                            {
                                int startIndex = i * maxPacketSize;
                                int packetSize = Math.Min(maxPacketSize, buffer.Length - startIndex);
                                byte[] packet = new byte[packetSize];
                                Array.Copy(buffer, startIndex, packet, 0, packetSize);

                                // Send each smaller packet
                                videoClient.Send(packet, packet.Length, new System.Net.IPEndPoint(
                                    System.Net.IPAddress.Parse(ServerSingleton.Instance.ServerIP), ServerSingleton.Instance.ImagePort));
                            }
                        }
                        else
                        {
                            // Send the entire buffer if it fits within the UDP packet size limit
                            videoClient.Send(buffer, buffer.Length, new System.Net.IPEndPoint(
                                System.Net.IPAddress.Parse(ServerSingleton.Instance.ServerIP), ServerSingleton.Instance.ImagePort));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when transmitting video: {ex.Message}");
            }
        }

        private void StartAudioStreaming()
        {
            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1) // 44.1kHz, 1 kênh (Mono)
            };
            waveIn.DataAvailable += SendAudioFrame;

            // Khởi tạo UDP client để gửi âm thanh
            audioClient = new UdpClient();

            waveIn.StartRecording();
            MessageBox.Show("Start transmitting audio...");
        }

        private void SendAudioFrame(object sender, WaveInEventArgs e)
        {
            try
            {
                int maxPacketSize = 65507;  // Maximum UDP packet size

                // Check if audio data is too large and split it into smaller packets
                if (e.Buffer.Length > maxPacketSize)
                {
                    int packetCount = (int)Math.Ceiling((double)e.Buffer.Length / maxPacketSize);
                    for (int i = 0; i < packetCount; i++)
                    {
                        int startIndex = i * maxPacketSize;
                        int packetSize = Math.Min(maxPacketSize, e.Buffer.Length - startIndex);
                        byte[] packet = new byte[packetSize];
                        Array.Copy(e.Buffer, startIndex, packet, 0, packetSize);

                        // Send the smaller audio packet
                        audioClient.Send(packet, packet.Length, new System.Net.IPEndPoint(
                            System.Net.IPAddress.Parse(ServerSingleton.Instance.ServerIP), ServerSingleton.Instance.AudioPort));
                    }
                }
                else
                {
                    // Send the audio buffer directly if it fits within the UDP packet size limit
                    audioClient.Send(e.Buffer, e.Buffer.Length, new System.Net.IPEndPoint(
                        System.Net.IPAddress.Parse(ServerSingleton.Instance.ServerIP), ServerSingleton.Instance.AudioPort));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when transmitting audio: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Bắt đầu truyền video
                StartVideoStreaming();

                // Bắt đầu truyền âm thanh
                StartAudioStreaming();

                MessageBox.Show("Đã bắt đầu truyền streaming!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động streaming: {ex.Message}");
            }
        }
    }
}
