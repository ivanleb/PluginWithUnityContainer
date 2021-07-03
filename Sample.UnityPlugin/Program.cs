using CommonServiceLocator;
using Microsoft.Practices.Unity.Configuration;
using Sample.UnityPlugin.Contracts;
using System.Configuration;
using Unity;
using Unity.ServiceLocation;

namespace Sample.UnityPlugin
{
    class Program
    {
        private static IUnityContainer GetContainer()
        {
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = "unity.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IService, ServiceImpl>();
            section.Configure(container);
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            return container;
        }

        static void Main(string[] args)
        {
            IUnityContainer container = GetContainer();
            var myProvider = container.Resolve<IProvider>();
            System.Console.WriteLine("Provider Name:{0}", myProvider.Name);
            myProvider.DoAction();
            System.Console.ReadKey();
        }
    }
}