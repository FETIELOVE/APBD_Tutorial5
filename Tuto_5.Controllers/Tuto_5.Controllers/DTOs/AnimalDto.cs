using System.ComponentModel.DataAnnotations;
namespace Tuto_5.Controllers.DTOs;

public class AnimalDto
{
    [Required]
    public int Id { get; init; }
    
    [Required]
    public string?  Name { get; init; }
   
    [Required]
    public string? Description { get; init; }
    [Required]
    public string? Category { get; init; }
    [Required]
    public string? Area{ get; init; }

}

  


