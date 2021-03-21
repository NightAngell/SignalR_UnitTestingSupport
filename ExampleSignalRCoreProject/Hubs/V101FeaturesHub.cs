using Microsoft.AspNetCore.SignalR;

namespace ExampleSignalRCoreProject.Hubs
{
    public class V101FeaturesHub : Hub
    {
        public void UseContextConnIdTwice()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var x = Context.ConnectionId;
            var y = Context.ConnectionId;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }

        public void AddUserToGroup()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, string.Empty);
        }

        public void RemoveUserFromGroupByConnIdGroup()
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, string.Empty);
        }
    }
}
