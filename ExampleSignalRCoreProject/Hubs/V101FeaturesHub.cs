using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ExampleSignalRCoreProject.Hubs
{
    public class V101FeaturesHub : Hub
    {
        public void UseContextConnIdTwice()
        {
            var x = Context.ConnectionId;
            var y = Context.ConnectionId;
        }

        public async Task AddUserToGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, string.Empty);
        }

        public async Task RemoveUserFromGroupByConnIdGroup()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, string.Empty);
        }
    }
}
