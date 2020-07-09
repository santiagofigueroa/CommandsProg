using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace  Commander.Profiles{

public class CommandsController: Profile
    {

            // Will map both objects as not found. 
             CommandsController()
            {
                CreateMap<Command,CommandReadDto>(); 
            }

            public string getClassName (){ 

                return ""; 
            }
           
    } 
}