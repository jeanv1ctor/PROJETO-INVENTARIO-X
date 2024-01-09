using System.ComponentModel.DataAnnotations;

namespace Api_Inventario.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Quantidade minima de caracteres para o nome do usuario = 5")]
        [MaxLength(30, ErrorMessage = "Quantidade maxima de caracteres  para o nome do usuario  = 30")]
        public string Nome { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Quantidade minima de caracteres para email = 5")]
        [MaxLength(100, ErrorMessage = "Quantidade maxima de caracteres  para email = 100")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
