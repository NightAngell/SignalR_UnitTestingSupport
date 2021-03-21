using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs.Interfaces
{
    public interface IExampleHubResponses
    {
        Task NotifyAboutSomething(string topic, string content);
        Task NotifyAboutSomethingElse();
    }
}
