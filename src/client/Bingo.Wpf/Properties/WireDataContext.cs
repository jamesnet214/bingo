using Bingo.Forms.Local.ViewModels;
using Bingo.Forms.UI.Views;
using Bingo.Login.Local;
using Bingo.Login.UI.Views;
using Bingo.Main.Local.ViewModels;
using Bingo.Main.UI.Views;
using Jamesnet.Wpf.Global.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Wpf.Properties
{
		internal class WireDataContext : ViewModelLocationScenario
		{
				protected override void Match(ViewModelLocatorCollection items)
				{
						items.Register<BingoWindow, BingoViewModel> ();
						items.Register<LoginContent, LoginContentViewModel> ();
						items.Register<MainContent, MainContentViewModel> ();
				}
		}
}
