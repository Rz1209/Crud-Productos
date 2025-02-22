// Usamos los espacios de nombres necesarios para trabajar con ASP.NET Core y Entity Framework.
using CRUD_Productos.Datos; //para acceder al contexto de la base de datos (ApplicationDbContext).
using CRUD_Productos.Modelos; //para acceder a los modelos de datos, como el modelo Producto.
using Microsoft.AspNetCore.Mvc; //para trabajar con Razor Pages y controladores de ASP.NET.
using Microsoft.AspNetCore.Mvc.RazorPages; //para trabajar con Razor Pages.
using Microsoft.EntityFrameworkCore; //para trabajar con Entity Framework Core, como ToListAsync().
using System.Threading.Tasks; //para trabajar con tareas asíncronas (await, async).

namespace CRUD_Productos.Pages.Productos
{
 
    public class IndexModel : PageModel
    {
        // La siguiente línea declara una variable privada que será usada para interactuar
        // con la base de datos.
        // _context es una instancia del contexto de la base de datos (ApplicationDbContext).
        private readonly ApplicationDbContext _context;

        // Constructor de la clase, donde se realiza la inyección de dependencias.
        // Al recibir el ApplicationDbContext, podemos usar _context para interactuar
        // con la base de datos.
        public IndexModel(ApplicationDbContext context) // El parámetro 'context' es el contexto de la base de datos.
        {
            _context = context; // Asignamos el contexto a la variable privada _context.
        }

        // Propiedad pública que almacenará la lista de productos que se obtendrán
        // de la base de datos.
        public IList<Producto> productos { get; set; } // Lista de productos que será usada en la vista.

        // El método OnGet se ejecuta cuando el usuario realiza una solicitud HTTP GET a esta página.
        public async Task OnGet()
        {
            // Aquí realizamos una consulta asincrónica a la base de datos para obtener todos
            // los productos.
            // _context.Producto hace referencia a la tabla de productos en la base de datos.
            // ToListAsync() convierte la consulta en una lista de objetos 'Producto'
            // de manera asincrónica.
            productos = await _context.Producto.ToListAsync(); // Asignamos la lista de productos a la propiedad 'productos'.
        }
    }
}
