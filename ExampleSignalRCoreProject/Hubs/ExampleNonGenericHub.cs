using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs
{
    public class ExampleNonGenericHub : Hub
    {
        public async Task NotifyAllAboutSomething()
        {
            await Clients.All.SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyAllExceptAboutSomething()
        {
            await Clients.AllExcept("").SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyCallerAboutSomething()
        {
            await Clients.Caller.SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyClientsAboutSomething()
        {
            await Clients.Clients(new List<string>().AsReadOnly()).SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyClientAboutSomething()
        {
            await Clients.Client("").SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyGrgoupAboutSomething()
        {
            await Clients.Group("").SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyGrgoupExceptAboutSomething()
        {
            await Clients.GroupExcept("", new List<string>().AsReadOnly()).SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyGroupsAboutSomething()
        {
            await Clients.Groups(new List<string>().AsReadOnly()).SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyOthersAboutSomething()
        {
            await Clients.Others.SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyOthersInGroupAboutSomething()
        {
            await Clients.OthersInGroup("").SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyUserAboutSomething()
        {
            await Clients.User("").SendAsync("NotifyUserAboutSomething");
        }

        public async Task NotifyUsersAboutSomething()
        {
            await Clients.Users(new List<string>().AsReadOnly()).SendAsync("NotifyUserAboutSomething");
        }
    }
}
