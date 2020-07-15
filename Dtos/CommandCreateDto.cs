using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos{

public class CommandCreateDto 
    {
        //https://www.youtube.com/watch?v=fmvcAzHpsk8&t=7408s 
        // The Id field is taken out becouse is created in the DB side. 
        // So we don't need to provide it.
         [Required] // Exceprt from a stack trace we give user error rather than a interna server error.
         [MaxLength(250)]
        public string  Howto {get; set;}
         [Required]
        public string  Line {get;set;}
         [Required]

        public string Platform {get; set;}
    }

}