using System.ComponentModel.DataAnnotations;

namespace Views.ViewModels;

public class ProfileViewModel
{
    [Required, StringLength(50)]
    public string Name { get; set; } = "";

    [Required, EmailAddress]
    public string Email { get; set; } = "";
}
