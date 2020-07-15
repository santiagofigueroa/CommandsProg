using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{

public class Command {
    //[key]
    public int Id {get;set; }
     // [MaxLength(250)]
    // JUst as an example
    [MaxLength(250)]
    [Required]
    public string  Howto {get; set;}
    [Required]
    public string  Line {get;set;}
    [Required]
    public string Platform {get;set;} 
}
}