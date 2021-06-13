using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.ServiceBus;

namespace PulumiAzureServiceBusSample
{
    internal class MyStack : Stack
    {
        public MyStack()
        {
            // Create an Azure Resource Group
            var resourceGroup = new ResourceGroup("rg-pulumi-sample");

            var serviceBusNamespace = new Namespace("sbns-pulumi-sample",
                new NamespaceArgs
                {
                    ResourceGroupName = resourceGroup.Name
                });

            var topic = new Topic("sbt-pulumi-sample", new TopicArgs
            {
                ResourceGroupName = resourceGroup.Name,
                NamespaceName = serviceBusNamespace.Name,
            });

            var subscription = new Subscription("sbs-pulumi-sample", new SubscriptionArgs
            {
                ResourceGroupName = resourceGroup.Name,
                NamespaceName = serviceBusNamespace.Name,
                TopicName = topic.Name
            });
        }
    }
}
