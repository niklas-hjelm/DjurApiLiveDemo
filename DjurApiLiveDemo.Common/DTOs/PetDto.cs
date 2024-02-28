using System;

namespace DjurApiLiveDemo.Common.DTOs;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Type { get; set; }
    public List< PersonDto> People { get; set; }
}