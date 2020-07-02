using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using System.Collections.Generic;
namespace Commander.Controllers
{ 
    //  Will look for the  API we need   
    [Route("api/commands")] 
    [ApiController]
    public class CommandsController : ControllerBase {

        private readonly ICommanderRepo _repository;
        // Dependy  injection the parameter in the Ctor 
        // Make sure the file is the same name as the class
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        // private readonly MockCommandRepo _repository = new MockCommandRepo();
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands(){
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }
        // Get request will respond to this URI
        // The id number will change from 1  to a as many items we have in the commands 
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandByID(int id){
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1 
            var commandItems = _repository.GetCommandByID(id);

            return Ok(commandItems);
        }

    }



}