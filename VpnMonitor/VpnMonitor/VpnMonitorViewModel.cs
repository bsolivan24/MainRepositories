using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows;

namespace VpnMonitor
{
    public class VpnMonitorViewModel
    {
        public Timer _monitor = new Timer();

        public string DefaultSelection = "Select PPTP 'IP Vanish'";

        public VpnMonitorModel Model { get; private set; }

        public VpnMonitorViewModel()
        {
            Model = new VpnMonitorModel();
            Model.InterfaceNames.Add(DefaultSelection);
            Model.NetworkNameSelection = DefaultSelection;
            _monitor.Interval = 2000;
            _monitor.Elapsed += (sender, e) =>  Monitor();
            _monitor.Start();
        }

        private void Monitor()
        {
            MonitorNetowrk();
            MonitorApps();
        }

        public void MonitorNetowrk()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var networkInterfaces = NetworkHelper.GetNetworkInterfaces();
                
                if(!networkInterfaces.Where(netInterface => netInterface.Name.ToLower() == Model.NetworkNameSelection.ToLower()).Any())
                {
                    Model.Status = GumballStatus.Bad;
                    return;
                }

                foreach (NetworkInterface Interface in networkInterfaces)
                {
                    if (Interface.Name.ToLower() != Model.NetworkNameSelection.ToLower())
                        continue;

                    Model.Status = Interface.OperationalStatus == OperationalStatus.Up ? GumballStatus.Good : GumballStatus.Bad;
                }
            }
        }

        internal void MakeSelection(string selection)
        {
            if (selection == DefaultSelection)
                return;
            Model.NetworkNameSelection = selection;
        }

        internal void PopulateNetworkInterfaceNames()
        {
            Model.InterfaceNames.Clear();
            
            var netInerfaces = NetworkHelper.GetNetworkInterfaces();
            foreach(var netInterface in netInerfaces)
            {
                Model.InterfaceNames.Add(netInterface.Name);
            }
        }

        internal void HandleDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileDropData = e.Data.GetData(DataFormats.FileDrop);
                var droppedFiles = fileDropData as String[];
                if(droppedFiles != null)
                {
                    foreach(var filePath in droppedFiles.Where(file => File.Exists(file)))
                    {
                        var fullPath = filePath;
                        var targetFile = filePath;
                        if (Path.GetExtension(fullPath) == ".lnk")
                        {
                            targetFile = AppHelpers.GetShortcutTargetFile(fullPath);
                        }
                        var appName = Path.GetFileNameWithoutExtension(targetFile);
                        var appInfo = new AppInfo()
                        {
                            FullPath = filePath,
                            AppName = appName,
                        };

                        Model.Apps.Add(appInfo);
                        Model.DragDropHelpTextVisility = Model.Apps.Any() ? Visibility.Collapsed : Visibility.Visible; 
                    }
                }
            }
        }

        public void MonitorApps()
        {
            foreach (var app in Model.Apps)
            {
                app.Status = AppHelpers.IsProcessRunning(app.AppName) ? GumballStatus.Good : GumballStatus.Bad;
            }
            
            if (Model.Status == GumballStatus.Good)
                StartApps();
            else
                StopApps();
        }

        public void StopApps()
        {
            foreach (var app in Model.Apps.Where(thisApp => thisApp.Status == GumballStatus.Good))
            {
                CloseApp(app);
            }
        }

        public void CloseApp(AppInfo app)
        {
            var processes = Process.GetProcessesByName(app.AppName);
            if(processes.Count() > 0)
            {
                foreach(var process in processes)
                {
                    process.Kill();
                }
            }
        }

        public void StartApps()
        {
            foreach (var app in Model.Apps.Where(thisApp => thisApp.Status == GumballStatus.Bad))
            {
                OpenApp(app);
            }
        }
        
        public void OpenApp(AppInfo app)
        {
            Process.Start(app.FullPath);
        }
    }
}
