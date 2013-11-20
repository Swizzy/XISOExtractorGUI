namespace XISOExtractorGUI
{
	using System;
	using System.Reflection;
	using System.Windows.Forms;

    internal sealed class FolderSelectDialog
	{
		readonly OpenFileDialog _ofd;
		const string DefaultFilter = "Folders|\n";

		public FolderSelectDialog()
		{
			_ofd = new OpenFileDialog {
				Filter = DefaultFilter,
				AddExtension = false,
				CheckFileExists = false,
				DereferenceLinks = true,
			};
		}

		#region Properties

		public string InitialDirectory
		{
			get { return _ofd.InitialDirectory; }
			set { _ofd.InitialDirectory = string.IsNullOrEmpty(value) ? Environment.CurrentDirectory : value; }
		}

		public string Title
		{
			get { return _ofd.Title; }
			set { _ofd.Title = value ?? "Select a folder"; }
		}

		public string FileName
		{
			get { return _ofd.FileName; }
			set { _ofd.FileName = value; }
		}

		#endregion

		#region Methods

		public bool ShowDialog()
		{
			return ShowDialog(IntPtr.Zero);
		}

		private bool ShowDialog(IntPtr hWndOwner)
		{
			bool flag;
			if (Environment.OSVersion.Version.Major >= 6)
			{
				var r = new Reflector("System.Windows.Forms");

				uint num = 0;
				var typeIFileDialog = r.GetType("FileDialogNative.IFileDialog");
				var dialog = Reflector.Call(_ofd, "CreateVistaDialog");
				Reflector.Call(_ofd, "OnBeforeVistaDialog", dialog);

				var options = (uint)Reflector.CallAs(typeof(FileDialog), _ofd, "GetOptions");
				options |= (uint)r.GetEnum("FileDialogNative.FOS", "FOS_PICKFOLDERS");
				Reflector.CallAs(typeIFileDialog, dialog, "SetOptions", options);

				var pfde = r.New("FileDialog.VistaDialogEvents", _ofd);
				var parameters = new[] { pfde, num };
				Reflector.CallAs2(typeIFileDialog, dialog, "Advise", parameters);
				num = (uint)parameters[1];
				try
				{
					var num2 = (int)Reflector.CallAs(typeIFileDialog, dialog, "Show", hWndOwner);
					flag = 0 == num2;
				}
				finally
				{
					Reflector.CallAs(typeIFileDialog, dialog, "Unadvise", num);
					GC.KeepAlive(pfde);
				}
			}
			else
			{
				var fbd = new FolderBrowserDialog {
													  Description = Title,
													  SelectedPath = InitialDirectory
												  };
				if (fbd.ShowDialog(new WindowWrapper(hWndOwner)) != DialogResult.OK)
					return false;
				_ofd.FileName = fbd.SelectedPath;
				return true;
			}

			return flag;
		}

		#endregion
	}

    internal sealed class WindowWrapper : IWin32Window
	{
	    internal WindowWrapper(IntPtr handle) {
			_hwnd = handle;
		}
		public IntPtr Handle {
			get { return _hwnd; }
		}

		private readonly IntPtr _hwnd;
	}

    internal sealed class Reflector
	{
		#region variables

		readonly string _mNs;
		readonly Assembly _mAsmb;

		#endregion

		#region Constructors

		public Reflector(string ns)
			: this(ns, ns)
		{ }

		public Reflector(string an, string ns)
		{
			_mNs = ns;
			_mAsmb = null;
			foreach (var aN in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
			{
				if (!aN.FullName.StartsWith(an, StringComparison.Ordinal))
					continue;
				_mAsmb = Assembly.Load(aN);
				break;
			}
		}

		#endregion

		#region Methods

		public Type GetType(string typeName)
		{
			Type type = null;
			var names = typeName.Split('.');

			if (names.Length > 0)
				type = _mAsmb.GetType(_mNs + "." + names[0]);

			for (var i = 1; i < names.Length; ++i) {
				if (type != null)
					type = type.GetNestedType(names[i], BindingFlags.NonPublic);
			}
			return type;
		}

		public object New(string name, params object[] parameters)
		{
			var type = GetType(name);

			var ctorInfos = type.GetConstructors();
			foreach (var ci in ctorInfos) {
				try {
					return ci.Invoke(parameters);
				} catch { }
			}

			return null;
		}

		public static object Call(object obj, string func, params object[] parameters) {
			return Call2(obj, func, parameters);
		}

		private static object Call2(object obj, string func, object[] parameters) {
			return CallAs2(obj.GetType(), obj, func, parameters);
		}

		public static object CallAs(Type type, object obj, string func, params object[] parameters) {
			return CallAs2(type, obj, func, parameters);
		}

		public static object CallAs2(Type type, object obj, string func, object[] parameters) {
			var methInfo = type.GetMethod(func, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			return methInfo.Invoke(obj, parameters);
		}

        public object GetEnum(string typeName, string name) {
			var type = GetType(typeName);
			var fieldInfo = type.GetField(name);
			return fieldInfo.GetValue(null);
		}

		#endregion

	}
}