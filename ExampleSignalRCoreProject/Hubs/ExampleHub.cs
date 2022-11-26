using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Microsoft.AspNetCore.SignalR;

namespace ExampleSignalRCoreProject.Hubs
{
    public class ExampleHub : Hub<IExampleHubResponses>
    {
        private readonly Db _db;

        public ExampleHub(Db db)
        {
            _db = db;
        }

        public async override Task OnConnectedAsync()
        {
            await Clients.All.NotifyAboutSomethingElse();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.NotifyAboutSomething("Test topic", "Test content");
        }

        public async Task AddNoteWithLoremIpsumAsContentToDb()
        {
            _db.Note.Add(new Note()
            {
               Content = "Lorem Ipsum",
            });

            await _db.SaveChangesAsync();
        }

        public async Task NotifyAboutSomethingElseAllExcept()
        {
            var excludedConnectionIds = new List<string> { };
            await Clients.AllExcept(excludedConnectionIds.AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyCallerAboutSomethingElse()
        {
            await Clients.Caller.NotifyAboutSomethingElse();
        }

        public async Task NotifyClientAboutSomethingElse()
        {
            await Clients.Client(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyClientsAboutSomethingElse()
        {
            var excludedConnectionIds = new List<string> { };
            await Clients.Clients(excludedConnectionIds).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupAboutSomethingElse()
        {
            await Clients.Group(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupExceptAboutSomethingElse()
        {
            await Clients.GroupExcept(string.Empty, new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyGroupsAboutSomethingElse()
        {
            await Clients.Groups(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public async Task NotifyOthersAboutSomethingElse()
        {
            await Clients.Others.NotifyAboutSomethingElse();
        }

        public async Task NotifyOthersInGroupAboutSomethingElse()
        {
            await Clients.OthersInGroup(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyUserAboutSomethingElse()
        {
            await Clients.User(string.Empty).NotifyAboutSomethingElse();
        }

        public async Task NotifyUsersAboutSomethingElse()
        {
            await Clients.Users(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void AddLoremAsKeyAndIpsumAsValueToContextItems()
        {
            Context.Items.Add("Lorem", "Ipsum");
        }

        public async Task AddSomebodyToGroup()
        {
            await Groups.AddToGroupAsync(string.Empty, string.Empty);
        }

        public async Task RemoveSomebodyFromGroup()
        {
            await Groups.RemoveFromGroupAsync(string.Empty, string.Empty);
        }
    }
}
