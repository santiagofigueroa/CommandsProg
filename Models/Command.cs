using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{

public class Command {
    public int Id {get;set; }
    [Required]
    // [MaxLength(250)]
    // JUst as an example 
    public string  Howto {get; set;}
    [Required]
    public string  Line {get;set;}
    [Required]
    public string Platform {get;set;} 
}
}