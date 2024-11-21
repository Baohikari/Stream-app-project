namespace Stream_app_project
{
    partial class Server_Input
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.streamer_name_input = new System.Windows.Forms.TextBox();
            this.stream_title_input = new System.Windows.Forms.TextBox();
            this.started_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "STREAM INFORMATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "STREAMHUB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Please enter your information!!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Streamer name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(267, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stream title:";
            // 
            // streamer_name_input
            // 
            this.streamer_name_input.Location = new System.Drawing.Point(401, 227);
            this.streamer_name_input.Name = "streamer_name_input";
            this.streamer_name_input.Size = new System.Drawing.Size(190, 22);
            this.streamer_name_input.TabIndex = 5;
            // 
            // stream_title_input
            // 
            this.stream_title_input.Location = new System.Drawing.Point(401, 282);
            this.stream_title_input.Name = "stream_title_input";
            this.stream_title_input.Size = new System.Drawing.Size(190, 22);
            this.stream_title_input.TabIndex = 6;
            // 
            // started_btn
            // 
            this.started_btn.Location = new System.Drawing.Point(359, 366);
            this.started_btn.Name = "started_btn";
            this.started_btn.Size = new System.Drawing.Size(162, 51);
            this.started_btn.TabIndex = 7;
            this.started_btn.Text = "Now! Let\'s get started!";
            this.started_btn.UseVisualStyleBackColor = true;
            this.started_btn.Click += new System.EventHandler(this.started_btn_Click);
            // 
            // Server_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 489);
            this.Controls.Add(this.started_btn);
            this.Controls.Add(this.stream_title_input);
            this.Controls.Add(this.streamer_name_input);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Server_Input";
            this.Text = "Server_Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox streamer_name_input;
        private System.Windows.Forms.TextBox stream_title_input;
        private System.Windows.Forms.Button started_btn;
    }
}