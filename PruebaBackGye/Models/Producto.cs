using System.Text.Json.Serialization;

namespace PruebaBackGye.Models
{
    public class Producto
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del producto
        public string Descripcion { get; set; } // Descripción del producto
        public decimal Precio { get; set; } // Precio del producto
        public int CategoriaId { get; set; } // Clave foránea de Categoría
        [JsonIgnore]
        public Categoria Categoria { get; set; } // Navegación a la categoría
    }
}
