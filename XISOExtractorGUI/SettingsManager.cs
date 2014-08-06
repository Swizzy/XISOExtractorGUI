namespace XISOExtractorGUI {
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net.FtpClient;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Xml;

    public partial class SettingsManager: Form {
        private readonly MainForm _mainfrm;

        public SettingsManager(MainForm mainForm) {
            InitializeComponent();
            _mainfrm = mainForm;
        }

        private void savebtn_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog {
                                             FileName = "default.cfg",
                                             DefaultExt = "cfg",
                                             AddExtension = true,
                                             Title = @"Select where to save your settings",
                                             InitialDirectory = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location)
                                         };
            if(sfd.ShowDialog() != DialogResult.OK)
                return;
            SaveSettings(sfd.FileName);
            Close();
        }

        private void loadbtn_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                                             FileName = "default.cfg",
                                             DefaultExt = "cfg",
                                             AddExtension = true,
                                             Title = @"Select settings to load",
                                             InitialDirectory = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location)
                                         };
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            LoadSettings(ofd.FileName);
            Close();
        }

        private void defaultsbtn_Click(object sender, EventArgs e) {
            _mainfrm.skipsysbox.Checked = true;
            _mainfrm.delIsobox.Checked = false;
            _mainfrm.ftpbox.Checked = false;
            _mainfrm.genfilelistbox.Checked = false;
            _mainfrm.gensfvbox.Checked = false;
            _mainfrm.FtpSettings.DataConnectionType = FtpDataConnectionType.PASVEX;
            _mainfrm.FtpSettings.Host = "";
            _mainfrm.FtpSettings.Password = "xbox";
            _mainfrm.FtpSettings.Port = 21;
            _mainfrm.FtpSettings.User = "xbox";
            Close();
        }

        private void SaveSettings(string file) {
            using(var xml = XmlWriter.Create(file, new XmlWriterSettings {
                                                                             Indent = true,
                                                                             CloseOutput = true
                                                                         })) {
                xml.WriteStartDocument();
                xml.WriteStartElement("root");
                xml.WriteElementString("skipsystemupdate", _mainfrm.skipsysbox.Checked.ToString());
                xml.WriteElementString("deleteiso", _mainfrm.delIsobox.Checked.ToString());
                xml.WriteElementString("generatefilelist", _mainfrm.genfilelistbox.Checked.ToString());
                xml.WriteElementString("generatesfv", _mainfrm.gensfvbox.Checked.ToString());
                xml.WriteElementString("useftp", _mainfrm.ftpbox.Checked.ToString());
                xml.WriteElementString("ftpcontype", ((int)_mainfrm.FtpSettings.DataConnectionType).ToString("X"));
                xml.WriteElementString("ftphost", _mainfrm.FtpSettings.Host);
                xml.WriteElementString("ftpport", _mainfrm.FtpSettings.Port.ToString(CultureInfo.InvariantCulture));
                xml.WriteElementString("ftpuser", _mainfrm.FtpSettings.User);
                xml.WriteElementString("ftppass", _mainfrm.FtpSettings.Password);
                xml.WriteEndElement();
                xml.WriteEndDocument();
            }
        }

        private static bool GetBool(XmlReader xml) {
            xml.Read();
            return xml.Value.Equals("true", StringComparison.CurrentCultureIgnoreCase);
        }

        private static string GetString(XmlReader xml) {
            xml.Read();
            return xml.Value;
        }

        private static int GetInt(XmlReader xml, int value, bool hex = false) {
            xml.Read();
            int ret;
            if(hex)
                return int.TryParse(xml.Value, NumberStyles.HexNumber, null, out ret) ? ret : value;
            if(int.TryParse(xml.Value, out ret))
                return ret;
            return int.TryParse(xml.Value, NumberStyles.HexNumber, null, out ret) ? ret : value;
        }

        private static FtpDataConnectionType GetConnectionType(XmlReader xml) { return (FtpDataConnectionType)GetInt(xml, (int)FtpDataConnectionType.PASVEX, true); }

        internal void LoadSettings(string file) {
            using(var xml = XmlReader.Create(file, new XmlReaderSettings {
                                                                             CloseInput = true
                                                                         })) {
                while(xml.Read()) {
                    if(!xml.IsStartElement())
                        continue;
                    switch(xml.Name.ToLower()) {
                        case "skipsystemupdate":
                            _mainfrm.skipsysbox.Checked = GetBool(xml);
                            break;
                        case "deleteiso":
                            _mainfrm.delIsobox.Checked = GetBool(xml);
                            break;
                        case "generatefilelist":
                            _mainfrm.genfilelistbox.Checked = GetBool(xml);
                            break;
                        case "generatesfv":
                            _mainfrm.gensfvbox.Checked = GetBool(xml);
                            break;
                        case "useftp":
                            _mainfrm.ftpbox.Checked = GetBool(xml);
                            break;
                        case "ftpcontype":
                            _mainfrm.FtpSettings.DataConnectionType = GetConnectionType(xml);
                            break;
                        case "ftphost":
                            _mainfrm.FtpSettings.Host = GetString(xml);
                            break;
                        case "ftpport":
                            _mainfrm.FtpSettings.Port = GetInt(xml, 21);
                            break;
                        case "ftpuser":
                            _mainfrm.FtpSettings.User = GetString(xml);
                            break;
                        case "ftppass":
                            _mainfrm.FtpSettings.Password = GetString(xml);
                            break;
                    }
                }
            }
        }
    }
}