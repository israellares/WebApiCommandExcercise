using CommanderWebApi.DTOS;
using CommanderWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderWebApi.Data
{
  public  interface ICommanderRepository
    {
        
        IEnumerable<Command> GetCommands();
        Command GetCommand(int id);

        bool CreateCommand(Command commandDTO);
        void UpdateCommand(Command command);
        void DeleteCommand(int id);
        void PatchCommand(Command command);



    }
}
