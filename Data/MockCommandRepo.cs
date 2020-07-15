using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    
    public class MockCommanderRepo : ICommanderRepo

    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> 
            {
              new Command{Id = 1, Line = "Boil an egg ",Platform ="Kettle and pand "},
              new Command{Id = 2, Line = "Cut bread",Platform ="Cutting board"},
              new Command{Id = 3, Line = "Toast" , Platform ="Pore water  into cattle. "}
             };
             
            return commands;

        }

        public Command GetCommandByID(int id)
        {
            return new Command{Id = 0, Howto="How to : ", Line="Boil and egg ", Platform="Hot water"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Command> ICommanderRepo.GetAllCommands()
        {
            throw new System.NotImplementedException();
        }

        Command ICommanderRepo.GetCommandByID(int id)
        {
            throw new System.NotImplementedException();
        }

        bool ICommanderRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        void ICommanderRepo.UpdateInfo(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }




}