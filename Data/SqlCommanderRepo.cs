using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data{

public class SqlCommanderRepo: ICommanderRepo{

        private readonly CommanderContext _context;

        public   SqlCommanderRepo(CommanderContext context) 
        {
            _context = context; 
        }

        public void CommandDelete(Command cmd)
        {
            // Check that the Command we going to delete 
            // exist in our repository. 

           if(cmd == null ){

                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);

        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null ){

                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands(){
            return _context.Commands.ToList();
         }
        public Command GetCommandByID (int id){
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges() >= 0);
        }

        public void UpdateInfo (Command cmd){
            //Implementation of Updating a record that already excist in our DB 
            // Wil do nothin on thi instance as we do nor need to update from this class
            // instead  from the Commmand controller.  
        }
    }

}