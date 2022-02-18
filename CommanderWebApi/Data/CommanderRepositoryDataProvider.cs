using CommanderWebApi.DbContextConnections;
using CommanderWebApi.DTOS;
using CommanderWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderWebApi.Data
{
    public class CommanderRepositoryDataProvider : ICommanderRepository
    {
        private readonly CommanderDBContextcs _dBContext;
        public CommanderRepositoryDataProvider(CommanderDBContextcs dBContext)
        {
            _dBContext = dBContext;

        }

        public bool CreateCommand(Command commandDTO)
        {
            try
            {
                _dBContext.Commands.Add(commandDTO);
                int lastId =_dBContext.SaveChanges();

                return lastId > 0 ? true : false;
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
                return false;
            }
            //return false;
        }

        public void DeleteCommand(int id)
        {
            try
            {
                _dBContext.Remove(_dBContext.Commands.Single(x => x.Id == id));
                _dBContext.SaveChanges();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message + exception.InnerException);
            }
        }

        public Command GetCommand(int id)
        {
            var command = _dBContext.Commands.FirstOrDefault(x => x.Id == id);
            return command;
        }

        public IEnumerable<Command> GetCommands()
        {
            var commands = _dBContext.Commands.ToList();
            return commands;
        }

        public void PatchCommand(Command command)
        {
            try
            {
                _dBContext.SaveChangesAsync();
            }catch(Exception exception)
            {
                Console.WriteLine(exception.Message + " " + exception.InnerException);
            }
        }

        public void UpdateCommand(Command command)
        {
            try
            {
                _dBContext.Commands.Update(command);
                _dBContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
