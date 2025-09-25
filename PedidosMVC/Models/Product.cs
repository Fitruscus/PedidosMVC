using System.ComponentModel.DataAnnotations;

namespace PedidosMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0")]
        public int Stock { get; set; }

        [StringLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres")]
        public string Categoria { get; set; } 
    }
}