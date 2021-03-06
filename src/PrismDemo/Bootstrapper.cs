﻿using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;

using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using PrismDemo.Infrastucture;

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


        /* Loading module from the Directory use Directory module catalog*/
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    string path = new Uri(Environment.CurrentDirectory+@"\Modules",UriKind.Relative).ToString();
        //    return new DirectoryModuleCatalog() { ModulePath = @"./Modules" };
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/PrismDemo;component/XamlCatalog.xaml", UriKind.Relative));
        }

        //protected override void ConfigureModuleCatalog()
        //{
        //    Type moduletype = typeof(ModuleAModule);
        //    ModuleCatalog.AddModule(new ModuleInfo
        //    {
        //        ModuleName=moduletype.Name,
        //        ModuleType=moduletype.AssemblyQualifiedName,

        //        InitializationMode= InitializationMode.WhenAvailable
        //    });
        //}

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mapping =  base.ConfigureRegionAdapterMappings();
            mapping.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanalRegionAdapter>());
            return mapping;
        }
       
    }
}
