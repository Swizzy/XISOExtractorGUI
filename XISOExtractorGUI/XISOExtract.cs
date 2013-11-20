namespace XISOExtractorGUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    using XISOExtractorGUI.Properties;

    public static class XISOExtract
    {
        private static readonly Encoding Enc = Encoding.GetEncoding(1252);
        private static ErrorLevels _errorLevel;
        private static bool _abort;

        public static bool Abort {
            get { return _abort; }
            set {
                _errorLevel = value ? ErrorLevels.Success : ErrorLevels.Aborted;
                _abort = value;
            }
        }

        private static long _totalSize;
        private static long _totalProcessed;
        private static long _currentSize;
        private static long _currentProcessed;

        #region Enums

        private enum XGDRootSector {
            XGD = 0,
            XGD1 = 0x30600,
            XGD2 = 0x1FB20,
            XGD3 = 0x4100
        }

        private enum ErrorLevels {
            Success = 0,
            TooSmallFile,
            CorruptXISO,
            InvalidTOCEntry,
            NothingToExtract,
            Aborted,
            Unkown = int.MaxValue //Unkown error, meaning something that shouldn't be possible happend!
            
        }

        #endregion

        #region Structs

        public struct XISODataEntry {
            public bool IsFile;
            public long Offset;
            public uint Size;
            public string Name;
            public string Path;
        }

        public class XISOListAndSize {
            public long Size;
            public long SysUpdateSize;
            public long Files;
            public long Folders;
            public List<XISODataEntry> List = new List<XISODataEntry>();
        }

        class XISOOptions
        {
            public string Source;
            public string Target;
            public bool ExcludeSysUpdate = true;
            public bool GenerateFileList;
            public bool GenerateSFV;
        }

        #endregion Structs

        #region Constants

        private const long TailOffset           = 0x7E6;
        private const long XISOHeaderOffset     = 0x10000;
        private const string XISOMediaString   = "MICROSOFT*XBOX*MEDIA";
        private const long SectorSize           = 0x800;
        private const uint BufferSize           = 0x200000;

        #endregion Constants

        #region Private Methods

        private static bool Seek(ref BinaryReader br, long offset, long len, ErrorLevels err = ErrorLevels.TooSmallFile, SeekOrigin origin = SeekOrigin.Begin) {
            if (origin == SeekOrigin.Begin || origin == SeekOrigin.End && br.BaseStream.Length < offset + len) {
                SeekError(ref br, err);
                return false;
            }
            if (origin == SeekOrigin.Current && br.BaseStream.Length < offset + len + br.BaseStream.Position) {
                SeekError(ref br, err);
                return false;
            }
            br.BaseStream.Seek(offset, origin);
            return true;
        }

        private static void SeekError(ref BinaryReader br, ErrorLevels err) {
            _errorLevel = err;
            br.Close();
        }

        private static bool SeekMediaString(ref BinaryReader br, long baseoffset) {
            return Seek(ref br, baseoffset * SectorSize + XISOHeaderOffset, XISOMediaString.Length);
        }

        private static bool VerifyMediaString(ref BinaryReader br, out XGDRootSector baseoffset) {

            XISOStatus.UpdateStatus("Verifying Media String in XISO Header");

            #region GamePartition Only/Xbox Original

            baseoffset = (long)XGDRootSector.XGD;
            if (!SeekMediaString(ref br, (long) baseoffset))
                return false;
            var tmp = br.ReadBytes(XISOMediaString.Length);
            if (Enc.GetString(tmp) == XISOMediaString)
                return true;

            #endregion GamePartition Only

            #region XGD3

            baseoffset = XGDRootSector.XGD3;
            if (!SeekMediaString(ref br, (long) baseoffset))
                return false;
            tmp = br.ReadBytes(XISOMediaString.Length);
            if (Enc.GetString(tmp) == XISOMediaString)
                return true;

            #endregion XGD3

            #region XGD2

            baseoffset = XGDRootSector.XGD2;
            if (!SeekMediaString(ref br, (long) baseoffset))
                return false;
            tmp = br.ReadBytes(XISOMediaString.Length);
            if (Enc.GetString(tmp) == XISOMediaString)
                return true;

            #endregion XGD2

            #region Xbox Original (iXtreme)

            baseoffset = XGDRootSector.XGD1;
            if (!SeekMediaString(ref br, (long) baseoffset))
                return false;
            tmp = br.ReadBytes(XISOMediaString.Length);
            if (Enc.GetString(tmp) == XISOMediaString)
                return true;

            #endregion Xbox Original (iXtreme)
            
            return false; // Invalid XISO (Couldn't find MediaString!)
        }

        private static bool VerifyMediaStringTail(ref BinaryReader br, XGDRootSector baseoffset) {
            XISOStatus.UpdateStatus("Verifying Media String in XISO Header Tail");
            if (!Seek(ref br, ((long)baseoffset * SectorSize) + TailOffset, XISOMediaString.Length))
                return false;
            var tmp = br.ReadBytes(XISOMediaString.Length);
            return Enc.GetString(tmp) == XISOMediaString;
        }

        private static bool VerifyXISO(string file, out XGDRootSector baseoffset)
        {
            _errorLevel = ErrorLevels.Success;
            baseoffset = 0;
            BinaryReader br;
            if (!LoadXISOForRead(file, out br))
                return false;
            if (VerifyMediaString(ref br, out baseoffset))
            {
                if (VerifyMediaStringTail(ref br, baseoffset))
                    return true;
                _errorLevel = ErrorLevels.CorruptXISO;
                return false;
            }
            return false;
        }

        private static bool LoadXISOForRead(string file, out BinaryReader br) {
            try 
            {
                br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read));
                return true;
            }
            catch {
               if (MessageBox.Show(string.Format(Resources.ErrorLoadingFileTryAgain, file), Resources.ERRORTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                   return LoadXISOForRead(file, out br);
            }
            br = null;
            return false;
        }

        private static bool GetXISOEntry(ref BinaryReader br, int basesector, long tocsector, int offset, out XISODataEntry ret, string dir, bool isFile = false) {
            ret = new XISODataEntry();
            if (!Seek(ref br, ((basesector + tocsector) * 2048) + offset + 0xD, 1, ErrorLevels.CorruptXISO))
                return false;
            int len = br.ReadByte();
            if (!Seek(ref br, ((basesector + tocsector) * 2048) + offset + 0xE, len, ErrorLevels.CorruptXISO))
                return false;
            ret.IsFile = isFile;
            ret.Path = dir;
            ret.Name = Enc.GetString(br.ReadBytes(len));
            if (isFile) {
                if (!Seek(ref br, ((basesector + tocsector) * 2048) + offset + 4, 4))
                    return false;
                uint tmp;
                if (!EndianConverter.Little32(br.ReadBytes(4), out tmp)) {
                    _errorLevel = ErrorLevels.Unkown;
                    return false;
                }
                ret.Offset = (basesector + tmp) * SectorSize;
                if (!Seek(ref br, ((basesector + tocsector) * 2048) + offset + 8, 4))
                    return false;
                if (!EndianConverter.Little32(br.ReadBytes(4), out ret.Size)) {
                    _errorLevel = ErrorLevels.Unkown;
                    return false;
                }
            }
            return true;
        }

        private static bool ParseXISO(ref BinaryReader br, ref List<XISODataEntry> filelist, int offset, int level, uint tocSector, XGDRootSector rootSector, string dirprefix = "\\")
        {
            if (_abort)
                return false;
            if (!Seek(ref br, (((int)rootSector + tocSector) * 2048) + offset + 4, 4, ErrorLevels.CorruptXISO)) 
                return false;
            uint sector;
            if (!EndianConverter.Big32(br.ReadBytes(4), out sector)) {
                _errorLevel = ErrorLevels.Unkown;
                return false;
            }
            if (sector == int.MaxValue) {
                _errorLevel = ErrorLevels.InvalidTOCEntry;
                return false;
            }
            if (!Seek(ref br, (((int)rootSector + tocSector) * 2048) + offset, 2, ErrorLevels.CorruptXISO))
                return false;
            ushort left;
            if (!EndianConverter.Little16(br.ReadBytes(2), out left)) {
                _errorLevel = ErrorLevels.Unkown;
                return false;
            }
            ushort right;
            if (!Seek(ref br, (((int)rootSector + tocSector) * 2048) + offset + 2, 2, ErrorLevels.CorruptXISO))
                return false;
            if (!EndianConverter.Little16(br.ReadBytes(2), out right)) {
                _errorLevel = ErrorLevels.Unkown;
                return false;
            }
            if (left != 0 && !ParseXISO(ref br, ref filelist, left * 4, level, tocSector, rootSector, dirprefix))
                return false;
            if (!Seek(ref br, (((int)rootSector + tocSector) * 2048) + offset + 0xC, 1, ErrorLevels.CorruptXISO))
                return false;
            if ((br.ReadByte() & 0x10) == 0x10) /* Dircectory found... */ {
                level++;
                if (!Seek(ref br, (((int)rootSector + tocSector) * 2048) + offset + 4, 4, ErrorLevels.CorruptXISO))
                    return false;
                if (!EndianConverter.Little32(br.ReadBytes(4), out tocSector)) {
                    _errorLevel = ErrorLevels.Unkown;
                    return false;
                }
                XISODataEntry entry;
                if (!GetXISOEntry(ref br, (int)rootSector, tocSector, offset, out entry, dirprefix))
                    return false;
                filelist.Add(entry);
                if (tocSector != 0 && !ParseXISO(ref br, ref filelist, 0, level, tocSector, rootSector, string.Format("{0}{1}\\", dirprefix, entry.Name)))
                    return false;

            }
            else {
                XISODataEntry entry;
                if (!GetXISOEntry(ref br, (int)rootSector, tocSector, offset, out entry, dirprefix, true))
                    return false;
                filelist.Add(entry);
            }
            return right == 0 || ParseXISO(ref br, ref filelist, right * 4, level, tocSector, rootSector, dirprefix);
        }

        private static bool ExtractFilesLocal(ref BinaryReader br, ICollection<XISODataEntry> files, string target) {
            if (files.Count == 0) {
                _errorLevel = ErrorLevels.NothingToExtract;
                return false;
            }
            XISOStatus.UpdateOperation(string.Format("Extracting data to: {0}", target));
            Directory.CreateDirectory(target);
            foreach (var entry in files) {
                if (_abort)
                    return false;
                if (!entry.IsFile) {
                    Directory.CreateDirectory(target + entry.Path + entry.Name);
                    continue;
                }
                XISOStatus.UpdateStatus(string.Format("Extracting {0}{1} ({2})", entry.Path, entry.Name, Utils.GetSizeReadable(entry.Size)));
                if (!ExtractFileLocal(ref br, entry.Offset, entry.Size, string.Format("{0}{1}{2}", target, entry.Path, entry.Name)))
                    return false;
            }
            return true;
        }

        private static bool ExtractFileLocal(ref BinaryReader br, long offset, uint size, string target) {
            if (!Seek(ref br, offset, size))
                return false;
            using (var bw = new BinaryWriter(File.Open(target, FileMode.Create, FileAccess.Write, FileShare.None))) { 
                for (uint i = 0; i < size;) {
                    if (_abort)
                        return false;
                    var readsize = Utils.GetSmallest(size - i, BufferSize);
                    bw.Write(br.ReadBytes((int) readsize));
                    i += readsize;
                    _totalProcessed += readsize;
                    _currentProcessed += readsize;
                    XISOStatus.UpdateFileProgress(i, size);
                    XISOStatus.UpdateOverallProgress(_totalProcessed, _totalSize);
                    XISOStatus.UpdateCurrentProgress(_currentProcessed, _currentSize);
                }
            }
            return true;
        }

        #endregion Private Methods

        #region Public Methods

        public static string GetLastError() {
            switch (_errorLevel) {
                case ErrorLevels.Success: return "Success";
                case ErrorLevels.TooSmallFile: return "File is to small...";
                case ErrorLevels.CorruptXISO: return "This XISO Seems to be corrupt";
                default: return "Undefined ERROR Occured";
            }
        }

        public static bool IsXISO(string file) {
            XGDRootSector tmp;
            return VerifyXISO(file, out tmp);
        }

        #endregion Public Methods
    }

    public static class XISOStatus {
        public class EventArg<T> : EventArgs {
            private readonly T _data;

            public EventArg(T data) {
                _data = data;
            }

            public T Data {
                get { return _data; }
            }

        }

        public static event EventHandler<EventArg<string>> Operation;
        public static event EventHandler<EventArg<string>> Status;
        public static event EventHandler<EventArg<double>> OverallProgress;
        public static event EventHandler<EventArg<double>> CurrentProgress;
        public static event EventHandler<EventArg<double>> FileProgress;
        public static event EventHandler<EventArg<double>> FTPProgress;

        internal static void UpdateOperation(string operation) {
            if (Operation != null)
                Operation(null, new EventArg<string>(operation));
        }

        internal static void UpdateStatus(string status) {
            if (Status != null)
                Status(null, new EventArg<string>(status));
        }

        internal static void UpdateCurrentProgress(long current, long max) {
            if (CurrentProgress != null)
                CurrentProgress(null, new EventArg<double>(Utils.GetPercentage(current, max)));
        }

        internal static void UpdateOverallProgress(long current, long max) {
            if (OverallProgress != null)
                OverallProgress(null, new EventArg<double>(Utils.GetPercentage(current, max)));
        }

        internal static void UpdateFileProgress(long current, long max) {
            if (FileProgress != null)
                FileProgress(null, new EventArg<double>(Utils.GetPercentage(current, max)));
        }

        internal static void UpdateFTPProgress(long current, long max)
        {
            if (FTPProgress != null)
                FTPProgress(null, new EventArg<double>(Utils.GetPercentage(current, max)));
        }

    }

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