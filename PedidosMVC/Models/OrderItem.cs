using System.ComponentModel.DataAnnotations;

namespace PedidosMVC.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Cantidad { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public decimal Subtotal => (Product?.Precio ?? 0) * Cantidad;
    }
}