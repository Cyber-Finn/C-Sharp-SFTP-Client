namespace C_Sharp_SFTP_Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtboxPassword = new TextBox();
            txtboxUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label8 = new Label();
            txtboxRemoteHost = new TextBox();
            lblConnStatus = new Label();
            btnUploadFiles = new Button();
            btnDownloadFiles = new Button();
            label1 = new Label();
            txtPort = new TextBox();
            txtPrivatekeyLocation = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtboxPassword
            // 
            txtboxPassword.Location = new Point(187, 78);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.PasswordChar = '*';
            txtboxPassword.Size = new Size(269, 31);
            txtboxPassword.TabIndex = 11;
            // 
            // txtboxUsername
            // 
            txtboxUsername.Location = new Point(187, 24);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.Size = new Size(269, 31);
            txtboxUsername.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(90, 78);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 24);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 8;
            label4.Text = "Username:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(64, 139);
            label8.Name = "label8";
            label8.Size = new Size(117, 25);
            label8.TabIndex = 12;
            label8.Text = "Remote host:";
            // 
            // txtboxRemoteHost
            // 
            txtboxRemoteHost.Location = new Point(187, 139);
            txtboxRemoteHost.Name = "txtboxRemoteHost";
            txtboxRemoteHost.Size = new Size(269, 31);
            txtboxRemoteHost.TabIndex = 13;
            
            // 
            // lblConnStatus
            // 
            lblConnStatus.AutoSize = true;
            lblConnStatus.Location = new Point(482, 78);
            lblConnStatus.Name = "lblConnStatus";
            lblConnStatus.Size = new Size(0, 25);
            lblConnStatus.TabIndex = 15;
            // 
            // btnUploadFiles
            // 
            btnUploadFiles.Location = new Point(55, 327);
            btnUploadFiles.Name = "btnUploadFiles";
            btnUploadFiles.Size = new Size(194, 54);
            btnUploadFiles.TabIndex = 16;
            btnUploadFiles.Text = "Upload Files";
            btnUploadFiles.UseVisualStyleBackColor = true;
            btnUploadFiles.Click += btnUploadFiles_Click;
            // 
            // btnDownloadFiles
            // 
            btnDownloadFiles.Location = new Point(377, 327);
            btnDownloadFiles.Name = "btnDownloadFiles";
            btnDownloadFiles.Size = new Size(194, 54);
            btnDownloadFiles.TabIndex = 17;
            btnDownloadFiles.Text = "Download Files";
            btnDownloadFiles.UseVisualStyleBackColor = true;
            btnDownloadFiles.Click += btnDownloadFiles_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 250);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 18;
            label1.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(187, 250);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(119, 31);
            txtPort.TabIndex = 19;
            txtPort.Text = "22";
            // 
            // txtPrivatekeyLocation
            // 
            txtPrivatekeyLocation.Location = new Point(187, 195);
            txtPrivatekeyLocation.Name = "txtPrivatekeyLocation";
            txtPrivatekeyLocation.Size = new Size(405, 31);
            txtPrivatekeyLocation.TabIndex = 21;
            txtPrivatekeyLocation.Text = "Leave blank if none";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 195);
            label6.Name = "label6";
            label6.Size = new Size(174, 25);
            label6.TabIndex = 20;
            label6.Text = "Private Key Location:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(627, 403);
            Controls.Add(txtPrivatekeyLocation);
            Controls.Add(label6);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Controls.Add(btnDownloadFiles);
            Controls.Add(btnUploadFiles);
            Controls.Add(lblConnStatus);
            Controls.Add(txtboxRemoteHost);
            Controls.Add(label8);
            Controls.Add(txtboxPassword);
            Controls.Add(txtboxUsername);
            Controls.Add(label5);
            Controls.Add(label4);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "CyberFinn Simple SFTP client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtboxPassword;
        private TextBox txtboxUsername;
        private Label label5;
        private Label label4;
        private Label label8;
        private TextBox txtboxRemoteHost;
        private Label lblConnStatus;
        private Button btnUploadFiles;
        private Button btnDownloadFiles;
        private Label label1;
        private TextBox txtPort;
        private TextBox txtPrivatekeyLocation;
        private Label label6;
    }
}