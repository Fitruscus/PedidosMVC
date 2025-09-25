namespace PedidosMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; } 
        public DateTime Fecha { get; set; }
    }
}