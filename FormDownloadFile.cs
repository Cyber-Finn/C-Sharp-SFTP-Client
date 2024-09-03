using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_SFTP_Client
{
    public partial class FormDownloadFile : Form
    {
        public FormDownloadFile()
        {
            InitializeComponent();
        }

        private void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            if (Utilities.CheckIfInputsOK(txtSource.Text) && Utilities.CheckIfInputsOK(txtDestination.Text))
            {
                UserInfo._localDirectory = txtDestination.Text;

                //get the selected file
                string selectedFilePath = GetSelectedFile();

                //Download the file
                Utilities.HandleFileDownload(selectedFilePath);

                RefreshView_FilesOnLocal();
                RefreshView_FilesOnServer();
            }
        }

        private string GetSelectedFile()
        {
            //get selected Item
            ListViewItem selectedItem = Utilities.GetSelectedListViewItem(ref listViewSource);

            //get name of selected Item
            string itemName = selectedItem.Text;

            //return the path of the selected file:
            return Path.Combine(txtDestination.Text, itemName);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshView_FilesOnLocal();
        }
        private void RefreshView_FilesOnServer()
        {
            if (Utilities.CheckIfInputsOK(txtSource.Text))
            {
                Utilities.ClearListViewItems(ref listViewSource);
                UserInfo._remoteDirectory = txtSource.Text;
                Utilities.HandleReadFilenamesFromServer(ref listViewSource);
            }
        }

        private void btnRefreshLocal_Click(object sender, EventArgs e)
        {
            //UserInfo._localDirectory = txtSource.Text;

            RefreshView_FilesOnServer();
        }
        private void RefreshView_FilesOnLocal()
        {
            if (Utilities.CheckIfInputsOK(txtDestination.Text))
            {
                Utilities.ClearListViewItems(ref listViewDestination);
                listViewDestination = Utilities.GetLocalDirListViewItems(txtDestination.Text, ref listViewDestination);

                listViewDestination.Update();
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
