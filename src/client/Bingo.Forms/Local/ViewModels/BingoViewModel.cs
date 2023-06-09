﻿using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Forms.Local.ViewModels
{
    public class BingoViewModel : IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public BingoViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        public void OnLoaded(IViewable view)
        {
            IRegion mainRegion = _regionManager.Regions["MainRegion"];
            IViewable loginContent = _containerProvider.Resolve<IViewable>("LoginContent");

            if (!mainRegion.Views.Contains(loginContent))
            {
                mainRegion.Add(loginContent);
            }
            mainRegion.Activate(loginContent);
        }
    }
}
