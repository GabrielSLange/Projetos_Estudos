using System.ComponentModel.DataAnnotations;

namespace blazorShop.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o título")]
        [MinLength(3, ErrorMessage = "A categoria deve ter no minimo 3 caracteres")]
        [MaxLength(60, ErrorMessage = "A categoria deve ter no máximo 60 caracteres")]
        public string title { get; set; } = string.Empty;
    }
}
