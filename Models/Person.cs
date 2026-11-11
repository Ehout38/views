using System.ComponentModel.DataAnnotations;

namespace Views.Models;

public class Person
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = "";

    [Range(1, 120)]
    public int Age { get; set; } = 18;
}
