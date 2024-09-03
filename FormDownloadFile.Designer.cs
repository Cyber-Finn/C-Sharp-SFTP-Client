namespace C_Sharp_SFTP_Client
{
    partial class FormDownloadFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSource;
        private TextBox txtDestination;
        private Button btnUploadFiles;
        private ListView listViewSource;
        private ListView listViewDestination;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnRefreshLocal;
        private Button btnRefresh;

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
            txtSource = new TextBox();
            txtDestination = new TextBox();
            btnUploadFiles = new Button();
            listViewSource = new ListView();
            listViewDestination = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnRefreshLocal = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // txtSource
            // 
            txtSource.Location = new Point(190, 9);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(407, 31);
            txtSource.TabIndex = 0;
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(190, 55);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(407, 31);
            txtDestination.TabIndex = 1;
            // 
            // btnUploadFiles
            // 
            btnUploadFiles.Location = new Point(234, 350);
            btnUploadFiles.Name = "btnUploadFiles";
            btnUploadFiles.Size = new Size(155, 57);
            btnUploadFiles.TabIndex = 2;
            btnUploadFiles.Text = "Download";
            btnUploadFiles.UseVisualStyleBackColor = true;
            btnUploadFiles.Click += btnDownloadFiles_Click;
            // 
            // listViewSource
            // 
            listViewSource.Location = new Point(12, 144);
            listViewSource.Name = "listViewSource";
            listViewSource.Size = new Size(600, 184);
            listViewSource.TabIndex = 3;
            listViewSource.UseCompatibleStateImageBehavior = false;
            // 
            // listViewDestination
            // 
            listViewDestination.Location = new Point(12, 432);
            listViewDestination.Name = "listViewDestination";
            listViewDestination.Size = new Size(600, 197);
            listViewDestination.TabIndex = 4;
            listViewDestination.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 15);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 5;
            label1.Text = "Remote Source:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(151, 25);
            label2.TabIndex = 6;
            label2.Text = "Local Destination:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 107);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 7;
            label3.Text = "Files on Server:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 401);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 8;
            label4.Text = "Local Files:";
            // 
            // btnRefreshLocal
            // 
            btnRefreshLocal.Location = new Point(500, 635);
            btnRefreshLocal.Name = "btnRefreshLocal";
            btnRefreshLocal.Size = new Size(112, 39);
            btnRefreshLocal.TabIndex = 9;
            btnRefreshLocal.Text = "Refresh";
            btnRefreshLocal.UseVisualStyleBackColor = true;
            btnRefreshLocal.Click += btnRefresh_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(500, 334);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 39);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefreshLocal_Click;
            // 
            // FormDownloadFile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 692);
            Controls.Add(btnRefresh);
            Controls.Add(btnRefreshLocal);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listViewDestination);
            Controls.Add(listViewSource);
            Controls.Add(btnUploadFiles);
            Controls.Add(txtDestination);
            Controls.Add(txtSource);
            MaximizeBox = false;
            Name = "FormDownloadFile";
            Text = "CyberFinn Download Files";
            FormClosed += formClosingEvent;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion Windows Form Designer generated code
    }
}