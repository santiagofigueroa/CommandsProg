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
        // Gets the name of the command we are going to use to return the newly created  
        // Command URL
        [HttpGet("{id}", Name = "GetCommandByID")]
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
         [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand (CommandCreateDto commandCreateDto)
        {
            // Implementing mapping from the DTO to the model 
            var commandModel  = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            //  We need to call this method as it will save the parse object to the DB.
            _repository.SaveChanges();

            // Here we are doing the opposite from the Model to the DTO, and we using the
            // The command read DTO model to read our data using the URL that will be created.
            // NOTE: As the create does not contain an ID attribute we need to provided with the
            // Read DTO class.
            var commandReadDto  = _mapper.Map<CommandReadDto>(commandModel);

            // We creating the model on route this will ma
            return CreatedAtRoute(nameof(GetCommandByID),new {Id = commandReadDto.Id},commandReadDto);
            //return Ok(commandModel);

        }




    }

 

}