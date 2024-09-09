using Renci.SshNet;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_Sharp_SFTP_Client
{
    public static class Utilities
    {
        public static void LoadPrivateKeyFile(string privatekeyLoc)
        {
            try
            {
                UserInfo._privateKey = new PrivateKeyFile(privatekeyLoc);
                UserInfo._usingPrivateKey = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                UserInfo._usingPrivateKey = false;
            }
        }

        public static void HandleFileUpload(string filePath)
        {
            HandleRemoteDirectoryNotGiven();
            if (UserInfo._usingPrivateKey)
            {
                UploadFile_PrivateKey(filePath);
                return;
            }
            UploadFile(filePath);
        }

        public static void HandleRemoteDirectoryNotGiven()
        {
            if (UserInfo._remoteDirectory == string.Empty)
            {
                UserInfo._remoteDirectory = UserInfo._myServer;
            }
        }

        private static void UploadFile(string filePath)
        {
            try
            {
                string name = Path.GetFileName(filePath);
                #region upload files to remote server
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._myPassword))
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            sftp.UploadFile(fileStream, UserInfo._remoteDirectory + "\\" + name);
                        }
                        #endregion upload files to remote server

                        //txtResult.Text += "Uploaded Successfully. Name: " + name.ToString() + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                //txtResult.Text += "\r\n" + ex.Message;
            }
        }

        private static void UploadFile_PrivateKey(string filePath)
        {
            try
            {
                string name = Path.GetFileName(filePath);
                #region upload files to remote server
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._privateKey)) //password not used when we connect via SSH with private key
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            sftp.UploadFile(fileStream, UserInfo._remoteDirectory + "\\" + name);
                        }
                        #endregion upload files to remote server

                        //txtResult.Text += "Uploaded Successfully. Name: " + name.ToString() + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                //txtResult.Text += "\r\n" + ex.Message;
            }
        }

        public static void HandleFileDownload(string filePath)
        {
            HandleRemoteDirectoryNotGiven();
            if (UserInfo._usingPrivateKey)
            {
                DownloadFile_PrivateKey(filePath);
                return;
            }
            DownloadFile(filePath);
        }

        public static void DownloadFile(string filePath)
        {
            try
            {
                string name = Path.GetFileName(filePath);
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._myPassword))
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        //txtResult.Text += "\r\nConnected to remote host.";
                        #region download the files from the remote server

                        var files = sftp.ListDirectory(UserInfo._remoteDirectory);

                        //download all files in the directory
                        foreach (var file in files)
                        {
                            string remoteFileName = file.Name;

                            if (System.IO.File.Exists(UserInfo._localDirectory + "\\" + file.Name))
                            {
                                MessageBox.Show("File already exists in local directory!");
                            }
                            else
                            {
                                if (remoteFileName.Substring(0, 2) == "./")
                                    remoteFileName = remoteFileName.Replace("./", "");

                                System.IO.File.Create(UserInfo._localDirectory + "\\"+ remoteFileName).Close();

                                using (Stream file1 = System.IO.File.OpenWrite(UserInfo._localDirectory + remoteFileName))
                                {
                                    sftp.DownloadFile(UserInfo._remoteDirectory + "\\" + remoteFileName, file1);
                                    //txtResult.Text += "\r\nDownloaded successfully. Name: " + remoteFileName.ToString();
                                }
                            }
                            
                        }
                        #endregion download the files from the remote server
                    }
                }
            }
            catch (Exception ex)
            {
                //txtResult.Text += "\r\n" + ex.Message;
            }
        }
        public static void DownloadFile_PrivateKey(string filePath)
        {
            try
            {
                string name = Path.GetFileName(filePath);
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._privateKey))
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        //txtResult.Text += "\r\nConnected to remote host.";
                        #region download the files from the remote server

                        var files = sftp.ListDirectory(UserInfo._remoteDirectory);

                        //download all files in the directory
                        foreach (var file in files)
                        {
                            string remoteFileName = file.Name;

                            if (System.IO.File.Exists(UserInfo._localDirectory + "\\" + file.Name))
                            {
                                MessageBox.Show("File already exists in local directory!");
                            }
                            else
                            {
                                if (remoteFileName.Substring(0, 2) == "./")
                                    remoteFileName = remoteFileName.Replace("./", "");

                                System.IO.File.Create(UserInfo._localDirectory + "\\" + remoteFileName).Close();

                                using (Stream file1 = System.IO.File.OpenWrite(UserInfo._localDirectory + remoteFileName))
                                {
                                    sftp.DownloadFile(UserInfo._remoteDirectory + "\\" + remoteFileName, file1);
                                    //txtResult.Text += "\r\nDownloaded successfully. Name: " + remoteFileName.ToString();
                                }
                            }
                        }
                        #endregion download the files from the remote server
                    }
                }
            }
            catch (Exception ex)
            {
                //txtResult.Text += "\r\n" + ex.Message;
            }
        }

        public static System.Windows.Forms.ListView GetLocalDirListViewItems(string path, ref System.Windows.Forms.ListView listView)
        {
            if(path == null || listView == null)
            {
                return null;
            }

            try
            {
                setListViewFontAndSize(ref listView);

                // Get all files in the directory
                string[] files = Directory.GetFiles(path);

                // Add files to the ListView
                foreach (string file in files)
                {
                    listView.Items.Add(new ListViewItem(Path.GetFileName(file)));
                }
                return listView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
            
        }
        private static void setListViewFontAndSize(ref System.Windows.Forms.ListView listView)
        {
            //set the font
            listView.Font = new Font(listView.Font.FontFamily, 14);
            //set the tile size
            listView.View = View.Tile;
            listView.TileSize = new Size(100, 100);
        }

        public static bool CheckIfInputsOK(string input)
        {
            return !string.IsNullOrEmpty(input) ? true : false;
        }
        public static System.Windows.Forms.ListViewItem GetSelectedListViewItem(ref System.Windows.Forms.ListView listViewSource)
        {
            if (listViewSource.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = listViewSource.SelectedItems[0];
                return selectedItem;
            }
            return null;
        }
        public static void ClearListViewItems(ref System.Windows.Forms.ListView listView)
        {
            // Clear existing items
            listView.Items.Clear();
        }

        public static void HandleReadFilenamesFromServer(ref System.Windows.Forms.ListView listView)
        {
            setListViewFontAndSize(ref listView);

            if (UserInfo._usingPrivateKey)
            {
                ReadFilenamesFromServer_PrivateKey(ref listView);
                return;
            }
                ReadFilenamesFromServer(ref listView);
        }

        private static void ReadFilenamesFromServer(ref System.Windows.Forms.ListView listView)
        {
            try
            {
                #region get filenames from the remote server
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._myPassword))
                {
                    sftp.Connect();
                    var files = sftp.ListDirectory(UserInfo._remoteDirectory);

                    foreach (var file in files)
                    {
                        if (!file.IsDirectory && !file.IsSymbolicLink)
                        {
                            listView.Items.Add(new ListViewItem(file.Name));
                        }
                    }

                    sftp.Disconnect();
                }
                #endregion get filenames from the remote server
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private static void ReadFilenamesFromServer_PrivateKey(ref System.Windows.Forms.ListView listView)
        {
            try
            {
                #region get filenames from the remote server
                //this SftpClient is coming from our Renci dependency
                using (SftpClient sftp = new SftpClient(UserInfo._myServer, UserInfo._myPort, UserInfo._myUser, UserInfo._privateKey))
                {
                    sftp.Connect();
                    var files = sftp.ListDirectory(UserInfo._remoteDirectory);

                    foreach (var file in files)
                    {
                        if (!file.IsDirectory && !file.IsSymbolicLink)
                        {
                            listView.Items.Add(new ListViewItem(file.Name));
                        }
                    }

                    sftp.Disconnect();
                }
                #endregion get filenames from the remote server
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
