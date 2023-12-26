using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Api_Inventario.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CodPatrimonio {get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Quantidade minima de caracteres para o nome do item = 5")]
        [MaxLength(30, ErrorMessage = "Quantidade maxima de caracteres  para o nome do item  = 20")]
        public string? Nome { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Quantidade minima de caracteres para o modelo = 2")]
        [MaxLength(20, ErrorMessage = "Quantidade maxima de caracteres para o modelo = 20")]
        public string? Modelo {get; set;}

        [Required]
        [MinLength(5, ErrorMessage = "Quantidade minima de caracteres para a descrição do item  = 5")]
        [MaxLength(20, ErrorMessage = "Quantidade maxima de caracteres para a descrição do item = 20")]
        public string? Descricao { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
