namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class comentarios_libros
    {
        public int id { get; set; }
        public int id_libro { get; set; } // Nombre exacto como en la BD
        public string comentarios { get; set; } // varchar(max) en BD
        public string usuario { get; set; }
        public DateTime created_at { get; set; }

        public libros Libros { get; set; } // Para la relación
    }
}
