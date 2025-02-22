using CRUD_Productos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Productos.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Aqui se agregan los modelos
        //Primer modelo
        public DbSet<Producto> Producto { get; set; }
    }
}
