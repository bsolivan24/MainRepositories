using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VpnMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public VpnMonitorViewModel ViewModel { get { return DataContext as VpnMonitorViewModel; } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            ViewModel.HandleDrop(e);
        }
        
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            ViewModel.PopulateNetworkInterfaceNames();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            ViewModel.MakeSelection(comboBox.SelectedItem as string);
        }
    }
}
