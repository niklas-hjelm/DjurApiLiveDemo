using System.ComponentModel.DataAnnotations;

namespace DjurApiLiveDemo.Common.DTOs;

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Phone]
    public string Phone { get; set; }
    public List<PetDto> Pets { get; set; }
}