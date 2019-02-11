using ExampleSignalRCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleSignalRCoreProject.Databases
{
    public class Db : DbContext
    {
        //We need constructor which take DbContextOptions<T> and pass it to base
        public Db(DbContextOptions<Db> options) : base (options){}

        public DbSet<Note> Note { get; set; }
    }
}
