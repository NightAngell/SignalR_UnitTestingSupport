using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs
{
    public class ExampleHub : Hub<ExampleHubResponses>
    {
        readonly Db _db;

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
            _db.Note.Add(new Note() {
               Content = "Lorem Ipsum"
            });

            await _db.SaveChangesAsync();
        }

        public void NotifyAboutSomethingElseAllExcept()
        {
            var excludedConnectionIds = new List<string> {};
            Clients.AllExcept(excludedConnectionIds.AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyCallerAboutSomethingElse()
        {
            Clients.Caller.NotifyAboutSomethingElse();
        }

        public void NotifyClientAboutSomethingElse()
        {
            Clients.Client("").NotifyAboutSomethingElse();
        }

        public void NotifyClientsAboutSomethingElse()
        {
            var excludedConnectionIds = new List<string> { };
            Clients.Clients(excludedConnectionIds).NotifyAboutSomethingElse();
        }

        public void NotifyGroupAboutSomethingElse()
        {
            Clients.Group("").NotifyAboutSomethingElse();
        }

        public void NotifyGroupExceptAboutSomethingElse()
        {
            Clients.GroupExcept("", new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyGroupsAboutSomethingElse()
        {
            Clients.Groups(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void NotifyOthersAboutSomethingElse()
        {
            Clients.Others.NotifyAboutSomethingElse();
        }

        public void NotifyOthersInGroupAboutSomethingElse()
        {
            Clients.OthersInGroup("").NotifyAboutSomethingElse();
        }

        public void NotifyUserAboutSomethingElse()
        {
            Clients.User("").NotifyAboutSomethingElse();
        }

        public void NotifyUsersAboutSomethingElse()
        {
            Clients.Users(new List<string>().AsReadOnly()).NotifyAboutSomethingElse();
        }

        public void AddLoremAsKeyAndIpsumAsValueToContextItems()
        {
            Context.Items.Add("Lorem", "Ipsum");
        }

        public void AddSomebodyToGroup()
        {
            Groups.AddToGroupAsync("", "");
        }

        public void RemoveSomebodyFromGroup()
        {
            Groups.RemoveFromGroupAsync("", "");
        }

    }
}
