namespace Stream_app_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.server_request = new System.Windows.Forms.Button();
            this.client_request = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME TO STREAMHUB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose who are you!!";
            // 
            // server_request
            // 
            this.server_request.Location = new System.Drawing.Point(301, 214);
            this.server_request.Name = "server_request";
            this.server_request.Size = new System.Drawing.Size(128, 45);
            this.server_request.TabIndex = 2;
            this.server_request.Text = "SERVER";
            this.server_request.UseVisualStyleBackColor = true;
            this.server_request.Click += new System.EventHandler(this.server_request_Click);
            // 
            // client_request
            // 
            this.client_request.Location = new System.Drawing.Point(562, 214);
            this.client_request.Name = "client_request";
            this.client_request.Size = new System.Drawing.Size(129, 45);
            this.client_request.TabIndex = 3;
            this.client_request.Text = "CLIENT";
            this.client_request.UseVisualStyleBackColor = true;
            this.client_request.Click += new System.EventHandler(this.client_request_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(298, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 74);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stream for everyone, everyone\'ll be able to watch you";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(559, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 73);
            this.label4.TabIndex = 5;
            this.label4.Text = "You\'ll be able to watch server stream";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 510);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.client_request);
            this.Controls.Add(this.server_request);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button server_request;
        private System.Windows.Forms.Button client_request;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

