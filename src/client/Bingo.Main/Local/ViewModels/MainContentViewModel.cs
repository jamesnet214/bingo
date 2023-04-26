using Bingo.Core.Models;
using Bingo.Main.Local.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Bingo.Main.Local.ViewModels
{
		public partial class MainContentViewModel : ObservableBase, IViewLoadable
		{
				[ObservableProperty]
				ObservableCollection<BingoItem> serverData;
				[ObservableProperty]
				private BingoItemCollection bingoItems;
				public MainContentViewModel()
				{
						this.BingoItems = new ()
						{
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
								new BingoItem(),
						};
						this.BingoItems.NumOfLine = 5;

						TestData ();
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

				private void TestData()
				{
						this.ServerData = new ();

						for(int i=1; i<=50; i++)
						{
								this.ServerData.Add (new BingoItem(i.ToString()));
						}
				}

				/// <summary>
				/// 서버 데이터 테이블 -> 클라이언트 데이터 테이블만 이동가능
				/// </summary>
				/// <param name="args"></param>
				[RelayCommand]
				private void Drop(BingoEventArgs args)
				{
						var TargetObj = args.TargetItem;
						var DropObj = args.DropItem;

						if(String.IsNullOrEmpty(TargetObj.Name))
						{
								this.ServerData.Remove (DropObj);
								return;
						}
						this.ServerData.Add (TargetObj);
				}
		}
}
