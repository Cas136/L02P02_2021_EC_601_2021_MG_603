using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}
