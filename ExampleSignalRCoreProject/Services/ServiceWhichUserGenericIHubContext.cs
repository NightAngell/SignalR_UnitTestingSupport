using System.Collections.Generic;
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

        public void NotifyAllAboutSomethingElse()
        {
            _exampleHub.Clients.All.NotifyAboutSomethingElse();
        }

        public void NotifyAboutSomethingElseAllExcept()
        {
            var excludedConnectionIds = new List<string> { };
            _exampleHub.Clients.AllExcept(excludedConnectionIds.AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyClientAboutSomethingElse()
        {
            _exampleHub.Clients.Client(string.Empty).NotifyAboutSomethingElse();
        }

        public void NotifyClientsAboutSomethingElse()
        {
            var excludedConnectionIds = new List<string> { };
            _exampleHub.Clients.Clients(excludedConnectionIds).NotifyAboutSomethingElse();
        }

        public void NotifyGroupAboutSomethingElse()
        {
            _exampleHub.Clients.Group(string.Empty).NotifyAboutSomethingElse();
        }

        public void NotifyGroupExceptAboutSomethingElse()
        {
            _exampleHub.Clients.GroupExcept(string.Empty, new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyGroupsAboutSomethingElse()
        {
            _exampleHub.Clients.Groups(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyUserAboutSomethingElse()
        {
            _exampleHub.Clients.User(string.Empty).NotifyAboutSomethingElse();
        }

        public void NotifyUsersAboutSomethingElse()
        {
            _exampleHub.Clients.Users(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }
    }
}
