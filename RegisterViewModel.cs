using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    public string inputName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string inputPassword { get; set; }

    public string inputTitle { get; set; }
    public string inputAddress { get; set; }
    public string inputcontext { get; set; }

}