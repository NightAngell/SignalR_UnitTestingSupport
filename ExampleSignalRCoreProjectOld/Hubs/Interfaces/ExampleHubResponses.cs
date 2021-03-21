using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs.Interfaces
{
    public interface ExampleHubResponses
    {
        Task NotifyAboutSomething(string topic, string content);
        Task NotifyAboutSomethingElse();
    }
}
