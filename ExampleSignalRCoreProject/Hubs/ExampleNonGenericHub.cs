using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

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
            await Clients.AllExcept(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
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
            await Clients.Client(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupAboutSomething()
        {
            await Clients.Group(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyGrgoupExceptAboutSomething()
        {
            await Clients.GroupExcept(string.Empty, new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
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
            await Clients.OthersInGroup(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUserAboutSomething()
        {
            await Clients.User(string.Empty).SendAsync(NotifyUserAboutSomethingResponse);
        }

        public async Task NotifyUsersAboutSomething()
        {
            await Clients.Users(new List<string>().AsReadOnly()).SendAsync(NotifyUserAboutSomethingResponse);
        }
    }
}
