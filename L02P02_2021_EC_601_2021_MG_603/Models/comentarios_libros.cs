using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string comentario { get; set; }

        [ForeignKey("libros")]
        public int libro_id { get; set; }

        public libros? libro { get; set; } 
    }
}
