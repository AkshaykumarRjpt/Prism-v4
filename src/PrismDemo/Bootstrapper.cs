using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using ModuleA;

namespace PrismDemo
{
    public class Bootstrapper  : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            Type moduletype = typeof(ModuleAModule);
            ModuleCatalog.AddModule(new ModuleInfo
            {
                ModuleName=moduletype.Name,
                ModuleType=moduletype.AssemblyQualifiedName,

                InitializationMode= InitializationMode.WhenAvailable
            });
        }

       
    }
}
