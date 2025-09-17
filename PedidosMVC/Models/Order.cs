namespace PedidosMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}