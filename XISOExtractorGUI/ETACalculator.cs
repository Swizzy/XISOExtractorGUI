namespace XISOExtractorGUI {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public interface IEtaCalculator {
        TimeSpan ETR { get; }

        void Reset();

        void Update(float progress);
    }

    public class EtaCalculator: IEtaCalculator {
        private readonly Queue<KeyValuePair<long, float>> _queue = new Queue<KeyValuePair<long, float>>();
        private readonly Stopwatch _timer;
        private KeyValuePair<long, float> _current;

        public EtaCalculator() { _timer = Stopwatch.StartNew(); }

        public void Reset() {
            _queue.Clear();
            _timer.Reset();
            _timer.Start();
        }

        public void Update(float progress) {
            if(_current.Value == progress)
                return;
            var currentTicks = _timer.ElapsedTicks;
            _current = new KeyValuePair<long, float>(currentTicks, progress);
            _queue.Enqueue(_current);
            if(_queue.Count > 10)
                _queue.Dequeue();
        }

        public TimeSpan ETR {
            get {
                if(_queue.Count < 1)
                    return TimeSpan.Zero;
                var oldest = _queue.Peek();
                var current = _current;
                if(oldest.Value == current.Value)
                    return TimeSpan.Zero;
                var finishedInTicks = (1.0d - current.Value) * (current.Key - oldest.Key) / (current.Value - oldest.Value);
                return TimeSpan.FromSeconds(finishedInTicks / Stopwatch.Frequency);
            }
        }
    }
}