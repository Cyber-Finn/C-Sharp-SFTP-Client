using Microsoft.VisualBasic.ApplicationServices;
using Renci.SshNet;
using System.Configuration;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

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
    private string _finalDir = "";

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //just have a single method here to do both uploading/downloading, but in reality, we'd split this out into separate methods for unit testing and control purposes
        SendAndReceiveDataFromSFTPServer();
    }

    private void SendAndReceiveDataFromSFTPServer()
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

                    richTextBox1.Text = "Uploaded Successfully. Name: " + name.ToString();

                    #region download the files from the remote server

                    var files = sftp.ListDirectory("");

                    foreach (var file in files)
                    {
                        string remoteFileName = file.Name;

                        //we need to check that we only download today's files
                        if ((!file.Name.StartsWith(".")) && ((file.LastWriteTime.Date == DateTime.Today)))
                        {
                            _finalDir = _localDirectory;

                            if (System.IO.File.Exists(_finalDir + file.Name))
                            {
                                MessageBox.Show("File already exists!");
                            }
                            else
                            {
                                using (Stream file1 = System.IO.File.OpenWrite(_finalDir + remoteFileName))
                                {
                                    sftp.DownloadFile(_remoteDirectory + remoteFileName, file1);
                                    richTextBox1.Text += "\r\nDownloaded successfully. Name: " + remoteFileName.ToString();
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
            richTextBox1.Text = ex.Message;
        }
    }
}