using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace  Commander.Profiles{

public class CommandsProfile: Profile
    {

            // Will map both objects as not found. 
             CommandsProfile()
            {
                CreateMap<Command,CommandReadDto>(); 
            }
           
    } 
}