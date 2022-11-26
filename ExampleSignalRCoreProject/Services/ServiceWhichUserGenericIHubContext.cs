using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Hubs;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ExampleSignalRCoreProject.Services
{
    public class ServiceWhichUserGenericIHubContext
    {
        private readonly IHubContext<ExampleHub, IExampleHubResponses> _exampleHub;

        public ServiceWhichUserGenericIHubContext(IHubContext<ExampleHub, IExampleHubResponses> exampleHub)
        {
            _exampleHub = exampleHub;
        }

        public async Task NotifyAllAboutSomethingElse()
        {
            await _exampleHub.Clients.All.NotifyAboutSomethingElse();
        }

        public async Task NotifyAboutSomethingElseAllExcept()
        {
            var excludedConnectionIds = new List<string> { };
            await _exampleHub.Clients.AllExcept(excludedConnectionIds.AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyClientAboutSomethingElse()
        {
            await _exampleHub.Clients.Client(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyClientsAboutSomethingElse()
        {
            var excludedConnectionIds = new List<string> { };
            await _exampleHub.Clients.Clients(excludedConnectionIds).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupAboutSomethingElse()
        {
            await _exampleHub.Clients.Group(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupExceptAboutSomethingElse()
        {
            await _exampleHub.Clients.GroupExcept(string.Empty, new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupsAboutSomethingElse()
        {
            await _exampleHub.Clients.Groups(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyUserAboutSomethingElse()
        {
            await _exampleHub.Clients.User(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyUsersAboutSomethingElse()
        {
            await _exampleHub.Clients.Users(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public Task<string> GetMessageFromClient()
        {
            return _exampleHub.Clients.Client(string.Empty).GetMessage();
        }
    }
}
