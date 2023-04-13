using Bingo.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;

namespace Bingo.Main.Local.ViewModels
{
		public partial class ManContentViewModel : ObservableBase, IViewLoadable
		{
				[ObservableProperty]
				private BingoItemCollection bingoItems;
				public ManContentViewModel()
				{
						bingoItems = new ()
						{
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
								new BingoItem("하이하이"),
						};
						bingoItems.NumOfLine = 5;
				}

				public void OnLoaded(IViewable view)
				{

				}
		}
}
