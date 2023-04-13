using Bingo.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using System;

namespace Bingo.Main.Local.ViewModels
{
		public partial class ManContentViewModel : ObservableBase, IViewLoadable
		{
				[ObservableProperty]
				private BingoItemCollection bingoItems;
				public ManContentViewModel()
				{
						this.BingoItems = new ()
						{
								new BingoItem("1"),
								new BingoItem("2"),
								new BingoItem("3"),
								new BingoItem("4"),
								new BingoItem("5"),
								new BingoItem("6"),
								new BingoItem("7"),
								new BingoItem("8"),
								new BingoItem("9"),
								new BingoItem("10"),
								new BingoItem("11"),
								new BingoItem("12"),
								new BingoItem("13"),
								new BingoItem("14"),
								new BingoItem("15"),
								new BingoItem("16"),
								new BingoItem("17"),
								new BingoItem("18"),
								new BingoItem("19"),
								new BingoItem("20"),
								new BingoItem("21"),
								new BingoItem("22"),
								new BingoItem("23"),
								new BingoItem("24"),
								new BingoItem("25"),
						};
						this.BingoItems.NumOfLine = 5;
				}

				public void OnLoaded(IViewable view)
				{

				}

				[RelayCommand]
				private void Goal(string goalCount)
				{
						if (String.IsNullOrWhiteSpace (goalCount))
								return;

						this.BingoItems.Goal = Convert.ToInt32 (goalCount);
				}
		}
}
