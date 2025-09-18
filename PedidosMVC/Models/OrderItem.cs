using System.ComponentModel.DataAnnotations;

namespace PedidosMVC.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int Producto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El subtotal debe ser positivo")]
        public int Subtotal { get; set; }
    }
}