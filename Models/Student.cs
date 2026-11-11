using System.ComponentModel.DataAnnotations;

namespace Views.Models;

public class Student
{
    [Required, StringLength(50)]
    public string Name { get; set; } = "";

    [Required, EmailAddress]
    public string Email { get; set; } = "";

    [Required, Phone]
    public string Phone { get; set; } = "";
}
