// Usamos los espacios de nombres necesarios para trabajar con ASP.NET Core y Entity Framework.
using CRUD_Productos.Datos; //para acceder al contexto de la base de datos (ApplicationDbContext).
using CRUD_Productos.Modelos; //para acceder a los modelos de datos, como el modelo Producto.
using Microsoft.AspNetCore.Mvc; //para trabajar con Razor Pages y controladores de ASP.NET.
using Microsoft.AspNetCore.Mvc.RazorPages; //para trabajar con Razor Pages.
using Microsoft.EntityFrameworkCore; //para trabajar con Entity Framework Core, como ToListAsync().
using System.Threading.Tasks; //para trabajar con tareas as�ncronas (await, async).

namespace CRUD_Productos.Pages.Productos
{
 
    public class IndexModel : PageModel
    {
        // La siguiente l�nea declara una variable privada que ser� usada para interactuar
        // con la base de datos.
        // _context es una instancia del contexto de la base de datos (ApplicationDbContext).
        private readonly ApplicationDbContext _context;

        // Constructor de la clase, donde se realiza la inyecci�n de dependencias.
        // Al recibir el ApplicationDbContext, podemos usar _context para interactuar
        // con la base de datos.
        public IndexModel(ApplicationDbContext context) // El par�metro 'context' es el contexto de la base de datos.
        {
            _context = context; // Asignamos el contexto a la variable privada _context.
        }

        // Propiedad p�blica que almacenar� la lista de productos que se obtendr�n
        // de la base de datos.
        public IList<Producto> productos { get; set; } // Lista de productos que ser� usada en la vista.

        // El m�todo OnGet se ejecuta cuando el usuario realiza una solicitud HTTP GET a esta p�gina.
        public async Task OnGet()
        {
            // Aqu� realizamos una consulta asincr�nica a la base de datos para obtener todos
            // los productos.
            // _context.Producto hace referencia a la tabla de productos en la base de datos.
            // ToListAsync() convierte la consulta en una lista de objetos 'Producto'
            // de manera asincr�nica.
            productos = await _context.Producto.ToListAsync(); // Asignamos la lista de productos a la propiedad 'productos'.
        }
    }
}
