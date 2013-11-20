namespace XISOExtractorGUI {
    using System;

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
}