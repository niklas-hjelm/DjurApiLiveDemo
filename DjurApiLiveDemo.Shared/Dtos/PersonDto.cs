using System.ComponentModel.DataAnnotations;

namespace DjurApiLiveDemo.Shared.Dtos;

public class PersonDto
{
    [Required, StringLength(15, MinimumLength = 2)]
    public string Name { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
}