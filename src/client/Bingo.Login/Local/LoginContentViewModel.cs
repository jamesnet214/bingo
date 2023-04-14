using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;

namespace Bingo.Login.Local
{
		public partial class LoginContentViewModel : ObservableBase, IViewLoadable
		{
				private readonly IRegionManager _regionManager;
				private readonly IContainerProvider _containerProvider;

				public LoginContentViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
				{
						this._regionManager = regionManager;
						this._containerProvider = containerProvider;
				}
				public void OnLoaded(IViewable smartWindow)
				{
				}

				[RelayCommand]
				private void Login()
				{
						IRegion mainRegion = _regionManager.Regions["MainRegion"];
						IViewable loginContent = _containerProvider.Resolve<IViewable> ("MainContent");

						if (!mainRegion.Views.Contains (loginContent))
						{
								mainRegion.Add (loginContent);
						}
						mainRegion.Activate (loginContent);
				}
		}
}
