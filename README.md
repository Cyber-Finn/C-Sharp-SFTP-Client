# C-Sharp SFTP Client
A very basic C# client that lets you connect to an SFTP server to download or upload files. This requires that the remote server has SFTP set up, and that you are running .Net.
<br>
The front-end now allows you to insert your own variable details to upload and download files as needed. This application does not save or store any information (as can be seen from the actual source code in this repository)
<br></br>
## Note:
Actual functionality code can be found in the "Form1.cs" file
<br>
There is a dependency mentioned in the code - this is a 3rd party library called Renci SSH .net which allows us to connect via SFTP

## How to connect to an SFTP site without code:
Firstly, Your remote server needs to have SFTP and SSH enabled.
<br>
Once that has been set up, you can connect with these steps from Command Prompt or PowerShell:
1. Windows provides functionality for this via SSH (Secure Shell). Simply open Command Prompt and type in "sftp {username@sftpServerDetails}" and hit enter! (the sftpServerDetails can either be an IP address, or a url, like "ftp.google.com" for example)
2. Type in your password when prompted
3. Use "ls" to browse your current remote directory, and "lls" to browse your device's local directory. "cd" and "lcd" work in the same way, respectively, to change directory.
4. Navigate to the directory you want to upload from (on your local machine) and the directory to download from (on the remote server).
5. Select a file to upload by running a command similar to "put {myfilename.txt}" - you can also use a wildcard character to upload all files of a given name or type.
6. Select a file to download by running a command similar to "put {myfilename.txt}" - you can also use a wildcard character to download all files of a given name or type.
