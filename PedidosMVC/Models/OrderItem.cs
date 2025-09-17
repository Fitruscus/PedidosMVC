namespace PedidosMVC.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public int Subtotal { get; set; }
    }
}