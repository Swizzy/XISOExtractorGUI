namespace XISOExtractorGUI {
    using System;

    internal sealed class EventArg <T>: EventArgs {
        
        public EventArg(T data) { Data = data; }

        public readonly T Data;
    }
}