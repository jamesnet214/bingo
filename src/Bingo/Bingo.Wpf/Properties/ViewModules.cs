using Bingo.Forms.Local.ViewModels;
using Bingo.Forms.UI.Views;
using Bingo.Main.UI.Views;
using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Wpf.Properties
{
    internal class ViewModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, MainContent>("MainContent");
        }
    }
}
