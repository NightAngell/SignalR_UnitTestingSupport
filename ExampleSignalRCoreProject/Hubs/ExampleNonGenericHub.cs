using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs
{
    public class ExampleNonGenericHub : Hub
    {
        public const string NotifyUserAboutSomethingResponse = "NotifyUserAboutSomething";

        public async Task NotifyAllAboutSomething()
        {
            await Clients.All.SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyAllExceptAboutSomething()
        {
            await Clients.AllExcept("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyCallerAboutSomething()
        {
            await Clients.Caller.SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientsAboutSomething()
        {
            await Clients.Clients(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyClientAboutSomething()
        {
            await Clients.Client("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupAboutSomething()
        {
            await Clients.Group("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupExceptAboutSomething()
        {
            await Clients.GroupExcept("", new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGroupsAboutSomething()
        {
            await Clients.Groups(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyOthersAboutSomething()
        {
            await Clients.Others.SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyOthersInGroupAboutSomething()
        {
            await Clients.OthersInGroup("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUserAboutSomething()
        {
            await Clients.User("").SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUsersAboutSomething()
        {
            await Clients.Users(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }
    }
}
