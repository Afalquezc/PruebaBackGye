using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBackGye.Models;
using PruebaBackGye.Repository.dbcontext;

namespace PruebaBackGye.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoDeseadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoDeseadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductoDeseado(int usuarioId, int productoId)
        {
            var productoDeseado = new ProductoDeseado { UsuarioId = usuarioId, ProductoId = productoId };
            _context.ProductosDeseados.Add(productoDeseado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductosDeseados), new { usuarioId }, productoDeseado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductoDeseado(int usuarioId, int productoId)
        {
            var productoDeseado = await _context.ProductosDeseados
        .FindAsync(usuarioId, productoId); // Usa ambos valores de la clave

            if (productoDeseado == null)
            {
                return NotFound();
            }

            _context.ProductosDeseados.Remove(productoDeseado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosDeseados(int usuarioId)
        {
            var productosDeseados = await _context.ProductosDeseados
                .Where(pd => pd.UsuarioId == usuarioId)
                .Select(pd => pd.Producto)
                .ToListAsync();

            return productosDeseados;
        }
    }
}
