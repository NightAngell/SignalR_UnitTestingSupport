using ExampleSignalRCoreProject.Databases;
using ExampleSignalRCoreProject.Hubs.Interfaces;
using ExampleSignalRCoreProject.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Hubs
{
    public class ExampleHub : Hub<ExampleHubResponses>
    {
        Db _db;
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
    }
}
