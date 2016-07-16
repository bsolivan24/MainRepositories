using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VpnMonitor
{
    public class AppHelpers
    {
        public static void CloseApplication(string appName)
        {
            if (IsProcessRunning(appName))
            {
                var proc = Process.GetProcessesByName(appName);
                foreach (var item in proc)
                {
                    item.Kill();
                }
            }
        }

        public static bool IsProcessRunning(string appName)
        {
            var proc = Process.GetProcessesByName(appName);
            return proc.Length > 0;
        }

        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            // IWshRuntimeLibrary is in the COM library "Windows Script Host Object Model"
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

            try
            {
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutFilename);
                return shortcut.TargetPath;
            }
            catch (COMException)
            {
                // A COMException is thrown if the file is not a valid shortcut (.lnk) file 
                return string.Empty;
            }

        }

    }
}
