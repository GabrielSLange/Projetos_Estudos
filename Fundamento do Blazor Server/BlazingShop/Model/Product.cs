using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Model
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Titulo deve ter no máximo 150 caracteres")]
        [MinLength(5, ErrorMessage = "Titulo deve ter no minimo 5 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        [Range(1, 9999, ErrorMessage = "O preço deve estar entre 1 e 9999")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        [Range(1, 9999, ErrorMessage = "A categoria deve estar entre 1 e 9999")]
        public int CategoryId { get; set; }

        public Category category { get; set; } = null!;
    }
}
