//file scoped namespace
namespace C_Sharp_SFTP_Client;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        setFormInfo();
    } 
    private void SetUserInfo()
    {
        //if they have some private key file loaded, use it instead of password
        if(!string.IsNullOrEmpty(txtPrivatekeyLocation.Text) && !txtPrivatekeyLocation.Text.Equals("Full path and name; Leave blank if none"))
        {
            LoadPrivateKey();
        }

        UserInfo._myPort = int.Parse(txtPort.Text);
        UserInfo._myUser = txtboxUsername.Text;
        UserInfo._myPassword = txtboxPassword.Text;
        UserInfo._myServer = txtboxRemoteHost.Text;
    }

    private void setFormInfo()
    {
        txtPort.Text = UserInfo._myPort.ToString();
        txtboxUsername.Text = UserInfo._myUser;
        txtboxPassword.Text = UserInfo._myPassword;
        txtboxRemoteHost.Text = UserInfo._myServer;
    }

    private void LoadPrivateKey()
    {
        Utilities.LoadPrivateKeyFile(txtPrivatekeyLocation.Text);
    }

    private void btnUploadFiles_Click(object sender, EventArgs e)
    {
        UserInfo._homeForm = this;
        SetUserInfo();
        FormUploadFile frmUploadFiles = new FormUploadFile();
        frmUploadFiles.Show();
        this.Hide();
    }

    private void btnDownloadFiles_Click(object sender, EventArgs e)
    {
        UserInfo._homeForm = this;
        SetUserInfo();
        FormDownloadFile frmDownloadFiles = new FormDownloadFile();
        frmDownloadFiles.Show();
        this.Hide();
    }
}