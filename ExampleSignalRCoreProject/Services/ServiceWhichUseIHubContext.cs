using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Services
{
    public class ServiceWhichUseIHubContext
    {
        private const string NotifyUserAboutSomethingResponse 
            = ExampleNonGenericHub.NotifyUserAboutSomethingResponse;
        IHubContext<ExampleNonGenericHub> _exampleHub;

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
            await _exampleHub.Clients.AllExcept("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientsAboutSomething()
        {
            await _exampleHub.Clients.Clients(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientAboutSomething()
        {
            await _exampleHub.Clients.Client("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupAboutSomething()
        {
            await _exampleHub.Clients.Group("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupExceptAboutSomething()
        {
            await _exampleHub.Clients.GroupExcept("", new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGroupsAboutSomething()
        {
            await _exampleHub.Clients.Groups(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUserAboutSomething()
        {
            await _exampleHub.Clients.User("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUsersAboutSomething()
        {
            await _exampleHub.Clients.Users(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

    }
}
