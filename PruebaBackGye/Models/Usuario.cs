namespace PruebaBackGye.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del usuario
        public ICollection<ProductoDeseado> ProductosDeseados { get; set; } // Relación con Productos Deseados
    }
}
