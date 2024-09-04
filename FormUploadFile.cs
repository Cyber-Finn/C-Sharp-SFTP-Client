using System.Windows.Forms;

namespace C_Sharp_SFTP_Client
{
    public partial class FormUploadFile : Form
    {
        public FormUploadFile()
        {
            InitializeComponent();
        }

        private void btnUploadFiles_Click(object sender, EventArgs e)
        {
            if (Utilities.CheckIfInputsOK(txtDestination.Text) && Utilities.CheckIfInputsOK(txtSource.Text))
            {
                UserInfo._remoteDirectory = txtDestination.Text;

                //get the selected file
                string selectedFilePath = GetSelectedFile();
                if(!string.IsNullOrEmpty(selectedFilePath))
                {
                    //upload the file
                    Utilities.HandleFileUpload(selectedFilePath);

                    RefreshView_FilesOnLocal();
                    RefreshView_FilesOnServer();
                    return;
                }
            }
            MessageBox.Show("Please check that you have selected an item to upload, and that all inputs are populated!");
        }

        private string GetSelectedFile()
        {
            try
            {
                //get selected Item
                ListViewItem selectedItem = Utilities.GetSelectedListViewItem(ref listViewSource);
                if (selectedItem != null)
                {
                    //get name of selected Item
                    string itemName = selectedItem.Text;

                    //return the path of the selected file:
                    return Path.Combine(txtSource.Text, itemName);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a file to upload to the remote server!");
                throw;
            }
            return string.Empty;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshView_FilesOnServer();
        }
        private void RefreshView_FilesOnServer()
        {
            if (Utilities.CheckIfInputsOK(txtDestination.Text))
            {
                UserInfo._remoteDirectory = txtDestination.Text;
                Utilities.HandleReadFilenamesFromServer(ref listViewDestination);
            }
        }

        private void btnRefreshLocal_Click(object sender, EventArgs e)
        {
            //UserInfo._localDirectory = txtSource.Text;

            RefreshView_FilesOnLocal();
        }
        private void RefreshView_FilesOnLocal()
        {
            if (Utilities.CheckIfInputsOK(txtSource.Text))
            {
                Utilities.ClearListViewItems(ref listViewSource);
                listViewSource = Utilities.GetLocalDirListViewItems(txtSource.Text, ref listViewSource);

                listViewSource.Update();
                //get all the listed files on our side
            }
        }

        private void formClosingEvent(object sender, FormClosedEventArgs e)
        {
            UserInfo._homeForm.Show();
            this.Hide();
        }
    }
}
