namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class libros
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string url_imagen { get; set; }
        public int id_autor { get; set; } // Nombre exacto como en la BD
        public int id_categoria { get; set; }
        public decimal precio { get; set; }
        public char estado { get; set; }

        public autores Autor { get; set; } // Para la relación
    }
}
