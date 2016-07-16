using System.Windows;
using System.Windows.Controls;

namespace VpnMonitor
{
    /// <summary>
    /// Interaction logic for StatusGumball.xaml
    /// </summary>
    public partial class StatusGumball : UserControl
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(GumballStatus), typeof(StatusGumball), new FrameworkPropertyMetadata(default(GumballStatus),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public GumballStatus Status
        {
            get { return (GumballStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public StatusGumball()
        {
            InitializeComponent();
        }
    }
}
