using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace VpnMonitor
{
    public class AppInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GumballStatus _status;

        public string AppName { get; set; }

        public string FullPath { get; set; }
        
        public GumballStatus Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;

                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
