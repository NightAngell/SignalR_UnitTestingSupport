using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ExampleSignalRCoreProject.Services
{
    public class ServiceWhichUseIHubContext
    {
        private const string NotifyUserAboutSomethingResponse = ExampleNonGenericHub.NotifyUserAboutSomethingResponse;
        private readonly IHubContext<ExampleNonGenericHub> _exampleHub;

        public ServiceWhichUseIHubContext(IHubContext<ExampleNonGenericHub> exampleHub)
        {
            _exampleHub = exampleHub;
        }

        public async Task NotifyAllAboutSomething()
        {
            await _exampleHub.Clients.All.SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyAllExceptAboutSomething()
        {
            await _exampleHub.Clients.AllExcept(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientsAboutSomething()
        {
            await _exampleHub.Clients.Clients(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientAboutSomething()
        {
            await _exampleHub.Clients.Client(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupAboutSomething()
        {
            await _exampleHub.Clients.Group(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupExceptAboutSomething()
        {
            await _exampleHub.Clients.GroupExcept(string.Empty, new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGroupsAboutSomething()
        {
            await _exampleHub.Clients.Groups(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUserAboutSomething()
        {
            await _exampleHub.Clients.User(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUsersAboutSomething()
        {
            await _exampleHub.Clients.Users(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }
    }
}
