using System.ComponentModel.DataAnnotations;

namespace blazorShop.Model
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o título")]
        [MinLength(3, ErrorMessage = "O produto deve ter no minimo 3 caracteres")]
        [MaxLength(120, ErrorMessage = "O produto deve ter no máximo 120 caracteres")]
        public string title { get; set; } = string.Empty;

        public string? description { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto")]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }

        public int categoryId { get; set; }
        public Category? category { get; set; } = null!;
    }
}
