using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PrismDemo.Infrastucture
{
    public class StackPanalRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanalRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }           

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        regionTarget.Children.Add(item);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            // AllActiveRegion
            //SingleActiveRegion
            //Region
            return new AllActiveRegion();
        }
    }
}
