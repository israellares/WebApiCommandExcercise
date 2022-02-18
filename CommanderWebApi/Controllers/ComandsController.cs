using AutoMapper;
using CommanderWebApi.Data;
using CommanderWebApi.DTOS;
using CommanderWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CommanderWebApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class ComandsController : ControllerBase
    {
        private readonly ICommanderRepository _commanderRepository;
        private readonly IMapper _autoMapper;

        public ComandsController(ICommanderRepository commanderRepository, IMapper autoMapper)
        {
            _commanderRepository = commanderRepository;
            _autoMapper = autoMapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommanderReaderDTO>> GetAllCommands()
        {
            var listOfCommands =   _commanderRepository.GetCommands();
            
            if (listOfCommands != null)
            {
                return Ok(_autoMapper.Map<IEnumerable<CommanderReaderDTO>>(listOfCommands));
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public ActionResult<CommanderReaderDTO> GetCommandById(int id)
        {
            var command = _commanderRepository.GetCommand(id);

            if (command != null)
            {
                return Ok(_autoMapper.Map<CommanderReaderDTO>(command));
            }
            return NotFound();
        }
        [HttpPost]
        public  ActionResult CreateCommands(CreateCommandDTO createCommandDTO)
        {
            if (ModelState.IsValid)
            {
                var commandConvertedfromDto = _autoMapper.Map<Command>(createCommandDTO);
                var isCreated = _commanderRepository.CreateCommand(commandConvertedfromDto);

                if (isCreated)
                {
                    return CreatedAtRoute(nameof(CreateCommands), new { });
                }
            }
                
                return BadRequest();
           
                            
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CreateCommandDTO commandDTO)
        {
            var command = _commanderRepository.GetCommand(id);
            if (command == null)
            {
                return NotFound();
            }
            var modelMapped = _autoMapper.Map(commandDTO, command);
            _commanderRepository.UpdateCommand(modelMapped);
            return NoContent();

            
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _commanderRepository.GetCommand(id);
            if (command == null)
            {
                return NotFound();
            }
            _commanderRepository.DeleteCommand(id);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PatchCommand(int id, JsonPatchDocument<CreateCommandDTO> patchDocument)
        {
            try
            {
                var command = _commanderRepository.GetCommand(id);
                if (command == null)
                {
                    return NotFound();
                }
                var commandToPatch = _autoMapper.Map<CreateCommandDTO>(command);

                patchDocument.ApplyTo(commandToPatch, ModelState);
                if (!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                _autoMapper.Map(commandToPatch, command);
                _commanderRepository.PatchCommand(command);
                return Ok();
            }catch(Exception exception)
            {
                Console.WriteLine(exception.Message + " " + exception.InnerException);
                return null;
            }
            
        }

    }
}
