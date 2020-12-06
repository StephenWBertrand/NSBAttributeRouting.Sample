using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace NSBAttributeRouting.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseNServiceBus(ConfigureNServiceBus)
                .ConfigureWebHostDefaults(c => c.UseStartup<Startup>());
        }

        private static EndpointConfiguration ConfigureNServiceBus(HostBuilderContext context)
        {
            //Basic Endpoint Config
            var endpointConfiguration = new EndpointConfiguration("HelloWorld");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            //endpointConfiguration.UseAttributeConventions();
            endpointConfiguration.Conventions().Add(new SuffixMessageConvention());
            endpointConfiguration.UseAttributeRouting();
            endpointConfiguration.SendOnly();
            endpointConfiguration.EnableInstallers();

            return endpointConfiguration;
        }
    }

    public class SuffixMessageConvention : IMessageConvention
    {
        public string Name { get; } = "Type name suffix";
        public bool IsCommandType(Type t) => t.FullName.EndsWith("Command");
        public bool IsEventType(Type t) => t.FullName.EndsWith("Event");
        public bool IsMessageType(Type t) => t.FullName.EndsWith("Message");
    }
}
