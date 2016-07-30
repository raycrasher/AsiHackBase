using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alliance.NihonggoFlash.Models;
using Alliance.NihonggoFlash.Services;
using System.Windows.Input;
using Alliance.NihonggoFlash.Framework;
using System.ComponentModel;
using System.Security.Principal;
using System.Diagnostics;

namespace Alliance.NihonggoFlash.ViewModels
{
    [ImplementPropertyChanged]
    class MainViewModel
    {
        public FlashCard FlashCard { get; set; } = new FlashCard();
        System.Random _rng = new Random();

        public MainViewModel()
        {
            FlashCard = GetRandomCard();
            RunOnStartup = SimpleIoc.Default.GetInstance<RunOnWindowsStartup>().IsEnabled;
        }

        private FlashCard GetRandomCard()
        {
            var cards = SimpleIoc.Default.GetInstance<IRepository>().Cards;

            var count = cards.Select(s => s.Id).Count();
            var n = _rng.Next(0, count - 1);
            return cards.OrderBy(s=>s.Word).Skip(n).First();
            /*
            return new FlashCard
            {
                HowToRead = "ひるまがあたたかい",
                Word = "昼間が暖かい",
                Meaning = "It's warm in the daytime",
                Sample = "NA"
            };*/
        }

        public bool RunOnStartup { get; set; }

        public ICommand ToggleRunOnStartup => new DelegateCommand(o => {
            var start = SimpleIoc.Default.GetInstance<RunOnWindowsStartup>();
            RunOnStartup = start.IsEnabled;

            if (IsAdministrator())
            {
                if (start.IsEnabled)
                {
                    start.Disable();
                    RunOnStartup = false;
                }
                else
                {
                    start.Enable();
                    RunOnStartup = true;
                }
            }
            else {                
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
                System.Windows.Application.Current.Shutdown();
                return;
            }

        });

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
