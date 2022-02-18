using CommanderWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderWebApi.DbContextConnections
{
    public class CommanderDBContextcs : DbContext
    {
        public CommanderDBContextcs(DbContextOptions<CommanderDBContextcs> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Command> Commands  { get; set; }
    }
}
