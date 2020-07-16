using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace  Commander.Profiles{

public class CommandsProfile: Profile
    {

            // Will map both objects as not found. 
            //  Make sure you add as public as it was not able to access it from the begining
             public CommandsProfile()
            {
                CreateMap<Command,CommandReadDto>(); 
                CreateMap<CommandCreateDto,Command>();
                CreateMap<CommandUpdateDto,Command>();
                CreateMap<Command,CommandUpdateDto>(); 
            }
           
    } 
}