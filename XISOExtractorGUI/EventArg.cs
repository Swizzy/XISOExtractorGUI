namespace XISOExtractorGUI {
    using System;

    internal sealed class EventArg<T> : EventArgs
    {
        private readonly T _data;

        public EventArg(T data) {
            _data = data;
        }

        public T Data {
            get { return _data; }
        }

    }
}