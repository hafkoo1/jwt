using System.ComponentModel.DataAnnotations;

namespace WebApplication17.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Введіть логін")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}