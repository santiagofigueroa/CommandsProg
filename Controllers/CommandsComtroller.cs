using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using System.Collections.Generic;
using AutoMapper;
using Commander.Dtos;

namespace Commander.Controllers
{ 
    //  Will look for the  API we need   
    [Route("api/commands")] 
    [ApiController]
    public class CommandsController : ControllerBase {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        // Dependy  injection the parameter in the Ctor 
        // Make sure the file is the same name as the class
        // Included I Mapper for DTO implememtation. 

        public CommandsController(ICommanderRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands(){
            var commandItems = _repository.GetAllCommands();
            // OK method so we only return a 200 status. 
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        // Get request will respond to this URI
        // The id number will change from 1  to a as many items we have in the commands 
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandByID(int id){
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1 
            var commandItems = _repository.GetCommandByID(id);
            if(commandItems != null){
                return Ok(_mapper.Map<CommandReadDto>(commandItems));
            } 
            // There is no need to add the item in the method. 
            return NotFound();
        }

        //POST api/commands 
         



    }

 

}