using ExampleSignalRCoreProject.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Services
{
    public class ServiceWhichUseIHubContext
    {
        IHubContext<ExampleNonGenericHub> _exampleHub;

        public ServiceWhichUseIHubContext(IHubContext<ExampleNonGenericHub> exampleHub)
        {
            _exampleHub = exampleHub;
        }

        public void DoSomething()
        {
            //_exampleHub
        }
    }
}
