using System.Collections.Generic;

namespace PedidosMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}