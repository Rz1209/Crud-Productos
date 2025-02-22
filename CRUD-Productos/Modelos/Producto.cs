using System.ComponentModel.DataAnnotations;

namespace CRUD_Productos.Modelos
{
    public class Producto
    {
        [Key] //Opcional si el nombre contiene 'Id'
        public int Id { get; set; } //Si el nombre contiene 'Id' no se necesita agregar la DataAnotations [KEY], ej IdProdcuto, ProductoId, Id
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }//Para desactivar el warning del null, click derecho sobre el proyecto y editar, <Nullable>disable</Nullable>
        
        [Range(1,1000, ErrorMessage = "El precio debe estar entre 1 y 1000 USD")]
        public decimal Precio { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "El estock no puede ser negativo")]
        public int Stock { get; set; }
        
        public DateTime FechaCreacion { get; set; }
    }
}
