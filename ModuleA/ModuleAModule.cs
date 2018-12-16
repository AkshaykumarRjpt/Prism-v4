using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismDemo.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManger;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManger)
        {
            this._container = container;
            this._regionManger = regionManger;
        }

        public void Initialize()
        {
            IRegion region = _regionManger.Regions[RegionNames.ToolBarRegion];
            region.Add(_container.Resolve<TabViewControl>());
            region.Add(_container.Resolve<TabViewControl>());
            region.Add(_container.Resolve<TabViewControl>());
            region.Add(_container.Resolve<TabViewControl>());
            region.Add(_container.Resolve<TabViewControl>());
            //_regionManger.RegisterViewWithRegion(RegionNames.ToolBarRegion,typeof(TabViewControl));
            _regionManger.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
