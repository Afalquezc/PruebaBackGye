using System.Text.Json.Serialization;

namespace PruebaBackGye.Models
{
    public class Categoria
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre de la categoría
        [JsonIgnore]
        public List<Producto> Productos { get; set; } // Navegación a los productos
    }
}
