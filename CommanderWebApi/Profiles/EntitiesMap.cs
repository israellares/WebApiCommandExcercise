using AutoMapper;
using CommanderWebApi.DTOS;
using CommanderWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CommanderWebApi.Profiles
{
    public class EntitiesMap : Profile
    {
        public EntitiesMap()
        {
            CreateMap<Command, CommanderReaderDTO>();
            CreateMap<CreateCommandDTO, Command>();
            CreateMap<Command, CreateCommandDTO>();
        }
        
    }
}
