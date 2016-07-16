using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace VpnMonitor
{
    public class VpnMonitorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _networkNameSelection;
        private GumballStatus _status;
        private Visibility _dragDropHelpTextVisible;

        public ObservableCollection<AppInfo> Apps { get; set; }

        public ObservableCollection<string> InterfaceNames { get; set; }

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
        
        public Visibility DragDropHelpTextVisility
        {
            get { return _dragDropHelpTextVisible; }
            set
            {
                if (_dragDropHelpTextVisible == value)
                    return;

                _dragDropHelpTextVisible = value;
                OnPropertyChanged("DragDropHelpTextVisility");
            }
        }

        public string NetworkNameSelection
        {
            get
            {
                return _networkNameSelection;
            }

            set
            {
                var cValue = value;
                if(cValue == null)
                {
                    cValue = string.Empty;
                }
                _networkNameSelection = cValue;
                OnPropertyChanged("NetworkNameSelection");
            }
        }

        public VpnMonitorModel()
        {
            Apps = new ObservableCollection<AppInfo>();
            InterfaceNames = new ObservableCollection<string>();
            NetworkNameSelection = string.Empty;
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
