using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stream_app_project
{
    public partial class Server_Input : Form
    {
        public Server_Input()
        {
            InitializeComponent();
        }

        private void started_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string serverName = streamer_name_input.Text.Trim();
                string streamTitle = stream_title_input.Text.Trim();
                if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(streamTitle))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên server và Tiêu đề stream.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lưu thông tin vào Singleton
                ServerSingleton.Instance.SetLocalIPAddress();
                ServerSingleton.Instance.StreamerName = serverName;
                ServerSingleton.Instance.StreamTitle = streamTitle;

                // Thông báo thông tin đã lưu
                MessageBox.Show($"Server Name: {serverName}\n" +
                                $"Stream Title: {streamTitle}\n" +
                                $"Server IP: {ServerSingleton.Instance.ServerIP}\n" +
                                $"Image Port: {ServerSingleton.Instance.ImagePort}\n" +
                                $"Audio Port: {ServerSingleton.Instance.AudioPort}\n" +
                                $"Control Port: {ServerSingleton.Instance.ControlPort}",
                                "Thông tin Server");

                // Chuyển sang form Server_Streaming
                Server_Streaming serverStreaming = new Server_Streaming();
                serverStreaming.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
        }
    }
}
