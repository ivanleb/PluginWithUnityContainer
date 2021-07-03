using CommonServiceLocator;
using Sample.UnityPlugin.Contracts;
using System;

namespace Sample.UnityPlugin.Cocoa
{
    public class Provider : IProvider
    {
        private readonly Lazy<IService> _serviceContainer = new Lazy<IService>(() => ServiceLocator.Current.GetInstance<IService>());
        public Provider(string providerName)
        {
            this.Name = providerName;
        }

        public object Connection { get; set; }

        public string Name { get; set; }

        public void DoAction()
        {
            IService service = _serviceContainer.Value;
            service.Do("Hello, world!");
        }
    }
}