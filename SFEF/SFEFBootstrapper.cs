using Caliburn.Micro;
using Ninject;
using Ninject.Extensions.Conventions;
using SFEF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SFEF
{
    class SFEFBootstrapper : BootstrapperBase
    {
        private IKernel kernel;

        public SFEFBootstrapper()
        {
            kernel = new StandardKernel();

            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindAllInterfaces();
            });

            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllInterfaces()
                 .EndingWith("Factory")
                 .BindToFactory();
            });

            Initialize();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null)
                throw new ArgumentNullException("Service");

            return kernel.Get(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            kernel.Inject(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }
    }
}
