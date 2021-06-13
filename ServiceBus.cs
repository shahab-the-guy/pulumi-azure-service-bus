using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.ServiceBus;

namespace PulumiAzureServiceBusSample
{
    internal class ServiceBus
    {
        public static void CreateResources(ResourceGroup resourceGroup)
        {
            // Create an Azure Service Bus Namespace
            var serviceBusNamespace = new Namespace("sbns-pulumi-sample",
                new NamespaceArgs
                {
                    ResourceGroupName = resourceGroup.Name
                });

            // Create an Azure Service Bus Topic
            var topic = new Topic("sbt-pulumi-sample", new TopicArgs
            {
                ResourceGroupName = resourceGroup.Name,
                NamespaceName = serviceBusNamespace.Name,
            });

            // Create an Azure Service Bus Topic Subscription
            var subscription = new Subscription("sbs-pulumi-sample", new SubscriptionArgs
            {
                ResourceGroupName = resourceGroup.Name,
                NamespaceName = serviceBusNamespace.Name,
                TopicName = topic.Name
            });
        }
    }
}
