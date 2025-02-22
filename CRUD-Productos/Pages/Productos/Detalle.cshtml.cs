using CRUD_Productos.Datos;
using CRUD_Productos.Modelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Productos.Pages.Productos
{
    public class DetalleModel : PageModel
    {
        
        private ApplicationDbContext _context;

        public DetalleModel(ApplicationDbContext context)
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
    }
}
