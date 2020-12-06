using NServiceBus.AttributeRouting.Contracts;

namespace NSBAttributeRouting.Sample.Messages
{
    [RouteTo("DomainOne")]
    public class PingHelloWordCommand
    {
        public string Name { get; set; }
    }
}
