using Bingo.Wpf.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Wpf
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddWireDataContext<WireDataContext>()
                .AddInversionModule<ViewModules>().Run();
        }
    }
}
