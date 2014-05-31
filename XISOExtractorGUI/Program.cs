namespace XISOExtractorGUI
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
            Application.Run(new MainForm());
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
            return opt;
        }
    }
}
