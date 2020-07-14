namespace Commander.Dtos{

public class CommandCreateDto 
    {
        // The Id field is taken out becouse is created in the DB side. 
        // So we don't need to provide it.
        public string  Howto {get; set;}
        public string  Line {get;set;}

        public string Platform {get; set;}
    }

}