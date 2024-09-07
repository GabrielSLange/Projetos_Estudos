using System.ComponentModel.DataAnnotations;

namespace BaltinhaTest.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }
}
