using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Model
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Titulo deve ter no máximo 50 caracteres")]
        [MinLength(5, ErrorMessage = "Titulo deve ter no minimo 5 caracteres")]
        public string Title { get; set; } = string.Empty;

        public List<Product> products { get; set; }
    }
}
