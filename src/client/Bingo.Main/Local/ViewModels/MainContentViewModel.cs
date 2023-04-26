using Bingo.Core.Events;
using Bingo.Core.Models;
using Bingo.Main.Local.Event;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Xml.Linq;

namespace Bingo.Main.Local.ViewModels
{
		public partial class MainContentViewModel : ObservableBase, IViewLoadable
		{
				[ObservableProperty]
				ObservableCollection<BingoItem> serverData;
				[ObservableProperty]
				private BingoItemCollection bingoItems;
				private readonly IEventAggregator _ea;

				public MainContentViewModel(IEventAggregator ea)
				{
						this.BingoItems = new ()
						{
								new BingoItem(1),
								new BingoItem(2),
								new BingoItem(3),
								new BingoItem(4),
								new BingoItem(5),
								new BingoItem(6),
								new BingoItem(7),
								new BingoItem(8),
								new BingoItem(9),
								new BingoItem(10),
								new BingoItem(11),
								new BingoItem(12),
								new BingoItem(13),
								new BingoItem(14),
								new BingoItem(15),
								new BingoItem(16),
								new BingoItem(17),
								new BingoItem(18),
								new BingoItem(19),
								new BingoItem(20),
								new BingoItem(21),
								new BingoItem(22),
								new BingoItem(23),
								new BingoItem(24),
								new BingoItem(25),
						};
						this.BingoItems.NumOfLine = 5;

						TestData ();
						this._ea = ea;
						this._ea.GetEvent<RecvDataEvent> ().Subscribe ((e) =>
						{
								var item = this.BingoItems.FirstOrDefault (x => x.Name == e);
								if (item == null)
										return;
								item.IsChecked = true;

								this.BingoItems.Update ();
								if(this.BingoItems.IsBingo)
								{
										Console.WriteLine ("빙고");
								}
						});
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
				/// <summary>
				/// 서버 데이터 테이블 -> 클라이언트 데이터 테이블만 이동가능
				/// </summary>
				/// <param name="args"></param>
				[RelayCommand]
				private void Drop(BingoEventArgs args)
				{
						var TargetObj = args.TargetItem;
						var DropObj = args.DropItem;

						this.ServerData.Remove (DropObj);
						if (String.IsNullOrEmpty (TargetObj.Name))
						{
								var data = this.BingoItems.ToList ().Find (x => x.idx == TargetObj.idx);
								data.Name = DropObj.Name;
								return;
						}
						this.ServerData.Add (new BingoItem(TargetObj.idx, TargetObj.Name));
						this.BingoItems.FirstOrDefault (x => x.Name == TargetObj.Name).Name = DropObj.Name;
				}

				#region TEST
				private void TestData()
				{
						this.ServerData = new ();

						for(int i=1; i<=50; i++)
						{
								this.ServerData.Add (new BingoItem(i, i.ToString()));
						}
				}

				[ObservableProperty]
				private string recvdata;

				[RelayCommand]
				private void TestString(string data)
				{
						this._ea.GetEvent<RecvDataEvent> ().Publish (data);
						this.Recvdata = null;
				}
				#endregion
		}
}
