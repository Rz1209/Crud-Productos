using CRUD_Productos.Datos;
using CRUD_Productos.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Productos.Pages.Productos
{
    public class BorrarModel : PageModel
    {
        private ApplicationDbContext _context { get; set; }

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var BorrarProducto = await _context.Producto.FindAsync(Producto.Id);
            if (Producto == null)
            {
                return NotFound();
            }

            if (BorrarProducto != null)
            {
                _context.Producto.Remove(BorrarProducto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index"); // Redirige a la lista de productos

        }
    }
}
