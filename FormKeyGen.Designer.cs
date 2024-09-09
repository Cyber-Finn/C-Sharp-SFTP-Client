namespace C_Sharp_SFTP_Client
{
    partial class FormKeyGen
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
            btnGenKey = new Button();
            label1 = new Label();
            label2 = new Label();
            txtOutput = new RichTextBox();
            txtDestination = new TextBox();
            txtKeyName = new TextBox();
            SuspendLayout();
            // 
            // btnGenKey
            // 
            btnGenKey.Location = new Point(286, 373);
            btnGenKey.Name = "btnGenKey";
            btnGenKey.Size = new Size(136, 49);
            btnGenKey.TabIndex = 0;
            btnGenKey.Text = "Create Key";
            btnGenKey.UseVisualStyleBackColor = true;
            btnGenKey.Click += btnGenKey_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 1;
            label1.Text = "Destination Folder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 60);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 2;
            label2.Text = "Key Name:";
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 108);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(686, 259);
            txtOutput.TabIndex = 3;
            txtOutput.Text = "";
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(179, 9);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(519, 31);
            txtDestination.TabIndex = 4;
            txtDestination.Text = "C:\\KeyFiles";
            // 
            // txtKeyName
            // 
            txtKeyName.Location = new Point(179, 60);
            txtKeyName.Name = "txtKeyName";
            txtKeyName.Size = new Size(519, 31);
            txtKeyName.TabIndex = 5;
            txtKeyName.Text = "sample-key-name";
            txtKeyName.TextChanged += txtKeyNameChanged;
            // 
            // FormKeyGen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 436);
            Controls.Add(txtKeyName);
            Controls.Add(txtDestination);
            Controls.Add(txtOutput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGenKey);
            Name = "FormKeyGen";
            Text = "Generate RSA 2048bit Keypair";
            FormClosed += formClosingEvent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenKey;
        private Label label1;
        private Label label2;
        private RichTextBox txtOutput;
        private TextBox txtDestination;
        private TextBox txtKeyName;
    }
}