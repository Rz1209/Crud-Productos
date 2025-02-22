using CRUD_Productos.Datos;
using CRUD_Productos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CRUD_Productos.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto{ get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);

            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Similar al OnPostAsync() de Crear
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Producto.FechaCreacion = DateTime.Now; // Actualiza la fecha

            _context.Attach(Producto).State = EntityState.Modified; // Marca como modificado

            try
            {
                await _context.SaveChangesAsync(); // Guarda cambios en la BD
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExiste(Producto.Id))
                {
                    return NotFound(); // Producto no existe
                }
                else
                {
                    throw; // Otro error: lo lanza para que lo manejes o lo veas
                }
            }
            return RedirectToPage("Index"); // Redirige a la lista de productos
        }

        private bool ProductoExiste(int id)
        {
            return _context.Producto.Any(p => p.Id== id);
        }
    }
}
