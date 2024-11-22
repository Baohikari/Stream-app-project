namespace Stream_app_project
{
    partial class Viewer_watching
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
            this.watching_screen = new System.Windows.Forms.PictureBox();
            this.commentBox = new System.Windows.Forms.ListBox();
            this.lblTitle_client = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName_client = new System.Windows.Forms.Label();
            this.watch_now = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblViewerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.watching_screen)).BeginInit();
            this.SuspendLayout();
            // 
            // watching_screen
            // 
            this.watching_screen.Location = new System.Drawing.Point(12, 12);
            this.watching_screen.Name = "watching_screen";
            this.watching_screen.Size = new System.Drawing.Size(646, 308);
            this.watching_screen.TabIndex = 0;
            this.watching_screen.TabStop = false;
            // 
            // commentBox
            // 
            this.commentBox.FormattingEnabled = true;
            this.commentBox.ItemHeight = 16;
            this.commentBox.Location = new System.Drawing.Point(673, 12);
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(259, 308);
            this.commentBox.TabIndex = 1;
            // 
            // lblTitle_client
            // 
            this.lblTitle_client.AutoSize = true;
            this.lblTitle_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_client.Location = new System.Drawing.Point(12, 335);
            this.lblTitle_client.Name = "lblTitle_client";
            this.lblTitle_client.Size = new System.Drawing.Size(77, 18);
            this.lblTitle_client.TabIndex = 2;
            this.lblTitle_client.Text = "This is title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "This stream\'s of";
            // 
            // lblName_client
            // 
            this.lblName_client.AutoSize = true;
            this.lblName_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName_client.Location = new System.Drawing.Point(119, 461);
            this.lblName_client.Name = "lblName_client";
            this.lblName_client.Size = new System.Drawing.Size(73, 18);
            this.lblName_client.TabIndex = 4;
            this.lblName_client.Text = "Bảo Bảo";
            // 
            // watch_now
            // 
            this.watch_now.Location = new System.Drawing.Point(369, 440);
            this.watch_now.Name = "watch_now";
            this.watch_now.Size = new System.Drawing.Size(126, 37);
            this.watch_now.TabIndex = 5;
            this.watch_now.Text = "Watch now!!";
            this.watch_now.UseVisualStyleBackColor = true;
            this.watch_now.Click += new System.EventHandler(this.watch_now_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(813, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Out this stream!";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(673, 331);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 22);
            this.textBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(750, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Comment now!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Your name is";
            // 
            // lblViewerName
            // 
            this.lblViewerName.AutoSize = true;
            this.lblViewerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewerName.Location = new System.Drawing.Point(94, 440);
            this.lblViewerName.Name = "lblViewerName";
            this.lblViewerName.Size = new System.Drawing.Size(52, 18);
            this.lblViewerName.TabIndex = 11;
            this.lblViewerName.Text = "label3";
            // 
            // Viewer_watching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 486);
            this.Controls.Add(this.lblViewerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.watch_now);
            this.Controls.Add(this.lblName_client);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle_client);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.watching_screen);
            this.Name = "Viewer_watching";
            this.Text = "Viewer_watching";
            ((System.ComponentModel.ISupportInitialize)(this.watching_screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox watching_screen;
        private System.Windows.Forms.ListBox commentBox;
        private System.Windows.Forms.Label lblTitle_client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName_client;
        private System.Windows.Forms.Button watch_now;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblViewerName;
    }
}