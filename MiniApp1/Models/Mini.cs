using MiniApp1.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace MiniApp1.Models
{
    public class Mini
    {
        [Required]
        public int MiniId { get; set; }

        [Required]
        public string? Name { get; set; }

        
        public string? Category { get; set; }

        [Required]
        [MiniValidateSize]
        public int? Size { get; set; }      
        
        public string? Description { get; set; }       // ? specifies that Description is nullable

        [Required]
        public double? Price { get; set; }  
        
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? CharRace { get; set; }
        public string? CharClass { get; set; }
    }
}
