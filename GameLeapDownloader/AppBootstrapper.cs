using Caliburn.Micro;
using GameLeapDownloader.ViewModels;
using System;
using System.Collections.Generic;

namespace GameLeapDownloader
{
    class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<DashboardViewModel>();
            container.Singleton<DownloaderViewModel>();


        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<DashboardViewModel>();   
        }
    }
}
