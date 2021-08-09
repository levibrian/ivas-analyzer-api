using System.Reflection;
using Ivas.Analyzer.Injection.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ivas.Analyzer.Injection.Injector
{
    public static class ServiceInjector
    {
        public static ServiceProvider Configure(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            RegisterCoreServices(serviceDescriptors);

            RegisterNetworkingBrokers(serviceDescriptors);
            
            RegisterMapper(serviceDescriptors);
            
            return serviceDescriptors.BuildServiceProvider();
        }

        private static void RegisterCoreServices(IServiceCollection serviceDescriptors)
        {
            InjectionHelper.Register(serviceDescriptors, "Ivas.Analyzer.Core", "Service");
        }

        private static void RegisterNetworkingBrokers(IServiceCollection serviceDescriptors)
        {
            InjectionHelper.Register(serviceDescriptors, "Ivas.Analyzer.Networking", "Broker");
        }
        
        private static void RegisterMapper(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAutoMapper(Assembly.Load("Ivas.Analyzer.Core"));
        }
    }
}