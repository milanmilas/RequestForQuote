using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using RfqUi.Annotations;
using Timer = System.Timers.Timer;

namespace RfqUi.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public int Progress
        {
            get => _progress;
            set {
                _progress = value;
                OnPropertyChanged();
            }
        }

        private Timer _timer;
        private int _progress;

        public MainWindowViewModel()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Progress+=10;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
