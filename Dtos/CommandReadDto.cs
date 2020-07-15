using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    /* 
    * Class to handle the DTO object. 
    * Completed our  DTO (Database object) 
    */
    public class CommandReadDto 
    {
         [Required]
        public int Id {get;set; }
         [Required]
        public string  Howto {get; set;}
         [Required]
        public string  Line {get;set;}
    }
}