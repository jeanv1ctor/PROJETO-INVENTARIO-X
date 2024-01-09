using System.ComponentModel.DataAnnotations;

namespace Api_Inventario.ViewModels.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Quantidade minima de caracteres para email = 5")]
        [MaxLength(100, ErrorMessage = "Quantidade maxima de caracteres  para email = 100")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
