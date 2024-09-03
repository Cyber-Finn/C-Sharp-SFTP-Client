using Renci.SshNet;

namespace C_Sharp_SFTP_Client
{
    public static class UserInfo
    {
        public static string _myServer = ""; //for GoAnywhere MFT or other SFTP sites - Like AWS transfer family S3 buckets, this would probably be something like "mft.mydomain.com"
        public static int _myPort = 22; //sftp uses port 22 (FTP runs on Port 21) -> we allow the user to specify this though
        public static string _myUser = "";
        public static string _myPassword = "";
        public static bool _usingPrivateKey = false;
        public static IPrivateKeySource _privateKey = null;

        public static string _localDirectory = "";
        public static string _remoteDirectory = "";
        public static Form1 _homeForm = null;
    }
}
