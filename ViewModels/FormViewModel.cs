using System.ComponentModel.DataAnnotations;

namespace Views.ViewModels;

public class FormViewModel
{
    [Required, StringLength(30)]
    public string Login { get; set; } = "";

    [Required, StringLength(100, MinimumLength = 6), DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Range(13, 120)]
    public int Age { get; set; } = 18;

    [StringLength(500)]
    public string? Comment { get; set; }

    public bool IsMarried { get; set; }

    [Required, RegularExpression("^(red|blue|green)$")]
    public string Color { get; set; } = "green";

    [Required, RegularExpression("^(iPhone|Pixel|Galaxy)$")]
    public string Phone { get; set; } = "Pixel";

    [MinLength(1, ErrorMessage = "Select at least one phone.")]
    public string[] Phones { get; set; } = [];
}
