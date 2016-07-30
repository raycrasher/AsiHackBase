using Alliance.NihonggoFlash.Services;
using Alliance.NihonggoFlash.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alliance.NihonggoFlash.Framework
{
    class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            SimpleIoc.Default.Register<IRepository,Repository>();
            SimpleIoc.Default.Register<RunOnWindowsStartup>();
            SimpleIoc.Default.Register<RetrieveDataFromOnline>();

            MainWindow mainWindow = new MainWindow();

            var app = new App();
            app.Run(mainWindow);
        }
    }
}
