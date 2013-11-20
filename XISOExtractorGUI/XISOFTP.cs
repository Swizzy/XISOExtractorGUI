namespace XISOExtractorGUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using XISOExtractorGUI.Properties;

    public static class XISOFTP {

        public static string LastError;

        private static readonly FtpClient Client = new FtpClient();

        public static bool IsConnected {
            get { return Client.IsConnected; }
        }

        private const uint BufferSize = 0x200000;

        private static bool Seek(ref BinaryReader br, long offset, long len, SeekOrigin origin = SeekOrigin.Begin)
        {
            if (origin == SeekOrigin.Begin || origin == SeekOrigin.End && br.BaseStream.Length < offset + len)
                return false;
            if (origin == SeekOrigin.Current && br.BaseStream.Length < offset + len + br.BaseStream.Position)
                return false;
            br.BaseStream.Seek(offset, origin);
            return true;
        }

        public static bool Connect(string host, int port = 21, FtpDataConnectionType connectionType = FtpDataConnectionType.PASVEX, string user = "xbox", string password = "xbox") {
            try {
                if (Client.IsConnected)
                    Client.Disconnect();
                Client.Host = host;
                Client.Port = port;
                Client.DataConnectionType = connectionType;
                Client.EncryptionMode = FtpEncryptionMode.None;
                Client.Credentials = new NetworkCredential(user, password);
                Client.Connect();
                return Client.IsConnected;
            }
            catch (Exception ex) {
                LastError = ex.Message;
                return false;
            }
        }

        public static void Disconnect() {
            Client.Disconnect();
        }

        public static bool SendFile(string file, byte[] data) {
            if (!Client.IsConnected)
                return false;
            using (var stream = Client.OpenWrite(file)) {
                try {
                    long offset = 0;
                    do {
                        var sendsize = Utils.GetSmallest(data.Length - offset, BufferSize);
                        stream.Write(data, (int)offset, (int)sendsize);
                        offset += sendsize;
                        XISOStatus.UpdateFTPProgress(offset, data.Length);
                    }
                    while (offset < data.Length);
                }
                catch (Exception ex) {
                    MessageBox.Show(string.Format(Resources.XISOFTPTransferError, file, ex), Resources.FTPTransferErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stream.Close();
                    return false;
                }
            }
            return true;
        }

        public static bool SendFile(string file, BinaryReader src, long offset, long size) {
            if (!Client.IsConnected)
                return false;
            using (var stream = Client.OpenWrite(file))
            {
                try
                {
                    if (src.BaseStream.Position != offset) {
                        if (!Seek(ref src, offset, size)) {
                            src.Close();
                            stream.Close();
                            return false;
                        }
                    }
                    else if (src.BaseStream.Length < src.BaseStream.Position + size) {
                        src.Close();
                        stream.Close();
                        return false;
                    }
                    long processed = 0;
                    do
                    {
                        var sendsize = Utils.GetSmallest(size - processed, BufferSize);
                        var data = src.ReadBytes((int) sendsize);
                        stream.Write(data, 0, data.Length);
                        processed += sendsize;
                        XISOStatus.UpdateFTPProgress(processed, size);
                    }
                    while (processed < size);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(Resources.XISOFTPTransferError, file, ex), Resources.FTPTransferErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stream.Close();
                    return false;
                }
            }
            return true;
        }

        public static bool GetDirListing(string dir, ref List<FTPDirList> list) {
            list.Clear();
            if (!Client.IsConnected)
                return false;
            try {
                if (dir != null)
                    Client.SetWorkingDirectory(dir);
                foreach (var ftpDirList in Client.GetListing()) {
                    list.Add(new FTPDirList {
                                                Name = ftpDirList.Name,
                                                IsDirectory =
                                                    ftpDirList.Type ==
                                                    FtpFileSystemObjectType.Directory
                                            });
                }
                return list.Count > 0;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
            }
            return false;
        }

        public class FTPDirList {
            public string Name;
            public bool IsDirectory;
        }

        public class FTPSettingsData
        {
            public string Host;
            public string User = "xbox";
            public string Password = "xbox";
            public int Port = 21;
            public FtpDataConnectionType DataConnectionType = FtpDataConnectionType.PASVEX;
            public string Path;
        }

    }
}