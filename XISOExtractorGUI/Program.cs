namespace XISOExtractorGUI
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    static class Program {
        internal static MainForm Form;
        internal static Icon Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Form = new MainForm(args);
            Application.Run(Form);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs) {
            File.WriteAllText(string.Format("crash{0}.log", DateTime.Now), unhandledExceptionEventArgs.ExceptionObject.ToString());
        }

        static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args) {
            if (string.IsNullOrEmpty(args.Name))
                throw new Exception("DLL Read Failure (Nothing to load!)");
            var name = string.Format("{0}.dll", args.Name.Split(',')[0]);
            using (var stream = Assembly.GetAssembly(typeof(Program)).GetManifestResourceStream(string.Format("{0}.{1}", typeof(Program).Namespace, name)))
            {
                if(stream == null)
                    throw new Exception(string.Format("Can't find external nor internal {0}!", name));
                var data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return Assembly.Load(data);
            }
        }

        internal static string GetOptString(BwArgs args)
        {
            var opt = "";
            if (args.SkipSystemUpdate)
                opt += "nosystemupdate=true ";
            if (args.GenerateFileList)
                opt += "genfilelist=true ";
            if (args.GenerateSfv)
                opt += "gensfv=true ";
            if(args.DeleteIsoOnCompletion)
                opt += "deleteisooncompletion=true ";
            if(args.UseFtp) {
                opt += "useftp=true";
                opt += " ftphost=" + args.FtpSettings.Host;
                opt += " ftpport=" + args.FtpSettings.Port;
                opt += " ftpuser=" + args.FtpSettings.User;
                opt += " ftppass=" + args.FtpSettings.Password;
                opt += " ftppath=" + args.FtpSettings.Path;
                opt += " ftpmode=" + args.FtpSettings.DataConnectionType;
            }
            return opt.Trim();
        }
    }
}
