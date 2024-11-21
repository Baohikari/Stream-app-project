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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void server_request_Click(object sender, EventArgs e)
        {
            Server_Input svInput = new Server_Input();
            svInput.Show();
            this.Hide();
        }

        private void client_request_Click(object sender, EventArgs e)
        {
            Viewer_input vInput = new Viewer_input();
            vInput.Show(); 
            this.Hide();
        }
    }
}
