using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alliance.NihonggoFlash.Services
{
    public class RunOnWindowsStartup
    {
        const string RegKeyName = "NihonggoFlash";
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public bool IsEnabled => rkApp.GetValue(RegKeyName)?.ToString() == System.Reflection.Assembly.GetExecutingAssembly().Location;

        public void Enable()
        {
            rkApp.SetValue(RegKeyName, System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        public void Disable()
        {
            rkApp.DeleteValue(RegKeyName, false);
        }
    }
}
