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
            btnUploadFile = new Button();
            txtResult = new RichTextBox();
            label1 = new Label();
            tabControlUI = new TabControl();
            tabPageUpload = new TabPage();
            btnOpenFileDialog = new Button();
            txtboxRemoteFolder = new TextBox();
            txtboxSourceFile = new TextBox();
            label3 = new Label();
            label2 = new Label();
            tabPageDownload = new TabPage();
            button1 = new Button();
            btnDownloadFile = new Button();
            txtboxLocalDestination = new TextBox();
            label7 = new Label();
            txtboxRemoteSource = new TextBox();
            label6 = new Label();
            txtboxPassword = new TextBox();
            txtboxUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            tabControlUI.SuspendLayout();
            tabPageUpload.SuspendLayout();
            tabPageDownload.SuspendLayout();
            SuspendLayout();
            // 
            // btnUploadFile
            // 
            btnUploadFile.Location = new Point(217, 147);
            btnUploadFile.Margin = new Padding(4);
            btnUploadFile.Name = "btnUploadFile";
            btnUploadFile.Size = new Size(184, 43);
            btnUploadFile.TabIndex = 0;
            btnUploadFile.Text = "Upload";
            btnUploadFile.UseVisualStyleBackColor = true;
            btnUploadFile.Click += UploadFileToServer_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(12, 453);
            txtResult.Margin = new Padding(4);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(611, 169);
            txtResult.TabIndex = 1;
            txtResult.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 424);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 2;
            label1.Text = "Result";
            // 
            // tabControlUI
            // 
            tabControlUI.Controls.Add(tabPageUpload);
            tabControlUI.Controls.Add(tabPageDownload);
            tabControlUI.Location = new Point(12, 129);
            tabControlUI.Name = "tabControlUI";
            tabControlUI.SelectedIndex = 0;
            tabControlUI.Size = new Size(615, 267);
            tabControlUI.TabIndex = 3;
            // 
            // tabPageUpload
            // 
            tabPageUpload.Controls.Add(btnOpenFileDialog);
            tabPageUpload.Controls.Add(txtboxRemoteFolder);
            tabPageUpload.Controls.Add(txtboxSourceFile);
            tabPageUpload.Controls.Add(label3);
            tabPageUpload.Controls.Add(label2);
            tabPageUpload.Controls.Add(btnUploadFile);
            tabPageUpload.Location = new Point(4, 34);
            tabPageUpload.Name = "tabPageUpload";
            tabPageUpload.Padding = new Padding(3);
            tabPageUpload.Size = new Size(607, 229);
            tabPageUpload.TabIndex = 0;
            tabPageUpload.Text = "Upload Files";
            tabPageUpload.UseVisualStyleBackColor = true;
            // 
            // btnOpenFileDialog
            // 
            btnOpenFileDialog.Location = new Point(451, 20);
            btnOpenFileDialog.Name = "btnOpenFileDialog";
            btnOpenFileDialog.Size = new Size(106, 31);
            btnOpenFileDialog.TabIndex = 7;
            btnOpenFileDialog.Text = "Open";
            btnOpenFileDialog.UseVisualStyleBackColor = true;
            btnOpenFileDialog.Click += OpenSourceFileDialog_Click;
            // 
            // txtboxRemoteFolder
            // 
            txtboxRemoteFolder.Location = new Point(176, 79);
            txtboxRemoteFolder.Name = "txtboxRemoteFolder";
            txtboxRemoteFolder.Size = new Size(269, 31);
            txtboxRemoteFolder.TabIndex = 6;
            // 
            // txtboxSourceFile
            // 
            txtboxSourceFile.Location = new Point(176, 20);
            txtboxSourceFile.Name = "txtboxSourceFile";
            txtboxSourceFile.Size = new Size(269, 31);
            txtboxSourceFile.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 82);
            label3.Name = "label3";
            label3.Size = new Size(129, 25);
            label3.TabIndex = 4;
            label3.Text = "Remote folder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 23);
            label2.Name = "label2";
            label2.Size = new Size(141, 25);
            label2.TabIndex = 3;
            label2.Text = "Local source file:";
            // 
            // tabPageDownload
            // 
            tabPageDownload.Controls.Add(button1);
            tabPageDownload.Controls.Add(btnDownloadFile);
            tabPageDownload.Controls.Add(txtboxLocalDestination);
            tabPageDownload.Controls.Add(label7);
            tabPageDownload.Controls.Add(txtboxRemoteSource);
            tabPageDownload.Controls.Add(label6);
            tabPageDownload.Location = new Point(4, 34);
            tabPageDownload.Name = "tabPageDownload";
            tabPageDownload.Padding = new Padding(3);
            tabPageDownload.Size = new Size(607, 229);
            tabPageDownload.TabIndex = 1;
            tabPageDownload.Text = "Download Files";
            tabPageDownload.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(451, 83);
            button1.Name = "button1";
            button1.Size = new Size(106, 31);
            button1.TabIndex = 12;
            button1.Text = "Open";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OpenDestinationFolderDialog_Click;
            // 
            // btnDownloadFile
            // 
            btnDownloadFile.Location = new Point(220, 143);
            btnDownloadFile.Name = "btnDownloadFile";
            btnDownloadFile.Size = new Size(159, 47);
            btnDownloadFile.TabIndex = 4;
            btnDownloadFile.Text = "Download";
            btnDownloadFile.UseVisualStyleBackColor = true;
            btnDownloadFile.Click += btnDownloadFile_Click;
            // 
            // txtboxLocalDestination
            // 
            txtboxLocalDestination.Location = new Point(176, 83);
            txtboxLocalDestination.Name = "txtboxLocalDestination";
            txtboxLocalDestination.Size = new Size(269, 31);
            txtboxLocalDestination.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 83);
            label7.Name = "label7";
            label7.Size = new Size(108, 25);
            label7.TabIndex = 2;
            label7.Text = "Local folder:";
            // 
            // txtboxRemoteSource
            // 
            txtboxRemoteSource.Location = new Point(176, 25);
            txtboxRemoteSource.Name = "txtboxRemoteSource";
            txtboxRemoteSource.Size = new Size(269, 31);
            txtboxRemoteSource.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 25);
            label6.Name = "label6";
            label6.Size = new Size(134, 25);
            label6.TabIndex = 0;
            label6.Text = "Remote source:";
            // 
            // txtboxPassword
            // 
            txtboxPassword.Location = new Point(192, 78);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.PasswordChar = '*';
            txtboxPassword.Size = new Size(269, 31);
            txtboxPassword.TabIndex = 11;
            // 
            // txtboxUsername
            // 
            txtboxUsername.Location = new Point(192, 24);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.Size = new Size(269, 31);
            txtboxUsername.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 78);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 24);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 8;
            label4.Text = "Username:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(641, 650);
            Controls.Add(txtboxPassword);
            Controls.Add(txtboxUsername);
            Controls.Add(tabControlUI);
            Controls.Add(label5);
            Controls.Add(txtResult);
            Controls.Add(label4);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Stephen Simple SFTP client";
            tabControlUI.ResumeLayout(false);
            tabPageUpload.ResumeLayout(false);
            tabPageUpload.PerformLayout();
            tabPageDownload.ResumeLayout(false);
            tabPageDownload.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUploadFile;
        private RichTextBox txtResult;
        private Label label1;
        private TabControl tabControlUI;
        private TabPage tabPageUpload;
        private TabPage tabPageDownload;
        private TextBox txtboxRemoteFolder;
        private TextBox txtboxSourceFile;
        private Label label3;
        private Label label2;
        private Button btnOpenFileDialog;
        private TextBox txtboxPassword;
        private TextBox txtboxUsername;
        private Label label5;
        private Label label4;
        private TextBox txtboxLocalDestination;
        private Label label7;
        private TextBox txtboxRemoteSource;
        private Label label6;
        private Button btnDownloadFile;
        private Button button1;
    }
}