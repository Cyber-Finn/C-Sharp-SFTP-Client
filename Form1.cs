using Microsoft.VisualBasic.ApplicationServices;
using Renci.SshNet;
using System.Configuration;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Windows.Forms;

//file scoped namespace
namespace C_Sharp_SFTP_Client;
public partial class Form1 : Form
{

    private string _pathOfFile = @"C:\PathTotheFileWeWantToUpload";
    private string _sftpDataInPath = @"\PathOfTheSFTPdropzone\";

    private string _myServer = "NameOfServer"; //for GoAnywhere MFT SFTP sites, this would probably be something like "mft.mydomain.com"
    private int _myPort = 22; //sftp uses port 22 (FTP runs on Port 21)
    private string _myUser = "MyUserName";
    private string _myPassword = "MyPassword";

    //download vars
    private string _remoteDirectory = "";
    private string _localDirectory = @"c:\downloads\";
    private string _finalDir = ""; //this will create a copy of _remoteDir each time we download a file from the remote folder, leave as-is 

    public Form1()
    {
        InitializeComponent();
    }

    private bool ValidateDetails(int operationID)
    {
        if (operationID == 0)
        {
            if (!string.IsNullOrWhiteSpace(txtboxSourceFile.Text) && !string.IsNullOrWhiteSpace(txtboxRemoteFolder.Text) && !string.IsNullOrWhiteSpace(txtboxUsername.Text) && !string.IsNullOrWhiteSpace(txtboxPassword.Text))
            {
                txtResult.Text = "Loaded details OK";

                //load the user's paths and creds
                _pathOfFile = txtboxSourceFile.Text;
                _sftpDataInPath = txtboxRemoteFolder.Text;
                _myUser = txtboxUsername.Text;
                _myPassword = txtboxPassword.Text;

                _myServer = txtboxRemoteHost.Text;

                return true;
            }
        }
        if (operationID == 1)
        {
            if (!string.IsNullOrWhiteSpace(txtboxRemoteSource.Text) && !string.IsNullOrWhiteSpace(txtboxLocalDestination.Text) && !string.IsNullOrWhiteSpace(txtboxUsername.Text) && !string.IsNullOrWhiteSpace(txtboxPassword.Text))
            {
                txtResult.Text = "Loaded details OK";

                //load the user's paths and creds
                _myUser = txtboxUsername.Text;
                _myPassword = txtboxPassword.Text;

                _myServer = txtboxRemoteHost.Text;

                return true;
            }
        }

        return false;
    }

    private void UploadFileToServer_Click(object sender, EventArgs e)
    {
        if (ValidateDetails(0))
        {
            //only attempt to send to remote server once the folders and user credentials are loaded (SFTP requires creds)
            SendDataToSFTPServer();
        }
        else
            txtResult.Text = "Missing details. Unable to perform action";
    }

    private void SendDataToSFTPServer()
    {
        string name = Path.GetFileName(_pathOfFile);
        try
        {
            #region upload files to remote server
            //this SftpClient is coming from our Renci dependency
            using (SftpClient sftp = new SftpClient(_myServer, _myPort, _myUser, _myPassword))
            {
                sftp.Connect();
                if (sftp.IsConnected)
                {
                    using (FileStream fileStream = new FileStream(_pathOfFile, FileMode.Open))
                    {
                        sftp.UploadFile(fileStream, _sftpDataInPath + "\\" + name);
                    }
                    #endregion upload files to remote server

                    txtResult.Text += "Uploaded Successfully. Name: " + name.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            txtResult.Text += ex.Message;
        }
    }


    private void DownloadFilesFromSFTPServer()
    {
        string name = Path.GetFileName(_pathOfFile);
        try
        {
            //this SftpClient is coming from our Renci dependency
            using (SftpClient sftp = new SftpClient(_myServer, _myPort, _myUser, _myPassword))
            {
                sftp.Connect();
                if (sftp.IsConnected)
                {
                    txtResult.Text += "\r\nConnected to remote host.";
                    #region download the files from the remote server

                    var files = sftp.ListDirectory(txtboxRemoteSource.Text);

                    //download all files in the directory
                    foreach (var file in files)
                    {
                        string remoteFileName = file.Name;

                        //we need to check that we only download today's files
                        if ((!file.Name.StartsWith(".")) && ((file.LastWriteTime.Date == DateTime.Today)))
                        {
                            _finalDir = _localDirectory; //dont want to overwrite my _localDir var, so using _finalDir to copy value each time

                            if (System.IO.File.Exists(_finalDir + file.Name))
                            {
                                MessageBox.Show("File already exists in local directory!");
                            }
                            else
                            {
                                if (remoteFileName.Substring(0, 2) == "./")
                                    remoteFileName = remoteFileName.Replace("./", "");

                                System.IO.File.Create(_finalDir + remoteFileName).Close();

                                using (Stream file1 = System.IO.File.OpenWrite(_finalDir + remoteFileName))
                                {
                                    sftp.DownloadFile(txtboxRemoteSource.Text + "\\" + remoteFileName, file1);
                                    txtResult.Text += "\r\nDownloaded successfully. Name: " + remoteFileName.ToString();
                                }
                            }
                        }
                    }
                    #endregion download the files from the remote server
                }
            }
        }
        catch (Exception ex) 
        {
            txtResult.Text += ex.Message;
        }
    }
    private void OpenSourceFileDialog_Click(object sender, EventArgs e)
    {
        //open a new file dialog window - lets our user choose files
        OpenFileDialog openFileDialog = new OpenFileDialog();

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                txtboxSourceFile.Text = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                txtResult.Text += $"Error with source file: {ex.Message}";
            }
        }

    }

    private void OpenDestinationFolderDialog_Click(object sender, EventArgs e)
    {
        //open a new file dialog window - lets our user choose files
        FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

        if (openFolderDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                txtboxLocalDestination.Text = openFolderDialog.SelectedPath;
            }
            catch (Exception ex)
            {
                txtResult.Text += $"Error with source file: {ex.Message}";
            }
        }
    }

    private void btnDownloadFile_Click(object sender, EventArgs e)
    {
        if (ValidateDetails(1))
        {
            _localDirectory = txtboxLocalDestination.Text + "\\";
            DownloadFilesFromSFTPServer();
        }
        else
            txtResult.Text = "Missing details. Unable to perform action";
        
    }
}