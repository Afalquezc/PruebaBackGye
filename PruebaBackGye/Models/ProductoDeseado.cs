namespace PruebaBackGye.Models
{
    public class ProductoDeseado
    {
        public int Id { get; set; } // Identificador único
        public int UsuarioId { get; set; } // Clave foránea de Usuario
        public int ProductoId { get; set; } // Clave foránea de Producto
        public Usuario Usuario { get; set; } // Navegación al usuario
        public Producto Producto { get; set; } // Navegación al producto
    }
}
