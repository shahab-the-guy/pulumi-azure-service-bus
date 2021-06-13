using System.Threading.Tasks;
using Pulumi;
using PulumiAzureServiceBusSample;

class Program
{
    static Task<int> Main() => Deployment.RunAsync<MyStack>();
}
