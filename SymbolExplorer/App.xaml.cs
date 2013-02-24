using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SymbolExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string FileToOpen;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (e.Args.Length > 0)
            {
                FileToOpen = e.Args[0];
            }
        }
    }
}
