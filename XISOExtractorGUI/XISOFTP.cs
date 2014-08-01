namespace XISOExtractorGUI {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.FtpClient;
    using System.Windows.Forms;
    using XISOExtractorGUI.Properties;

    public static class Xisoftp {
        private const uint BufferSize = 0x2000;
        public static string LastError;

        private static readonly FtpClient Client = new FtpClient();

        static Xisoftp() {
            Client.SocketKeepAlive = true;
        }

        public static bool IsConnected { get { return Client.IsConnected; } }

        internal static event EventHandler<EventArg<long, long, long>> ProgressUpdate;

        private static bool Seek(ref BinaryReader br, long offset, long len, SeekOrigin origin = SeekOrigin.Begin) {
            if(origin == SeekOrigin.Begin && br.BaseStream.Length < offset + len)
                return false;
            if(origin == SeekOrigin.End && br.BaseStream.Length - offset < len)
                return false;
            if(origin == SeekOrigin.Current && br.BaseStream.Length < offset + len + br.BaseStream.Position)
                return false;
            br.BaseStream.Seek(offset, origin);
            return true;
        }

        public static bool Connect(string host, int port = 21, FtpDataConnectionType connectionType = FtpDataConnectionType.PASVEX, string user = "xbox", string password = "xbox") {
            try {
                if(Client.IsConnected)
                    Client.Disconnect();
                Client.Host = host;
                Client.Port = port;
                Client.DataConnectionType = connectionType;
                Client.EncryptionMode = FtpEncryptionMode.None;
                Client.Credentials = new NetworkCredential(user, password);
                Client.Connect();
                return Client.IsConnected;
            }
            catch(Exception ex) {
                LastError = ex.Message;
                return false;
            }
        }

        public static void Disconnect() { Client.Disconnect(); }

        public static bool SendFile(string file, ref BinaryReader src, long offset, long size) {
            if(!Client.IsConnected) {
                XisoExtractor.UpdateStatus("FTP Not connected!");
                return false;
            }
            try {
                using(var stream = Client.OpenWrite(file)) {
                    if(src.BaseStream.Position != offset) {
                        if(!Seek(ref src, offset, size)) {
                            src.Close();
                            XisoExtractor.UpdateStatus("Seek failure!");
                            return false;
                        }
                    }
                    else if(src.BaseStream.Length < src.BaseStream.Position + size) {
                        src.Close();
                        XisoExtractor.UpdateStatus("Size failure!");
                        return false;
                    }
                    long processed = 0;
                    XISOStatus.UpdateFTPProgress(processed, size);
                    while(processed < size) {
                        if(XisoExtractor.Abort)
                            return false;
                        var sendsize = Utils.GetSmallest(size - processed, BufferSize);
                        var data = src.ReadBytes((int)sendsize);
                        stream.Write(data, 0, data.Length);
                        processed += sendsize;
                        var handler = ProgressUpdate;
                        if(handler != null)
                            handler.Invoke(null, new EventArg<long, long, long>(sendsize, processed, size));
                        XISOStatus.UpdateFTPProgress(processed, size);
                    }
                }
            }
            catch(Exception ex) {
                LastError = ex.Message;
                MessageBox.Show(string.Format(Resources.XISOFTPTransferError, file, ex), Resources.FTPTransferErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool SetDirectory(string dir) {
            if(!Client.IsConnected)
                return false;
            try {
                Client.SetWorkingDirectory(dir);
                var ret = Client.GetWorkingDirectory();
                if(!ret.EndsWith("/") && dir.EndsWith("/"))
                    ret += "/";
                if (ret.EndsWith("/") && !dir.EndsWith("/"))
                    dir += "/";
                return (ret == dir);
            }
            catch(FtpCommandException ex) {
                if (ex.Message.Equals("No such directory", StringComparison.CurrentCultureIgnoreCase) || ex.Message.EndsWith("Path not found.", StringComparison.CurrentCultureIgnoreCase))
                {
                    //var index = dir.Substring(0, dir.Length - 1).LastIndexOf('/');
                    //if(index <= 0)
                    //    return false;
                    //var tmp = dir.Substring(index);
                    //dir = dir.Substring(0, index) + "/";
                    Client.CreateDirectory(dir);
                    Client.SetWorkingDirectory(dir);
                    var ret = Client.GetWorkingDirectory();
                    if (!ret.EndsWith("/") && dir.EndsWith("/"))
                        ret += "/";
                    if(ret.EndsWith("/") && !dir.EndsWith("/"))
                        dir += "/";
                    return (ret == dir);
                }
                LastError = ex.Message;
                return false;
            }
        }

        public static bool GetDirListing(string dir, ref List<FTPDirList> list) {
            list.Clear();
            if(!Client.IsConnected)
                return false;
            try {
                if(dir != null)
                    Client.SetWorkingDirectory(dir);
                foreach(var ftpDirList in Client.GetListing()) {
                    list.Add(new FTPDirList {
                                                Name = ftpDirList.Name,
                                                IsDirectory = ftpDirList.Type == FtpFileSystemObjectType.Directory
                                            });
                }
                return list.Count > 0;
            }
            catch(Exception ex) {
                LastError = ex.Message;
            }
            return false;
        }

        public static bool CreateDirectory(string dir) {
            if(!Client.IsConnected)
                return false;
            Client.CreateDirectory(dir, false);
            return true;
        }

        public class FTPDirList {
            public bool IsDirectory;
            public string Name;
        }

        public class FTPSettingsData {
            public FtpDataConnectionType DataConnectionType = FtpDataConnectionType.PASVEX;
            public string Host;
            public string Password = "xbox";
            private string _path;

            public string Path {
                get {
                    return _path;
                }
                set {
                    if(!value.EndsWith("/"))
                        value += "/";
                    _path = value;
                }
            }

            public int Port = 21;
            public string User = "xbox";

            public bool IsValid { get { return !string.IsNullOrEmpty(Host) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Path); } }
        }
    }
}