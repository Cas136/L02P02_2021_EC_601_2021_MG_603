using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class libros
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string titulo { get; set; }

        [ForeignKey("autores")]
        public int autor_id { get; set; }
        
        public autores? autor { get; set; } 
    }
}
