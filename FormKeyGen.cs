using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SFTP_Client
{
    public partial class FormKeyGen : Form
    {
        public FormKeyGen()
        {
            InitializeComponent();
        }
        private void btnGenKey_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "[STARTING]";

            //define our command args
            string command = "ssh-keygen";
            string folderPath = txtDestination.Text;
            string fileName = txtKeyName.Text;
            string filePath = System.IO.Path.Combine(folderPath, fileName);
            string arguments = $"-t rsa-sha2-256 -b 2048 -f \"{filePath}\" -N \"\""; ;
            try
            {
                //create a new process - set the starting info
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                //start the new process
                using(Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    //read the output
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    //display our output (or any errors)
                    txtOutput.Text += "[OUTPUT]: " + output + "\r\n";
                    string res = (string.IsNullOrEmpty(error)) ? "None!" : error;
                    txtOutput.Text += "[ERRORS]: " + res + "\r\n";

                    if(!string.IsNullOrEmpty(error))
                    {
                        //load up their private key
                        Utilities.LoadPrivateKeyFile(System.IO.Path.Combine(folderPath, fileName));
                    }
                }
                txtOutput.Text += "[INFO]: Both a 2048 bit Public and Private RSA key were created in the directory\r\nThe public key has the \".pub\"extension.";
            }
            catch (Exception ex)
            {
                txtOutput.Text += "[ERRORS]: " + ex.Message + "\r\n";
                return;
            }
        }

        private void formClosingEvent(object sender, FormClosedEventArgs e)
        {
            UserInfo._homeForm.Show();
            this.Hide();
        }

        private void txtKeyNameChanged(object sender, EventArgs e)
        {
            //convert to lowercase and replace spaces with hyphens
            string modified = txtKeyName.Text.ToLower().Replace(' ', '-');

            //unsubscribe to avoid recursive calls
            txtKeyName.TextChanged -= txtKeyNameChanged;

            txtKeyName.Text = modified;

            //set the cursor to the end of the text
            txtKeyName.SelectionStart = txtKeyName.Text.Length;

            //subscribe to the event again
            txtKeyName.TextChanged += txtKeyNameChanged;
        }
    }
}
