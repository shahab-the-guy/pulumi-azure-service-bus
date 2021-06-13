using Pulumi;
using Pulumi.AzureNative.Resources;

namespace PulumiAzureServiceBusSample
{
    internal class MyStack : Stack
    {
        public MyStack()
        {
            // Create an Azure Resource Group
            var resourceGroup = new ResourceGroup("rg-pulumi-sample");

            ServiceBus.CreateResources(resourceGroup);
        }
    }
}
